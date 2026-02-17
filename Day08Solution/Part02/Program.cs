using System;

namespace Day08
{
    // Interface definition
    internal interface IShapeSeries
    {
        int CurrentShapeArea { get; set; }
        void GetNextArea();
        void ResetSeries();
    }

    // SquareSeries implementation
    internal class SquareSeries : IShapeSeries
    {
        private int side = 0;
        public int CurrentShapeArea { get; set; }

        public void GetNextArea()
        {
            side++;
            CurrentShapeArea = side * side;
        }

        public void ResetSeries()
        {
            side = 0;
            CurrentShapeArea = 0;
        }
    }

    // CircleSeries implementation
    internal class CircleSeries : IShapeSeries
    {
        private int radius = 0;
        public int CurrentShapeArea { get; set; }

        public void GetNextArea()
        {
            radius++;
            CurrentShapeArea = (int)(Math.PI * radius * radius);
        }

        public void ResetSeries()
        {
            radius = 0;
            CurrentShapeArea = 0;
        }
    }

    // Shape class for sorting
    internal class Shape : IComparable
    {
        public string Name { get; set; }
        public double Area { get; set; }

        public Shape(string name, double area)
        {
            Name = name;
            Area = area;
        }

        public int CompareTo(object obj)
        {
            Shape other = (Shape)obj;
            if (this.Area < other.Area) return -1;
            else if (this.Area > other.Area) return 1;
            else return 0;
        }

        public override string ToString()
        {
            return Name + " -> Area = " + Math.Round(Area, 2);
        }
    }

    // Abstract base for geometric shapes
    internal abstract class GeometricShape
    {
        public double Dimension1 { get; set; }
        public double Dimension2 { get; set; }

        public abstract double CalculateArea();
        public abstract double Perimeter { get; }
    }

    // Triangle implementation
    internal class Triangle : GeometricShape
    {
        public Triangle(double baseLength, double height)
        {
            Dimension1 = baseLength;
            Dimension2 = height;
        }

        public override double CalculateArea()
        {
            return 0.5 * Dimension1 * Dimension2;
        }

        public override double Perimeter
        {
            get
            {
                double hypotenuse = Math.Sqrt(Dimension1 * Dimension1 + Dimension2 * Dimension2);
                return Dimension1 + Dimension2 + hypotenuse;
            }
        }

        public override string ToString()
        {
            return "Triangle | Base=" + Dimension1 + ", Height=" + Dimension2
                 + " | Area=" + Math.Round(CalculateArea(), 2)
                 + " | Perimeter=" + Math.Round(Perimeter, 2);
        }
    }

    // Rectangle implementation
    internal class Rectangle : GeometricShape
    {
        public Rectangle(double width, double height)
        {
            Dimension1 = width;
            Dimension2 = height;
        }

        public override double CalculateArea()
        {
            return Dimension1 * Dimension2;
        }

        public override double Perimeter
        {
            get { return 2 * (Dimension1 + Dimension2); }
        }

        public override string ToString()
        {
            return "Rectangle | " + Dimension1 + "x" + Dimension2
                 + " | Area=" + Math.Round(CalculateArea(), 2)
                 + " | Perimeter=" + Math.Round(Perimeter, 2);
        }
    }

    // Factory Pattern
    internal class ShapeFactory
    {
        public static GeometricShape CreateShape(string shapeType, double dim1, double dim2)
        {
            if (shapeType == "Rectangle") return new Rectangle(dim1, dim2);
            else if (shapeType == "Triangle") return new Triangle(dim1, dim2);
            else
            {
                Console.WriteLine("Unknown shape type: " + shapeType);
                return null;
            }
        }
    }

    // Main Program
    internal class Program
    {
        // Helper method to print 10 shapes from any series
        static void PrintTenShapes(IShapeSeries series)
        {
            series.ResetSeries();
            for (int i = 0; i < 10; i++)
            {
                series.GetNextArea();
                Console.WriteLine("Shape " + (i + 1) + " area = " + series.CurrentShapeArea);
            }
        }

        // Selection Sort implementation
        public static void SelectionSort(int[] numbers)
        {
            for (int i = 0; i < numbers.Length - 1; i++)
            {
                int minIndex = i;

                for (int j = i + 1; j < numbers.Length; j++)
                {
                    if (numbers[j] < numbers[minIndex])
                        minIndex = j;
                }

                // Swap
                int temp = numbers[minIndex];
                numbers[minIndex] = numbers[i];
                numbers[i] = temp;
            }
        }

        static void Main()
        {
            PrintTenShapes(new SquareSeries());

            PrintTenShapes(new CircleSeries());

            Shape[] shapes = new Shape[]
            {
                new Shape("Circle",    78.54),
                new Shape("Square",    25.00),
                new Shape("Rectangle", 48.00),
                new Shape("Triangle",  15.00),
                new Shape("Circle",   113.10)
            };

            Console.WriteLine("\nBefore sorting:");
            foreach (Shape s in shapes)
                Console.WriteLine(s);

            Array.Sort(shapes);

            Console.WriteLine("\nAfter sorting (by area):");
            foreach (Shape s in shapes)
                Console.WriteLine(s);

            GeometricShape[] geoShapes = new GeometricShape[]
            {
                new Triangle(6, 4),
                new Rectangle(5, 3)
            };

            foreach (GeometricShape g in geoShapes)
                Console.WriteLine(g);

            int[] areas = { 78, 25, 48, 15, 113, 9, 3 };

            Console.Write("Before: ");
            foreach (int a in areas) Console.Write(a + " ");

            SelectionSort(areas);

            Console.Write("\nAfter:  ");
            foreach (int a in areas) Console.Write(a + " ");

            GeometricShape r = ShapeFactory.CreateShape("Rectangle", 5, 3);
            GeometricShape t = ShapeFactory.CreateShape("Triangle", 6, 4);

            Console.WriteLine(r);
            Console.WriteLine(t);

            Console.WriteLine("\n\nPress any key to exit...");
            Console.ReadKey();
        }
    }
}
