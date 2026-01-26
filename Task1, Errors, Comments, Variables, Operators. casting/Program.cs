using System;

namespace CsharpDay02Giza01
{
    class Program
    {
        static void Main()
        {
            #region Problem 1 (Comments)
            // declare integer variable x
            int x = 10;

            // declare integer variable y
            int y = 20;

            /*
             calculate the sum of x and y
             and put it in sum
            */
            int sum = x + y;

            // print the result
            Console.WriteLine(sum);
            #endregion


            #region Question 1 (Comment shortcut)
            // Comment   : ctrl + k , c
            // Uncomment : ctrl + k , u
            #endregion


            #region Problem 2 (Fix Errors)
            int x1 = 10;  // without qoutation marks because its an integer
            int y1 = 5;
            Console.WriteLine(x1 + y1);
            #endregion

            #region Question 2 (Runtime vs Logical)
            // Runtime error: happens during execution (like division by zero)
            int a = 10;
            int b = 0;
            // Console.WriteLine(a / b); // this line will cause runtime error

            // Logical error: program runs but gives incorrect result due to wrong logic (like using - instead of +)
            int c = 10;
            int d = 5;
            Console.WriteLine(c - d); // should be c + d for sum
            #endregion


            #region Problem 3 (Variables with maming conventions)
            string fullName = "Mariam Ehab";
            int age = 19;
            decimal monthlySalary = 6000.00m;
            bool isStudent = true;
            #endregion


            #region Question 3 (Naming Conventions)
            /*
             naming conventions improve readability and maintainability 
             when working in teams or large projects
             */
            #endregion


            #region Problem 4 (Ref Type Behavior)
            Point p1 = new Point();
            p1.x = 5;

            Point p2 = p1;
            p2.x = 10;

            Console.WriteLine(p1.x); // the output is 10 because p1 and p2 reference to x (the same object in heap)
            #endregion


            #region Question 4 (Value vs Ref. Types)
            /* value types are stored in stack and hold actual values so 
             changing one does not affect the other

             reference types are stored in heap and variables hold references 
             and point to the same object so changing one affects the other
            */
            #endregion


            #region Problem 5 (Calculations)
            int x2 = 15;
            int y2 = 4;

            Console.WriteLine(x2 + y2); // Sum
            Console.WriteLine(x2 - y2); // Difference
            Console.WriteLine(x2 * y2); // Product
            Console.WriteLine(x2 / y2); // Division
            Console.WriteLine(x2 % y2); // Remainder
            #endregion


            #region Question 5 (Modulus Output)
            // int a = 2, b = 7;
            // a % b = 2 because a is smaller than b and we cannot divide it even once so the remainder is a itself
            #endregion


            #region Problem 6 (AND Condition)
            int num = 12;

            if (num > 10 && num % 2 == 0)
                Console.WriteLine("Valid");
            else
                Console.WriteLine("Invalid");
            #endregion


            #region Question 6 (&& and &)
            /* && is logical AND with short circuit so its for boolean 
               expressions and stops evaluating if first is false
             */
            /* & is bitwise AND and evaluates both sides so used for 
               bitwise operations and boolean expressions without short circuit
             */
            // -------------------------------------------------------------------------------------
            #endregion


            #region Problem 7 (casting)
            double x3 = 13.5;
            int explicitResult;
            checked  // if overflow then throw exception
            {
                explicitResult = (int)x3;
            }
            double implicitResult = explicitResult;  // no need for checked block here

            Console.WriteLine(explicitResult);
            
            Console.WriteLine(implicitResult);
            #endregion


            #region Question 7 (explicit Casting)
            // explicit casting is required because converting double to int may cause data loss
            #endregion


            #region Problem 8 (Parse and Validate)
            Console.WriteLine("enter your age:");
            int age2 = int.Parse(Console.ReadLine());
            if (age2 > 0)
                Console.WriteLine("valid");
            else
                Console.WriteLine("invalid");
            #endregion


            #region Question 8 (Exception handling)
            // potential exception
            // Can be handled using the checked block or using try catch 
            #endregion


            #region Problem 9 (Prefix and Postfix)
            int x4 = 1;

            Console.WriteLine(++x4);  // output 2, x4 = 2
            Console.WriteLine(x4++);  // output 2, x4 = 3
            Console.WriteLine(x4++);  // output 3, x4 = 4
            #endregion


            #region Question 9 (explanation of Prefix and Postfix)
            /* 
             int x = 5; 
             int y = ++x + x++; 
             
             the value of x after the excution = 7
             the value of y after the excution = 12 
             because ++x makes x = 6, then x++ makes x = 7 after this step
             so y = 6 + 6 = 12, and x = 7
             */
            #endregion
        }
    }

    #region Point Class
    class Point
    {
        public int x;
        public int y;
    }
    #endregion
}
