﻿using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace SIMSrq2
{
    class SecondPhase: ITimeObserver
    {
        public double mu2;
        public bool isServing;

        public double servingTime;

        public SecondPhase(double mu2)
        {
            this.mu2 = mu2;
            isServing = false;
            servingTime = 0;
        }
        public void GetCall()
        {
            isServing = true;
            servingTime = Calc.ExpDist(mu2);            
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
