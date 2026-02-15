using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day07
{
    internal interface IShape
    {
        double Area { get; }   // get-only property
        void Draw();

        void PrintDetails()
        {
            Console.WriteLine($"Area = {Area}");
        }
    }
}
