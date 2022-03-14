using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.IO;
using Excel = Microsoft.Office.Interop.Excel;
using System.Threading;


namespace SIMSrq2
{
    interface ITimeObservable {
        void AddTimer(IEnumerable<ITimeObserver> timers);
        void UpdateTime(double deltaTime);
    }
    interface ITimeObserver
    {
        void CorrectTime(double deltaTime);
    }
    class Model: ITimeObservable
    {
        private HashSet<ITimeObserver> timers = new HashSet<ITimeObserver>();
        string path = "iamlog.txt";
        string str;
        public bool isRunning;

        Input input;
        FirstPhase firstPhase1;
        FirstPhase firstPhase2;
        FirstQueue queue;
        SecondPhase secondPhase;
        Orbit orbit;

        public double currentTime;
        public double maxCalls;
        public double p;

        public List<double> orbitLength;

        int inputCalls;
        int losingCalls;
        int leavingCalls;
        int queueCalls;
        int orbitCalls;

        public double maxTime;
        double deltaTime;
        double callFromOrbitTime;

        public List<double> times;
        public int eventCount;

        int k;

        Excel.Application excelApp = new Excel.Application();
        Excel.Workbook workBook;
        Excel.Worksheet workSheet;

        public int simulationsCount;

        public Model()
        {
            workBook = excelApp.Workbooks.Add();
        }

        public void AddTimer(IEnumerable<ITimeObserver> times) {
            foreach (ITimeObserver time in times)
            {
                timers.Add(time);
            }
        }

        public void UpdateTime(double deltaTime)
        {
            foreach (ITimeObserver timer in timers)
            {
                timer.CorrectTime(deltaTime);
            }
        }
        
        public void StartSimulation()
        {
            isRunning = true;
            GetNewCall();
            while (currentTime < maxTime)
            {
                FindClosestTime();
            }
            EndSimulation();
        }

        public void EndSimulation()
        {
            isRunning = false;
            File.WriteAllText(path, str);
            LogToExcel();
        }

        public void ResetModel(double lambda, double mu1, double mu2, int N, double sigma, double p)
        {
            times = new List<double>();

            input = new Input(lambda);
            firstPhase1 = new FirstPhase(mu1);
            firstPhase2 = new FirstPhase(mu1);
            secondPhase = new SecondPhase(mu2);
            orbit = new Orbit(sigma);
            queue = new FirstQueue();
            AddTimer(new List<ITimeObserver>() { input, firstPhase1, firstPhase2, secondPhase, orbit });

            queue.currentLength = 0;
            queue.maxLength = N;
            orbitLength = new List<double>();
            this.p = p;

            inputCalls = 0;
            losingCalls = 0;
            leavingCalls = 0;
            queueCalls = 0;
            orbitCalls = 0;
   
            currentTime = 0;
            maxCalls = 0;
        }

        /// <summary>
        /// Переход к ближайшему событию
        /// </summary>
        public void FindClosestTime()
        {
            deltaTime = 10000;
            callFromOrbitTime = orbit.GetClosestTime();

            times.AddRange(new List<double> { input.newCallTime, firstPhase1.servingTime, firstPhase2.servingTime, secondPhase.servingTime, callFromOrbitTime });
            times.RemoveAll(c => c == 0);
            deltaTime = times.Min();

            k =-1;
            if (deltaTime == input.newCallTime) k = 0;
            if (deltaTime == firstPhase1.servingTime) k = 1;
            if (deltaTime == firstPhase2.servingTime) k = 2;
            if (deltaTime == secondPhase.servingTime) k = 3;
            if (deltaTime == callFromOrbitTime) k = 4;
            
            currentTime += deltaTime;

            UpdateTime(deltaTime);
            switch (k)
            {
                //Приход новой заявки
                case 0:
                    GetNewCall();
                    //LogToTxt(" Новая заявка");
                    break;
                //Конец обслуживания на первом приборе первой фазы
                case 1:
                    firstPhase1.EndServing();
                    if (queue.currentLength > 0)
                    {
                        queue.currentLength--;
                        firstPhase1.NewServing();
                    }
                    if (Calc.isLeaving(p))
                        NewCallInSecondPhase();
                    else
                        leavingCalls++;
                    //LogToTxt(" Конец обслуживания на первом приборе 1 фазы");
                    break;
                //Конец обслуживания на втором приборе первой фазы
                case 2:
                    firstPhase2.EndServing();
                    if (queue.currentLength > 0)
                    {
                        queue.currentLength--;
                        firstPhase2.NewServing();
                    }
                    if (Calc.isLeaving(p))
                        NewCallInSecondPhase();
                    else
                        leavingCalls++;
                    //LogToTxt(" Конец обслуживания на втором приборе 1 фазы");
                    break;
                //Конец обслуживания на второй фазе
                case 3:                    
                    secondPhase.EndServing();
                    //LogToTxt(" Конец обслуживания на 2 фазе");
                    break;
                //Обращение заявки с орбиты
                case 4:
                    orbit.RemoveCall();
                    orbitLength.Add(orbit.currentOrbitTime.Count);
                    if (secondPhase.isServing == false)
                        secondPhase.GetCall();
                    else
                        orbit.NewCall();
                    //LogToTxt(" Вызов с орбиты");
                    break;
                default:
                    //LogToTxt(" Неизвестное событие");
                    break;
            }
            times.Clear();
        }

        public void GetNewCall()
        {
            inputCalls++;
            input.GenerateEvent();
            if ((queue.currentLength < queue.maxLength) && (firstPhase1.isServing == true) && (firstPhase2.isServing == true))
            {
                queue.currentLength++;
            }
            else if ((queue.currentLength == 0) && (firstPhase1.isServing == false))
            {
                //Приоритет у первого прибора?
                firstPhase1.NewServing();
            }
            else if ((queue.currentLength == 0) && (firstPhase2.isServing == false))
            {
                firstPhase2.NewServing();
            }
            else if (queue.currentLength == queue.maxLength)
            {
                losingCalls++;
            }
        }

        public void NewCallInSecondPhase()
        {
            if (secondPhase.isServing)
            {
                orbit.NewCall();
                orbitLength.Add(orbit.currentOrbitTime.Count);
            }
            else
                secondPhase.GetCall();
        }

        public void LogToExcel()
        {
            workSheet = (Excel.Worksheet)workBook.Worksheets.get_Item(1);
            int i = 1;
            foreach (double call in orbitLength)
            {
                i++;
                workSheet.Cells[i, 1] = call;
            }
        }

        public void LogToTxt(string _event)
        {
            orbitCalls = orbit.currentOrbitTime.Count;
            eventCount++;
            str += eventCount.ToString() + _event;
            str += "\nПромежутки времени:";
            str += "\nПриход новой заявки: " + input.newCallTime;
            str += "\nКонец обслуживания на первом приборе 1 фазы: " + firstPhase1.servingTime;
            str += "\nКонец обслуживания на втором приборе 1 фазы: " + firstPhase2.servingTime;
            str += "\nКонец обслуживания на 2: " + secondPhase.servingTime;
            str += "\nВремя обращения с орбиты: " + orbit.GetClosestTime();
            str += "\nВходящие: " + inputCalls.ToString() + " Потерянные: " + losingCalls.ToString()+ " Покинувшие: " + leavingCalls.ToString() + " Очередь: " + queueCalls.ToString();
            str += "\nОрбита:";
            foreach (double call in orbit.currentOrbitTime)
            {
                str += "\n" + call.ToString();
            }
            str += "\n\n";
        }

        public void OpenTab()
        {
            excelApp.Visible = true;
            excelApp.UserControl = true;
        }     
    }
}
