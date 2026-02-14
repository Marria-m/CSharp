using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day06
{
    public class TypeA
    {
        private int F;   // accessible only here
        internal int G;  // accessible anywhere in the same project
        public int H;    // accessible from any code

        public void print()
        {
            Console.WriteLine($"F is {F}, G is {G}, H is {H}");
        }
    }
}
