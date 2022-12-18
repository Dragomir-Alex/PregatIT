using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TemaPractica1
{
    // validare, text mesaje
    public class IntegerInterval
    {
        private int lowerLimit;
        private int upperLimit;
        public int LowerLimit
        {
            get { return lowerLimit; }
            set
            {
                if (value > upperLimit)
                {
                    lowerLimit = upperLimit;
                    upperLimit = value;
                }
            }
        }
        public int UpperLimit
        {
            get { return upperLimit; }
            set
            {
                if (value < lowerLimit)
                {
                    upperLimit = lowerLimit;
                    lowerLimit = value;
                }
            }
        }

        public IntegerInterval()
        {
            lowerLimit = 0;
            upperLimit = 1;
        }

        public IntegerInterval(int lowerLimit, int upperLimit)
        {
            LowerLimit = lowerLimit;
            UpperLimit = upperLimit;
        }
    }
}