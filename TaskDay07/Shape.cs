using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day07
{
    internal abstract class Shape
    {
        // virtual has a body, derived class MAY override
        public virtual void Draw() { 
            Console.WriteLine("Drawing Shape");
        }

        // abstract method has no body, derived class MUST override
        public abstract double CalculateArea();
    }

    internal class Rectangles : Shape
    {
        public double Width { get; set; }
        public double Height { get; set; }
        public Rectangles(double w, double h) { Width = w; Height = h; }

        public override void Draw()
        {
            Console.WriteLine($"Drawing Rectangle {Width} x {Height}");
        }

        public override double CalculateArea() {
            Width * Height;
        }
    }

}
}
