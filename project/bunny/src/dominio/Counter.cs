using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace bunny.src.dominio
{
    class Counter
    {
        private int counter;
        public Counter()
        {
            this.counter = 0;
        }
        public void increase()
        {
            if (counter < 59 && counter >= 0) counter++;
            else counter = 0;
        }
        public void decrease()
        {
            if (counter < 59 && counter >= 1) counter--;
            else counter = 59;
        }
        public int getCounter()
        {
            return counter;
        }
    }
}
