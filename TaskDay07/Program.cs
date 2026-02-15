using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Reflection;

namespace Day07
{
    internal class Program
    { 
        static void Main()
        {
            #region Problem1
            Car c1 = new Car();
            Car c2 = new Car(101);
            Car c3 = new Car(102, "Toyota");
            Car c4 = new Car(103, "BMW", 45000.99);

            Console.WriteLine(c1); // Id=0 Brand=Unknown Price=$0.00
            Console.WriteLine(c2); // Id=101 Brand=Unknown Price=$0.00
            Console.WriteLine(c3); // Id=102 Brand=Toyota Price=$0.00
            Console.WriteLine(c4); // Id=103 Brand=BMW Price=$45,000.99
            #endregion

            #region Problem2
            Calculator calc = new Calculator();

            Console.WriteLine(calc.Sum(3, 4));  // 7
            Console.WriteLine(calc.Sum(1, 2, 3));  // 6
            Console.WriteLine(calc.Sum(2.5, 1.75));  // 4.25
            #endregion

            #region Problem3 + Problem4 + Problem5 
            Child ch = new Child(1, 2, 3);  // Problem 3
            Console.WriteLine(ch);  // (1, 2, 3)  // Problem5

            // Problem4
            Console.WriteLine(ch.Product()); // 6 Child.Product()
            Console.WriteLine(ch.Sum());     // 6 Child.Sum()

            Parent p = ch;
            Console.WriteLine(p.Product()); // 2 Parent.Product()! (early binding, ref type decides)
            Console.WriteLine(p.Sum());     // 6 Child.Sum()  (late binding, object decides)

            Parent p = new Parent(1, 2);
            Child ch = new Child(1, 2, 3);

            // problem5
            Console.WriteLine(p);   // (1, 2)
            Console.WriteLine(ch);  // (1, 2, 3)
            #endregion


            #region Problem6
            Rectangle rect = new Rectangle(5, 3);
            rect.Draw();  // Drawing Rectangle: 5 x 3
            Console.WriteLine(rect.Area);  // 15

            IShape shape = rect;  // polymorphic reference
            shape.Draw();
            Console.WriteLine(shape.Area);
            #endregion

            #region Problem7
            IShape s = new Circle(5);
            s.Draw();
            s.PrintDetails();
            // Drawing Circle
            // Area = 78.5398
            #endregion

            #region Problem8
            IMovable movable = new Car("Toyota");
            movable.Move(); // Toyota is moving
            #endregion

            #region Problem9
            FileHandler file = new FileHandler("data.txt");
            file.Read();  // Reading from data.txt
            file.Write();  // Writing to data.txt

            //IReadable reader = file;
            //IWritable writer = file;
            //reader.Read();
            //writer.Write();
            // just trying something
            #endregion

            #region Problem10
            Shape s = new Rectangles(4, 6);
            s.Draw();  // Drawing Rectangle 4 x 6
            Console.WriteLine(s.CalculateArea());  // 24
            #endregion
        }
    }
}
