using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day07
{
    internal class Circle : IShape
    {
        public double Radius { get; set; }
        public Circle(double radius) { Radius = radius; }

        public double Area {
            Math.PI * Radius * Radius;
        }

        public void Draw()
        {
            Console.WriteLine($"Drawing Circle with radius {Radius}");
        }
        // PrintDetails is inherited automatically
    }
}
