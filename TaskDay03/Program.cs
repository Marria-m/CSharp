using System;
using System.Drawing;
using System.Security.Principal;
using System.Text;
using System.Text.RegularExpressions;

namespace Task2
{
    class Program
    {
        static void Main(string[] args)
        {
            #region int.Parse vs Convert.ToInt32
            Console.Write("Enter a number: ");
            string input = Console.ReadLine();

            try
            {
                int parsed = int.Parse(input);
                Console.WriteLine($"int.Parse result: {parsed}");
            }
            catch (Exception e)
            {
                Console.WriteLine($"int.Parse error: {e.Message}");
            }

            try
            {
                int converted = Convert.ToInt32(input);
                Console.WriteLine($"Convert.ToInt32 result: {converted}");
            }
            catch (Exception e)
            {
                Console.WriteLine($"Convert.ToInt32 error: {e.Message}");
            }

            // Question Answer:
            // int.Parse(null) throws ArgumentNullException
            // Convert.ToInt32(null) returns 0
            #endregion

            #region int.TryParse
            Console.Write("\nEnter a number: ");
            string input2 = Console.ReadLine();

            bool success = int.TryParse(input2, out int result);
            if (success)
                Console.WriteLine($"Valid {result}");
            else
                Console.WriteLine("Invalid number");

            // Question Answer:
            // TryParse is better because: No exceptions thrown, it returns true/false, it has better performance

            #endregion

            #region Object and GetHashCode
            object obj;

            obj = 100;
            Console.WriteLine($"\nint 100: {obj.GetHashCode()}");

            obj = "Mariam";
            Console.WriteLine($"string Mariam: {obj.GetHashCode()}");

            obj = 3.14;
            Console.WriteLine($"double 3.14: {obj.GetHashCode()}");

            /*
             Question Answer:

             GetHashCode purposes are:
             1.Returns numeric code for object
             2.Used by Dictionary anf HashSet for fast lookup o(1)
             3.Same objects must have same hash code which is important for collections
            */
            #endregion

            #region Reference Equality
            Person p1 = new Person { Name = "Mariam", Age = 19 };
            Person p2 = p1; // both point to same object now 

            Console.WriteLine($"\nBefore change:");
            Console.WriteLine($"p1: {p1.Name}, {p1.Age}");
            Console.WriteLine($"p2: {p2.Name}, {p2.Age}");

            p1.Age = 20; // change through first reference

            Console.WriteLine($"\nAfter changing p1.Name to 20:");
            Console.WriteLine($"p1: {p1.Name}, {p1.Age}");
            Console.WriteLine($"p2: {p2.Name}, {p2.Age}");

            /*
            Question Answer:

            Reference equality checks whether two variables point to the same object in memory, 
            not whether their data matches.
            This is useful for performance and identity checks, and to avoid unintended side effects.
            Object.
            */
            #endregion

            #region String Immutability
            string text = "Hi";
            Console.WriteLine($"\nBefore: '{text}'");
            Console.WriteLine($"HashCode: {text.GetHashCode()}");

            text = text + " Willy";
            Console.WriteLine($"\nAfter: '{text}'");
            Console.WriteLine($"HashCode: {text.GetHashCode()}");

            /*
             Question Answer:
            
            Immutability makes strings safe to share across memory and threads without fear.
            it enables string interning, and saving memory by reusing identical values.
            Modifications create new objects, which can impact performance if done excessively.
            */

            #endregion

            #region StringBuilder
            StringBuilder sb = new StringBuilder("Hi");
            Console.WriteLine($"\nBefore: '{sb}'");
            Console.WriteLine($"HashCode: {sb.GetHashCode()}");

            sb.Append(" Willy");
            Console.WriteLine($"\nAfter: '{sb}'");
            Console.WriteLine($"HashCode: {sb.GetHashCode()}");

            /*Question Answers:
             How does StringBuilder address the inefficiencies of string concatenation? 

             1.Modifies same buffer instead of creating new strings
             2.Reduces memory allocations
             3.Improves performance for multiple modifications
             4.Optimized for frequent changes
            */

            #endregion

            #region String Formatting
            Console.Write("\nEnter first number: ");
            int a = Convert.ToInt32(Console.ReadLine());

            Console.Write("Enter second number: ");
            int b = Convert.ToInt32(Console.ReadLine());

            // Concatenation
            Console.WriteLine("Sum is " + a + " + " + b + " = " + (a + b));

            // Composite formatting
            Console.WriteLine(string.Format("Sum is {0} + {1} = {2}", a, b, a + b));

            // String interpolation
            Console.WriteLine($"Sum is {a} + {b} = {a + b}");

            // Question Answer:
            // String interpolation ($) is most used because:
            // 1. Most readable
            // 2. Compile-time checking
            // 3. Clean syntax
            #endregion

            #region Problem 8: StringBuilder Operations
            StringBuilder sb2 = new StringBuilder("Hello World");
            Console.WriteLine($"\nOriginal: '{sb2}'");

            sb2.Append("!");
            Console.WriteLine($"After Append: '{sb2}'");

            sb2.Replace("World", "C#");
            Console.WriteLine($"After Replace: '{sb2}'");

            sb2.Insert(6, "Beautiful ");
            Console.WriteLine($"After Insert: '{sb2}'");

            sb2.Remove(6, 10);
            Console.WriteLine($"After Remove: '{sb2}'");

            // Question Answer:
            // StringBuilder designed for modifications by:
            // 1. Mutable char buffer
            // 2. Can grow when needed
            // 3. Returns same object for chaining
            // 4. No new objects for each change
            #endregion
        }
    }

    class Person
    {
        public string Name { get; set; }
        public int Age { get; set; }
    }
}