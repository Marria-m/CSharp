using Day08.Interface;
using Day08.Problem2;
using Day08.Problem4;
using Day08.Problem5;
using Day08.Problem6;
using Day08.Problem7;
using Day08.Problem8;
using Day08.Problme3;
using System;

namespace Day08
{
    internal class Program
    {
        static void Main(string[] args)
        {
            #region Problem1
            Console.WriteLine("Problem1");
            IVehicle[] vehicles = new IVehicle[]
            {
                new Car("Toyota"),
                new Bike("Yamaha")
            };

            foreach (IVehicle v in vehicles)
            {
                v.StartEngine();
                v.StopEngine();
            }
            // Toyota car started.
            // Toyota car stopped.
            // Yamaha bike started.
            // Yamaha bike stopped.
            #endregion

            Console.WriteLine();

            #region Problem2
            Console.WriteLine("Problem2");
            Shape[] shapes = { 
                new Rectangle(4, 6), 
                new Circle(5) 
            };

            foreach (Shape s in shapes)
                s.Display();
            // Rectangle Area = 24.00
            // Circle Area = 78.54
            #endregion

            #region Problem3
            Console.WriteLine("Problem3");
            Product[] products = new Product[]
            {
            new Product(1, "Laptop",  9999.99),
            new Product(2, "Mouse",    25.00),
            new Product(3, "Keyboard", 555.00)
            };

            Array.Sort(products); // uses CompareTo() 

            foreach (Product p in products)
                Console.WriteLine(p);
            // id: 1, name: Laptop, price: 9999.99
            // id: 2, name: Mouse, price: 25.00
            // id: 3, name: Keyboard, price: 555.00
            #endregion

            Console.WriteLine();

            #region Problem4
            Console.WriteLine("Problem4");
            Student original = new Student(1, "Marie", 100);
            // Shallow copy
            Student shallow = original; // reference copy

            // Deep copy
            Student deep = new Student(original); // creates a new object with the same values

            original.Grade = 90;

            Console.WriteLine("Original: " + original);  // Original: id: 1, name: Marie, grade: 90
            Console.WriteLine("Shallow: " + shallow);  // Shallow: id: 1, name: Marie, grade: 90 (same as original)
            Console.WriteLine("Deep: " + deep);  // Deep: id: 1, name: Marie, grade: 100 (independent copy)
            #endregion

            Console.WriteLine();

            #region Problem5
            Console.WriteLine("Problem5");
            Robot r = new Robot();
            IWalkable w = r;

            r.Walk();  // Robot walking normally
            w.Walk();  // Robot walking as IWalkable
            #endregion

            Console.WriteLine();

            #region Problem6
            Console.WriteLine("Problem6");
            Account a = new Account(1, "Mariam", 6000);
            Console.WriteLine(a);  // Id: 1, Account Holder: Mariam, Balance: $6000.00

            a.Balance = -100;  // Balance cant be negative
            Console.WriteLine(a);  // still $6000.00

            a.Balance = 7500;
            Console.WriteLine(a);  // Id: 1, Account Holder: Mariam, Balance: $7500.00
            #endregion

            Console.WriteLine();

            #region Problem7
            Console.WriteLine("Problem7");
            ILogger console = new ConsoleLogger();
            ILogger silent = new SilentLogger();

            console.Log("App started.");  // Consol 10:45 AM > App started
            silent.Log("App started.");   // default log App started
            #endregion

            Console.WriteLine();

            #region Peoblem8
            Console.WriteLine("Problem8");
            Book b1 = new Book();
            Book b2 = new Book("Fourth Wing");
            Book b3 = new Book("throne of glass", "Sarah J. Maas");

            Console.WriteLine(b1); // "Unknown Title" by Unknown Author
            Console.WriteLine(b2); // "Fourth Wing" by Unknown Author
            Console.WriteLine(b3); // "throne of glass" by Sarah J. Maas
            #endregion
        }
    }
}
