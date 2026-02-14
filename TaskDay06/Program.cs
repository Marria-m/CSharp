using Day06;
using System;
using System.Xml.Linq;


namespace CSharpDay06Solution
{
    internal class Program
    {
        // two functions for problem 6
        public static void ModifyP(Point p)
        {
            p.x = 10; // modifies copy (value type)
        }

        static void ModifyEmp(Employee e)
        {
            e.SetName("MMMMM");  // modifies the original object (ref)
        }

        static void Main()
        {

            #region Problem1 Question
            // Question: Why can't a struct inherit from another struct or class in C#?
            /* Answer:
             Structs are System.ValueType, and this already inherits from Object. 
             and they dont support inheritance because they are designed to be lightweight and allocated on the stack. 
             another thing that allowing inheritance would introduce virtual method overhead and complicate memory layout
             */
            #endregion

            #region Problem2 Test
            TypeA n = new TypeA();
            // n.F = 10;  // this will give us an error because F is private
            n.G = 20;     // acc because in the same project (internal)
            n.H = 30;     // acc because its public
            n.print();    // acc because its public so now we can acc all the members

            // Question: How do access modifiers impact the scope and visibility of a class member?  
            /* Answer:
             * private members are only accessible within the same class
             * internal members are accessible within the same project 
             * public members are accessible from any code that can access the class.
             */
            #endregion

            #region Problem3 Test
            Employee emp = new Employee();  // 0, null, 0
            Console.WriteLine(emp);

            Employee emp2 = new Employee(1, "Mariam", 40000);
            Console.WriteLine(emp2);

            Employee emp3 = new Employee();
            emp3.SetName("marie");
            emp3.Salary = 6000;
            Console.WriteLine($"Name: {emp3.GetName()}, Salary: {emp3.Salary}");  // just to test the setter and getter ^-^

            // Question: Why is encapsulation critical in software design?  
            /* Answer: 
             * it allows us to hide the implementation details of a class and only expose a controlled interface to the outside world. 
             * this is for maintainability and flexibility in code
             */
            #endregion

            #region Problem4 Test
            Point p1 = new Point(1);      // x = 1 y = 0
            Point p2 = new Point(1, 2);  // x = 1 y = 2

            Console.WriteLine(p1);
            Console.WriteLine(p2);

            // Question: what is constructors in structs? 
            /* Answer:
             * ctor in structs are used to initialize the fields of the struct when it is created. 
             * they can be parameterless (not all cases like 5.0) or parameterized but they must initialize all fields of the struct. 
             * and actually structs have an implicit parameterless constructor that initializes all fields to their default values.
             */

            #endregion

            #region Problem5 Test
            Point P1;
            P1 = new Point();  // x = 0 y = 0
            Console.WriteLine(P1.x);  // x = 0
            Console.WriteLine(P1.y);  // 0
            Point P2 = new Point(2, 4); // x = 2, y = 4
            Console.WriteLine(P2.x); // 2
            Console.WriteLine(P2.y); // 4
            Point P03 = new Point(10);
            Console.WriteLine(P03.x); // 10
            Console.WriteLine(P03.y); // 0

            // Question: How does overriding methods like ToString() improve code readability? 
            /* Answer:
             * it allows us to provide a meaningful string representation of an object 
             * it improves code readability to easily understand the state of an object when we print it.
             */
            #endregion

            #region Problem6 Test
            Point p = new Point(5, 20);
            ModifyP(p);
            Console.WriteLine(p.x); // still 10 (the copy was modified)

            Employee emp6 = new Employee(2, "Marie", 6000);
            ModifyEmp(emp6);
            Console.WriteLine(emp6.GetName()); // "MMMMM" (the original modified)

            // Question: How does memory allocation differ for structs and classes in C#?
            /* Answer:
             * structs are value types and are allocated on the stack and they hold their data directly
             * classes are reference types and are allocated on the heap and they hold a reference to the data
             * assigning a struct to another variable creates a copy of the data but for a class variable copies the reference not the actual object
             */
            #endregion

        }
    }
}