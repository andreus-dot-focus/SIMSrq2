using System;
using System.Collections.Generic;
using System.Text;

namespace SIMSrq2
{
    struct FirstQueue 
    {
        public int maxLength;
        public int currentLength;
    }
    class FirstPhase: ITimeObserver
    {
        public double mu1;
        public bool isServing;

        public double servingTime;

        public int inputCalls;
        Random rnd;
        
        public FirstPhase(double mu1)
        {
            isServing = false;
            this.mu1 = mu1;
            servingTime = 0;
            rnd = new Random();
        }

        public void NewServing()
        {
            isServing = true;
            servingTime = Calc.ExpDist(mu1);
        }
        public void EndServing()
        {
            isServing = false;
            servingTime = 0;                     
        }        
        public void CorrectTime(double deltaTime)
        {
            if(servingTime!=0)
                servingTime -= deltaTime;
        }
    }
}
