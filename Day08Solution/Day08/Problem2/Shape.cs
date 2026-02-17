using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day08.Problem2
{
    internal abstract class Shape
    {
        // subclass MUST implement
        public abstract double GetArea();

        // subclass inherits for free
        public void Display()
        {
            Console.WriteLine(GetType().Name + " Area = " + Math.Round(GetArea(), 2));
        }
    }
}
