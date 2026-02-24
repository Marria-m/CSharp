using System;
using System.Collections.Generic;

namespace Day10_Complete_G02
{
    #region Problem 1 & 4
    class Employee : IComparable<Employee>, ICloneable
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public double Salary { get; set; }

        public Employee() { }

        public Employee(int id, string name, double salary)
        {
            Id = id;
            Name = name;
            Salary = salary;
        }

        public int CompareTo(Employee other)
        {
            return this.Salary.CompareTo(other.Salary);
        }

        public object Clone()
        {
            return new Employee(this.Id, this.Name, this.Salary);
        }

        public override string ToString()
        {
            return "Id=" + Id + ", Name=" + Name + ", Salary=" + Salary;
        }
    }

    class Manager : Employee, IComparable<Manager>
    {
        public string Department { get; set; }

        public Manager(int id, string name, double salary, string department)
            : base(id, name, salary)
        {
            Department = department;
        }

        public int CompareTo(Manager other)
        {
            return this.Salary.CompareTo(other.Salary);
        }

        public override string ToString()
        {
            return base.ToString() + ", Dept=" + Department;
        }
    }
    #endregion

    #region Problem 1, 4, 7, 10
    static class SortingAlgorithm<T> where T : IComparable<T>
    {
        public static void Sort(T[] items)
        {
            for (int i = 0; i < items.Length - 1; i++)
            {
                for (int j = 0; j < items.Length - 1 - i; j++)
                {
                    if (items[j].CompareTo(items[j + 1]) == 1)
                    {
                        Swap(ref items[j], ref items[j + 1]);
                    }
                }
            }
        }

        public static void Swap(ref T a, ref T b)
        {
            T temp = a;
            a = b;
            b = temp;
        }
    }

    static class SortingAlgorithmCloneable<T> where T : IComparable<T>, ICloneable
    {
        public static T[] CloneAndSort(T[] items)
        {
            T[] cloned = new T[items.Length];
            for (int i = 0; i < items.Length; i++)
            {
                cloned[i] = (T)items[i].Clone();
            }
            SortingAlgorithm<T>.Sort(cloned);
            return cloned;
        }
    }
    #endregion

    #region Problem 2, 3, 5, 8 
    static class SortingTwo<T>
    {
        public static void Sort(T[] items, Func<T, T, bool> compareFunc)
        {
            for (int i = 0; i < items.Length - 1; i++)
            {
                for (int j = 0; j < items.Length - 1 - i; j++)
                {
                    if (compareFunc.Invoke(items[j], items[j + 1]))
                    {
                        Swap(ref items[j], ref items[j + 1]);
                    }
                }
            }
        }

        public static void Swap(ref T a, ref T b)
        {
            T temp = a;
            a = b;
            b = temp;
        }
    }

    static class CompareFunctions
    {
        public static bool CompareDesc(int x, int y) { return x < y; }
        public static bool CompareAsc(int x, int y) { return x > y; }
        public static bool CompareDoubleDesc(double x, double y) { return x < y; }
        public static bool CompareDoubleAsc(double x, double y) { return x > y; }
        public static bool CompareLengthAsc(string x, string y) { return x.Length > y.Length; }
        public static bool CompareLengthDesc(string x, string y) { return x.Length < y.Length; }
    }
    #endregion

    #region Problem 9
    static class DefaultHelper
    {
        public static T GetDefault<T>()
        {
            return default(T);
        }
    }
    #endregion

    #region Problem 11
    public delegate string StringTransformDelegate(string input);

    static class StringTransformer
    {
        public static List<string> TransformList(List<string> list, StringTransformDelegate transform)
        {
            List<string> result = new List<string>();
            foreach (string s in list)
            {
                result.Add(transform(s));
            }
            return result;
        }

        public static string ToUpperCase(string s) { return s.ToUpper(); }
        public static string Reverse(string s)
        {
            char[] arr = s.ToCharArray();
            Array.Reverse(arr);
            return new string(arr);
        }
        public static string AddPrefix(string s) { return "-> " + s; }
    }
    #endregion

    #region Problem 12
    public delegate int MathOperationDelegate(int a, int b);

    static class MathOperations
    {
        public static int PerformOperation(int a, int b, MathOperationDelegate operation)
        {
            return operation(a, b);
        }

        public static int Add(int a, int b) { return a+ b; }
        public static int Subtract(int a, int b) { return a - b; }
        public static int Multiply(int a, int b) { return a * b; }
        public static int Divide(int a, int b) { return b != 0 ? a / b : 0; }
    }
    #endregion

    #region Problem 13
    public delegate R TransformDelegate<T, R>(T input);

    static class GenericTransformer
    {
        public static List<R> Transform<T, R>(List<T> list, TransformDelegate<T, R> transform)
        {
            List<R> result = new List<R>();
            foreach (T item in list)
            {
                result.Add(transform(item));
            }
            return result;
        }
    }
    #endregion

    internal class Program
    {
        static void Main()
        {
            #region Problem 1 Demo
            Console.WriteLine("P1");
            Employee[] employees = new Employee[]
            {
                new Employee(1, "Mariam", 4567),
                new Employee(2, "Marie", 9567),
                new Employee(3, "Aya", 3567)
            };

            Console.WriteLine("Before sorting:");
            foreach (Employee e in employees)
                Console.WriteLine(e);

            SortingAlgorithm<Employee>.Sort(employees);

            Console.WriteLine("\nAfter sorting (salary ascending):");
            foreach (Employee e in employees)
                Console.WriteLine(e);

            Console.WriteLine("\nQ: Benefits of generic sorting over non-generic?");
            Console.WriteLine("A: Write once, works for any type implementing IComparable<T>.");
            Console.WriteLine("Type-safe (no casting), reusable, maintainable, scalable.");
            Console.WriteLine();
            #endregion

            #region Problem 2 Demo
            Console.WriteLine("p2");
            int[] numbers = { 5, 3, 8, 4, 2 };

            Console.WriteLine("Before sorting:");
            foreach (int n in numbers)
                Console.Write(n + " ");

            // Lambda expression
            SortingTwo<int>.Sort(numbers, (x, y) => x < y);

            Console.WriteLine("\nAfter sorting (descending):");
            foreach (int n in numbers)
                Console.Write(n + " ");

            Console.WriteLine("\n\nQ: How do lambda expressions improve readability and flexibility?");
            Console.WriteLine("A: Concise inline syntax, no need to define separate named methods");
            Console.WriteLine("and easy to change sorting logic on the fly, reduces code clutter.");
            Console.WriteLine();
            #endregion

            #region Problem 3 Demo
            Console.WriteLine("p3");
            string[] names = { "Mariam", "Aya", "Abdallah", "Aliaa" };

            Console.WriteLine("Before sorting:");
            foreach (string n in names)
                Console.Write(n + " ");

            SortingTwo<string>.Sort(names, CompareFunctions.CompareLengthAsc);

            Console.WriteLine("\nAfter sorting (ascendingby length):");
            foreach (string n in names)
                Console.Write(n + " ");

            Console.WriteLine("\n\nQ: Why use dynamic comparer functions?");
            Console.WriteLine("A: Different types need different comparison logic (salary vs name vs length)");
            Console.WriteLine("Dynamic comparers make sorting flexible without changing the sort algorithm");
            Console.WriteLine();
            #endregion

            #region Problem 4 Demo
            Console.WriteLine("P4");
            Manager[] managers = new Manager[]
            {
                new Manager(1, "Sara", 12000, "Engineering"),
                new Manager(2, "Omar", 8500, "Marketing"),
                new Manager(3, "Layla", 15000, "Sales")
            };

            Console.WriteLine("Before sorting:");
            foreach (Manager m in managers)
                Console.WriteLine(m);

            SortingAlgorithm<Manager>.Sort(managers);

            Console.WriteLine("\nAfter sorting (by salary ascending):");
            foreach (Manager m in managers)
                Console.WriteLine(m);

            Console.WriteLine("\nQ: How does IComparable<T> in derived classes enable custom sorting?");
            Console.WriteLine("A: Each class defines its own CompareTo logic - Manager can sort by salary,");
            Console.WriteLine("while a different derived class could sort by a different field.");
            Console.WriteLine();
            #endregion

            #region Problem 5 Demo
            Console.WriteLine("P5");
            Employee[] empsByName = new Employee[]
            {
                new Employee(1, "Aliaa", 5000),
                new Employee(2, "Abdullah", 6000),
                new Employee(3, "Marie", 7000)
            };

            Console.WriteLine("Before sorting:");
            foreach (Employee e in empsByName)
                Console.WriteLine(e);

            Func<Employee, Employee, bool> compareByNameLength = (e1, e2) => e1.Name.Length > e2.Name.Length;
            SortingTwo<Employee>.Sort(empsByName, compareByNameLength);

            Console.WriteLine("\nAfter sorting (name length ascending):");
            foreach (Employee e in empsByName)
                Console.WriteLine(e);

            Console.WriteLine("\nQ: Advantage of using Func<T, T, TResult> in generic programming?");
            Console.WriteLine("A: its Built-in so no need to declare custom delegates. Covers most scenarios.");
            Console.WriteLine();
            #endregion

            #region Problem 6 Demo
            Console.WriteLine("p6");
            int[] nums = { 5, 3, 8, 4, 2 };

            // Anonymous function
            Func<int, int, bool> anonFunc = delegate (int x, int y) { return x > y; };
            SortingTwo<int>.Sort(nums, anonFunc);

            Console.WriteLine("Sorted with anonymous function (ascending):");
            foreach (int n in nums)
                Console.Write(n + " ");

            nums = new int[] { 5, 3, 8, 4, 2 }; // reset

            // Lambda expression
            SortingTwo<int>.Sort(nums, (x, y) => x > y);

            Console.WriteLine("\nSorted with lambda expression (ascending):");
            foreach (int n in nums)
                Console.Write(n + " ");

            Console.WriteLine("\n\nQ: How do anonymous functions differ from lambda expressions?");
            Console.WriteLine("A: Anonymous functions use 'delegate' keyword -> more verbose");
            Console.WriteLine("while Lambda expressions are more concise, modern, and readable");
            Console.WriteLine("-> Both compile to the same IL code but lambda is syntactic sugar");
            Console.WriteLine();
            #endregion

            #region Problem 7 Demo
            Console.WriteLine("p7");
            int a = 10, b = 20;
            Console.WriteLine("Before swap: a=" + a + ", b=" + b);
            SortingAlgorithm<int>.Swap(ref a, ref b);
            Console.WriteLine("After swap:  a=" + a + ", b=" + b);

            Console.WriteLine("\nQ: Why use generic methods for utility functions like Swap?");
            Console.WriteLine("A: to make it Works for any type like int, double, string, custom classes");
            Console.WriteLine("and it couses no code duplication, and single implementation.");
            Console.WriteLine();
            #endregion

            #region Problem 8 Demo
            Console.WriteLine("p8");
            Employee[] empsMulti = new Employee[]
            {
                new Employee(1, "Mariam", 5000),
                new Employee(2, "Abdullah", 5000),
                new Employee(3, "Aliaa", 4000),
                new Employee(4, "Aya", 5000)
            };

            Console.WriteLine("Before sorting:");
            foreach (Employee e in empsMulti)
                Console.WriteLine(e);

            // Sort by salary then by name if salaries are equal
            Func<Employee, Employee, bool> multiCriteria = (e1, e2) => 
            {
                if (e1.Salary != e2.Salary)
                    return e1.Salary > e2.Salary;
                else
                    return String.Compare(e1.Name, e2.Name) > 0;
            };

            SortingTwo<Employee>.Sort(empsMulti, multiCriteria);

            Console.WriteLine("\nAfter sorting (salary asc & name asc):");
            foreach (Employee e in empsMulti)
                Console.WriteLine(e);

            Console.WriteLine("\nQ: Challenges and benefits of multi-criteria sorting?");
            Console.WriteLine("A: Challenge: Logic becomes complex and harder to read and maintain");
            Console.WriteLine("Benefit: Single sort call handles multiple levels of ordering");
            Console.WriteLine();
            #endregion

            #region Problem 9 Demo
            Console.WriteLine("p9");
            int defaultInt = DefaultHelper.GetDefault<int>();
            double defaultDouble = DefaultHelper.GetDefault<double>();
            string defaultString = DefaultHelper.GetDefault<string>();
            Employee defaultEmployee = DefaultHelper.GetDefault<Employee>();

            Console.WriteLine("default(int): " + defaultInt);  // 0
            Console.WriteLine("default(double): " + defaultDouble);  // 0
            Console.WriteLine("default(string): " + (defaultString is null ? "null" : defaultString));
            Console.WriteLine("default(Employee): " + (defaultEmployee is null ? "null" : defaultEmployee.ToString()));

            Console.WriteLine("\nQ: Why is default(T) crucial in generic programming?");
            Console.WriteLine("A: You can't use '0' or 'null' directly when T is unknown.");
            Console.WriteLine("default(T) returns 0 for numbers, false for bool, null for references");
            Console.WriteLine("it ensures generic code works correctly with any type");
            Console.WriteLine();
            #endregion

            #region Problem 10 Demo
            Console.WriteLine("P10");
            Employee[] original = new Employee[]
            {
                new Employee(1, "Ali", 5000),
                new Employee(2, "Sara", 7000)
            };

            Console.WriteLine("Original array:");
            foreach (Employee e in original)
                Console.WriteLine(e);

            Employee[] sorted = SortingAlgorithmCloneable<Employee>.CloneAndSort(original);

            Console.WriteLine("\nCloned and sorted array:");
            foreach (Employee e in sorted)
                Console.WriteLine(e);

            Console.WriteLine("\nOriginal array (unchanged):");
            foreach (Employee e in original)
                Console.WriteLine(e);

            Console.WriteLine("\nQ: How do constraints ensure type safety?");
            Console.WriteLine("A: Constraints guarantee T has required methods/interfaces at compile time");
            Console.WriteLine("Prevents runtime errors,and enables calling specific methods on T");
            Console.WriteLine();
            #endregion

            #region Problem 11 Demo
            Console.WriteLine("P11");
            List<string> words = new List<string> { "Marie", "and", "csharp" };

            Console.WriteLine("Original:");
            foreach (string w in words)
                Console.Write(w + " ");

            List<string> upper = StringTransformer.TransformList(words, StringTransformer.ToUpperCase);
            Console.WriteLine("\n\nUppercase:");
            foreach (string w in upper)
                Console.Write(w + " ");

            List<string> reversed = StringTransformer.TransformList(words, StringTransformer.Reverse);
            Console.WriteLine("\n\nReversed:");
            foreach (string w in reversed)
                Console.Write(w + " ");

            List<string> prefixed = StringTransformer.TransformList(words, StringTransformer.AddPrefix);
            Console.WriteLine("\n\nPrefixed:");
            foreach (string w in prefixed)
                Console.Write(w + " ");

            Console.WriteLine("\n\nQ: Benefits of using delegates for string transformations?");
            Console.WriteLine("A: Functional programming style to pass behavior as parameter");
            Console.WriteLine("Highly reusable, extensible without modifying TransformList method");
            Console.WriteLine();
            #endregion

            #region Problem 12 Demo
            Console.WriteLine("P12");
            int x = 10, y = 5;

            int sum = MathOperations.PerformOperation(x, y, MathOperations.Add);
            int diff = MathOperations.PerformOperation(x, y, MathOperations.Subtract);
            int product = MathOperations.PerformOperation(x, y, MathOperations.Multiply);
            int quotient = MathOperations.PerformOperation(x, y, MathOperations.Divide);

            Console.WriteLine(x + " + " + y + " = " + sum);
            Console.WriteLine(x + " - " + y + " = " + diff);
            Console.WriteLine(x + " * " + y + " = " + product);
            Console.WriteLine(x + " / " + y + " = " + quotient);

            Console.WriteLine("\nQ: How do delegates promote code reusability in math operations?");
            Console.WriteLine("A: Single PerformOperation method works for any binary operation.");
            Console.WriteLine("Easy to add new operations without changing core logic.");
            Console.WriteLine();
            #endregion

            #region Problem 13 Demo
            Console.WriteLine("P13");
            List<int> integers = new List<int> { 1, 2, 3, 4, 5 };

            Console.Write("Integers: ");
            foreach (int i in integers)
                Console.Write(i + " ");

            TransformDelegate<int, string> intToString = (n) => n.ToString();
            List<string> strings = GenericTransformer.Transform(integers, intToString);

            Console.Write("\nAs strings: ");
            foreach (string s in strings)
                Console.Write(s + " ");

            Console.WriteLine("\n\nQ: Advantages of generic delegates in transforming data structures?");
            Console.WriteLine("A: Works with any input/output type combination (T to R).");
            Console.WriteLine("Type-safe transformations, so we dont need boxing/unboxing");
            Console.WriteLine();
            #endregion

            #region Problem 14 Demo
            Console.WriteLine("P14");
            List<int> nums14 = new List<int> { 1, 2, 3, 4, 5 };

            Func<int, int> square = (n) => n * n; 

            List<int> squares = new List<int>();
            foreach (int n in nums14)
                squares.Add(square(n));

            Console.Write("Original: ");
            foreach (int n in nums14)
                Console.Write(n + " ");

            Console.Write("\nSquared:  ");
            foreach (int n in squares)
                Console.Write(n + " ");

            Console.WriteLine("\n\nQ: How does Func simplify delegate creation and usage?");
            Console.WriteLine("A: No need to declare custom delegate types cuz Func is built-in");
            Console.WriteLine("Clear signature (input types -> return type)");
            Console.WriteLine();
            #endregion

            #region Problem 15 Demo 
            Console.WriteLine("P15");
            List<string> messages = new List<string> { "Marie", "and", "CSharp" };

            Action<string> printAction = (s) => Console.WriteLine("* " + s);

            Console.WriteLine("Applying action to each string:");
            foreach (string msg in messages)
                printAction(msg);

            Console.WriteLine("\nQ: Why is Action preferred for operations that don't return values?");
            Console.WriteLine("A: Explicitly shows intent so this operation has side effects with no return");
            Console.WriteLine("prevents confusion about expected return values.");
            Console.WriteLine();
            #endregion

            #region Problem 16 Demo
            Console.WriteLine("P16");
            List<int> allNumbers = new List<int> { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };

            Predicate<int> isEven = (n) => n % 2 == 0;

            List<int> evens = new List<int>();
            foreach (int n in allNumbers)
                if (isEven(n))
                    evens.Add(n);

            Console.Write("All numbers: ");
            foreach (int n in allNumbers)
                Console.Write(n + " ");

            Console.Write("\nEven numbers: ");
            foreach (int n in evens)
                Console.Write(n + " ");

            Console.WriteLine("\n\nQ: What role do predicates play in functional programming?");
            Console.WriteLine("A: predicates represent conditions/filters, it always return bool");
            Console.WriteLine("makes filtering logic reusable and composable, and testable");
            Console.WriteLine();
            #endregion

            #region Problem 17 Demo
            Console.WriteLine("P17");
            List<string> allWords = new List<string> { "apple", "banana", "avocado", "cherry", "apricot" };

            Func<string, bool> startsWithA = delegate (string s) { return s.StartsWith("a"); };

            List<string> filtered = new List<string>();
            foreach (string w in allWords)
                if (startsWithA(w))
                    filtered.Add(w);

            Console.Write("All words: ");
            foreach (string w in allWords)
                Console.Write(w + " ");

            Console.Write("\nStarts with 'a': ");
            foreach (string w in filtered)
                Console.Write(w + " ");

            Console.WriteLine("\n\nQ: How do anonymous functions improve code modularity?");
            Console.WriteLine("A: define behavior inline where it's used, no need for separate methods.");
            Console.WriteLine("easy to customize conditions per use case without polluting namespace.");
            Console.WriteLine();
            #endregion

            #region Problem 18 Demo
            Console.WriteLine("P18");
            Func<int, int, int> add = delegate (int a, int b) { return a + b; };
            Func<int, int, int> subtract = delegate (int a, int b) { return a - b; };
            Func<int, int, int> multiply = delegate (int a, int b) { return a * b; };

            Console.WriteLine("10 + 5 = " + add(10, 5));
            Console.WriteLine("10 - 5 = " + subtract(10, 5));
            Console.WriteLine("10 * 5 = " + multiply(10, 5));

            Console.WriteLine("\nQ: When prefer anonymous functions over named methods?");
            Console.WriteLine("A: When the logic is simple, used only once, and doesnt need a name");
            Console.WriteLine("Named methods are better for complex logic or when reused multiple times.");
            Console.WriteLine();
            #endregion

            #region Problem 19 Demo
            Console.WriteLine("P19");
            List<string> words19 = new List<string> { "hi", "hello", "hey", "welcome" };

            Func<string, bool> lengthGreaterThan3 = (s) => s.Length > 3;

            List<string> longWords = new List<string>();
            foreach (string w in words19)
                if (lengthGreaterThan3(w))
                    longWords.Add(w);

            Console.Write("All words: ");
            foreach (string w in words19)
                Console.Write(w + " ");

            Console.Write("\nLength > 3: ");
            foreach (string w in longWords)
                Console.Write(w + " ");

            // Contains 'e'
            Func<string, bool> containsE = (s) => s.Contains("e");
            List<string> withE = new List<string>();
            foreach (string w in words19)
                if (containsE(w))
                    withE.Add(w);

            Console.Write("\nContains 'e': ");
            foreach (string w in withE)
                Console.Write(w + " ");

            Console.WriteLine("\n\nQ: What makes lambda expressions essential in modern C#?");
            Console.WriteLine("A: Concise, readable, supports LINQ, async/await, functional patterns");
            Console.WriteLine("Its industry standard for delegates and expression trees");
            Console.WriteLine();
            #endregion

            #region Problem 20 Demo
            Console.WriteLine("P20");
            Func<double, double, double> divide = (a, b) => b != 0 ? a / b : 0;
            Func<double, double, double> power = (a, b) => Math.Pow(a, b);

            Console.WriteLine("10.0 / 2.0 = " + divide(10.0, 2.0));
            Console.WriteLine("2.0 ^ 3.0 = " + power(2.0, 3.0));

            Console.WriteLine("\nQ: How do lambda expressions enhance expressiveness of math computations?");
            Console.WriteLine("A: Read like math formulas, minimal syntax overhead");
            Console.WriteLine("Easy to compose complex operations inline without ceremony.");
            Console.WriteLine();
            #endregion
        }
    }
}