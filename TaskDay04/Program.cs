using System;
using System.Linq;

namespace ProblemDay04
{
    class Program
    {
        static void Main(string[] args)
        {
            #region Array Initialization in Three Ways
            // Using new int[size]
            int[] grades1 = new int[3];
            grades1[0] = 85;
            grades1[1] = 90;
            grades1[2] = 78;

            Console.WriteLine("Using new int[size]:");
            for (int i = 0; i < grades1.Length; i++)
            {
                Console.WriteLine($"grades1[{i}] = {grades1[i]}");
            }
            Console.WriteLine();

            // Using initializer list
            int[] grades2 = new int[3] { 88, 92, 76 };

            Console.WriteLine("Using initializer list:");
            for (int i = 0; i < grades2.Length; i++)
            {
                Console.WriteLine($"grades2[{i}] = {grades2[i]}");
            }
            Console.WriteLine();

            // Using syntax sugar
            int[] grades3 = { 95, 87, 91 };

            Console.WriteLine("Using syntax sugar:");
            for (int i = 0; i < grades3.Length; i++)
            {
                Console.WriteLine($"grades3[{i}] = {grades3[i]}");
            }
            Console.WriteLine();

            // Demonstrating IndexOutOfRangeException
            Console.WriteLine("try to access index out of range:");
            try
            {
                Console.WriteLine(grades1[5]); // throw exception
            }
            catch (IndexOutOfRangeException ex)
            {
                Console.WriteLine($"Exception caught: {ex.Message}");
            }

            // Question Answer:
            // Default value for int array elements is 0
            // For reference types it would be null
            // For bool it would be false

            #endregion

            #region Shallow Copy vs Deep Copy
            int[] arr1 = { 10, 20, 30 };
            int[] arr2 = { 40, 50, 60 };

            // Shallow Copy
            arr2 = arr1; // Both point to same memory location
            Console.WriteLine(arr1[0]); // 10
            Console.WriteLine(arr2[0]); // 10

            arr1[0] = 999;
            Console.WriteLine(arr2[0]); // 999, arr2 is affected due to shallow copy

            // Deep Copy using Clone()
            int[] arr3 = { 100, 200, 300 };
            int[] arr4 = (int[])arr3.Clone();

            Console.WriteLine(arr3[0]);
            Console.WriteLine(arr4[0]);

            arr3[0] = 888;
            Console.WriteLine(arr3[0]); // 888
            Console.WriteLine(arr4[0]); // 100, arr4 is NOT affected!

            // Question Answer:
            // Array.Clone() creates a shallow copy for 1D arrays of value types
            // Returns object type, needs casting
            // Array.Copy() copies elements from source to destination array
            // More control with start index and length parameters
            // Both create new array objects

            #endregion

            #region 2D Array
            int[,] studentGrades = new int[3, 3]; // 3 students, 3 subjects

            for (int i = 0; i < studentGrades.GetLength(0); i++) // Students
            {
                Console.WriteLine($"\nEnter grades for Student {i + 1}:");
                for (int j = 0; j < studentGrades.GetLength(1); j++) // Subjects
                {
                    // validation to avoid exeptions
                    bool flag;
                    do
                    {
                        Console.Write($"  Subject {j + 1}: ");
                        flag = int.TryParse(Console.ReadLine(), out studentGrades[i, j]);

                        if (!flag || studentGrades[i, j] < 0 || studentGrades[i, j] > 100)
                        {
                            Console.WriteLine("plz enter a grade between 0-100.");
                            flag = false;
                        }
                    }
                    while (!flag);
                }
            }

            Console.Clear();

            // to print grades
            for (int i = 0; i < studentGrades.GetLength(0); i++)
            {
                Console.WriteLine($"Student {i + 1} Grades:");
                for (int j = 0; j < studentGrades.GetLength(1); j++)
                {
                    Console.WriteLine($"Subject {j + 1}: {studentGrades[i, j]}");
                }
                Console.WriteLine();
            }

            // Question Answer:
            // GetLength(dimension) returns the length of specific dimension (0 for rows, 1 for columns)
            // Length returns total number of elements in all dimensions
            // For 3x3 array: GetLength(0)=3, GetLength(1)=3, Length=9
            #endregion

            #region Array Methods Demonstration
            int[] n = { 9, 3, 7, 1, 5, 2, 8, 4, 6 };
            int[] targetArray = new int[5];

            // Sort
            foreach (int i in n)
            {
                Console.WriteLine(i); // 9 3 7 1 5 2 8 4 6
            } 
            Array.Sort(n);
            foreach (int i in n)
            {
                Console.WriteLine(i); // 1 2 3 4 5 6 7 8 9
            }

            // Reverse
            Array.Reverse(n);
            foreach (int i in n)
            {
                Console.WriteLine(i); // 9 8 7 6 5 4 3 2 1
            } 
           
            // IndexOf
            int Index = Array.IndexOf(n, 4);
            Console.WriteLine(Index); // 5
            Console.WriteLine();

            // LastIndexOf
            int Index2 = Array.LastIndexOf(n, 4);
            Console.WriteLine(Index2); 

            // Copy
            Console.WriteLine("5. Array.Copy()");
            int[] arr01 = { 11, 22, 33, 44, 55 };
            int[] arr02 = new int[7];
            Console.WriteLine(arr01[0]);
            Console.WriteLine(arr02[0]);
            Array.Copy(arr01, arr02, 4);
            Console.WriteLine(arr02[0]);

            // Clear
            int[] arr03 = { 100, 200, 300, 400, 500 };
            foreach (int i in arr03)
            {
                Console.Write(i); // 100 200 300 400 500
            }
            Console.WriteLine();
            Array.Clear(arr03, 1, 3); // Clear 3 elements starting from index 1
            foreach (int i in arr03)
            {
                Console.Write(i); // 100 0 0 0 500
            }
            Console.WriteLine();

            // Question Answer:
            // Array.Copy() - More flexible, allows partial copying with start index
            // Array.ConstrainedCopy() - Atomic operation, either all or nothing
            // If any error occurs, ConstrainedCopy leaves destination unchanged
            // Copy may leave destination partially modified on error

            #endregion

            #region Loop Comparison

            Console.WriteLine();

            int[] loop = { 10, 20, 30, 40, 50 };

            // For loop
            Console.WriteLine("1. Using for loop:");
            for (int i = 0; i < loop.Length; i++)
            {
                Console.WriteLine($"loop[{i}] = {loop[i]}");
            }
            Console.WriteLine();

            // Foreach loop
            Console.WriteLine("2. Using foreach loop:");
            foreach (int i in loop)
            {
                Console.WriteLine($"Element: {i}");
            }
            Console.WriteLine();

            // While loop (reverse order)
            Console.WriteLine("3. Using while loop (reverse order):");
            int index = loop.Length - 1;
            while (index >= 0)
            {
                Console.WriteLine($"loop[{index}] = {loop[index]}");
                index--;
            }
            Console.WriteLine();

            // Question Answer:
            // foreach is preferred for read-only operations because:
            // 1. Cleaner syntax: no index management needed
            // 2. no IndexOutOfRange risk
            #endregion

            #region Defensive Coding
            bool validInput;
            int number;

            do
            {
                Console.Write("Enter a positive odd number: ");
                validInput = int.TryParse(Console.ReadLine(), out number);

                if (!validInput)
                {
                    Console.WriteLine("plz enter a valid number");
                }
                else if (number <= 0)
                {
                    Console.WriteLine("the Number must be positive");
                    validInput = false;
                }
                else if (number % 2 == 0)
                {
                    Console.WriteLine("Number must be odd");
                    validInput = false;
                }
            }
            while (!validInput);

            Console.WriteLine($"\ncorrect, You entered: {number}");
            Console.WriteLine();

            // Question Answer:
            // Input validation is important because:
            // 1. Prevents crashes from invalid data
            // 2. Ensures data integrity
            // 3. Improves user experience with clear error messages
            // 4. Protects against malicious input
            // 5. Makes programs more robust and reliable
            #endregion

            #region 2D Array Matrix Format
            int[,] matrix = {
                { 1, 2, 3, 4 },
                { 5, 6, 7, 8 },
                { 9, 10, 11, 12 }
            };

            // to print
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    Console.Write($"{matrix[i, j],4}");
                }
                Console.WriteLine();
            }
            Console.WriteLine();

            // Question Answer:
            // To format 2D array output for better readability:
            // 1. we can use Console.Write with width specifier: {value,width}
            // 2. Add borders and separators
            // 3. Use string.format or interpolation for alignment
            // 4. Add row/column labels
            // 5. Use different symbols for visual separation

            #endregion

            #region if-else vs switch
            Console.Write("Enter month number (1-12): ");
            int monthNum;
            bool validMonth = int.TryParse(Console.ReadLine(), out monthNum);

            if (validMonth && monthNum >= 1 && monthNum <= 12)
            {
                // Using if-else
                string monthName;
                if (monthNum == 1)
                    monthName = "January";
                else if (monthNum == 2)
                    monthName = "February";
                else if (monthNum == 3)
                    monthName = "March";
                else if (monthNum == 4)
                    monthName = "April";
                else if (monthNum == 5)
                    monthName = "May";
                else if (monthNum == 6)
                    monthName = "June";
                else if (monthNum == 7)
                    monthName = "July";
                else if (monthNum == 8)
                    monthName = "August";
                else if (monthNum == 9)
                    monthName = "September";
                else if (monthNum == 10)
                    monthName = "October";
                else if (monthNum == 11)
                    monthName = "November";
                else
                    monthName = "December";

                Console.WriteLine($"Month: {monthName}");

                Console.WriteLine();
                // Using switch
                switch (monthNum)
                {
                    case 1:
                        Console.WriteLine("Month: January");
                        break;
                    case 2:
                        Console.WriteLine("Month: February");
                        break;
                    case 3:
                        Console.WriteLine("Month: March");
                        break;
                    case 4:
                        Console.WriteLine("Month: April");
                        break;
                    case 5:
                        Console.WriteLine("Month: May");
                        break;
                    case 6:
                        Console.WriteLine("Month: June");
                        break;
                    case 7:
                        Console.WriteLine("Month: July");
                        break;
                    case 8:
                        Console.WriteLine("Month: August");
                        break;
                    case 9:
                        Console.WriteLine("Month: September");
                        break;
                    case 10:
                        Console.WriteLine("Month: October");
                        break;
                    case 11:
                        Console.WriteLine("Month: November");
                        break;
                    case 12:
                        Console.WriteLine("Month: December");
                        break;
                }
            }
            else
            {
                Console.WriteLine("please enter 1-12");
            }
            Console.WriteLine();

            // Question Answer:
            // Prefer switch over if else when:
            // 1. Testing single variable against multiple constant values
            // 2. More than 3-4 conditions on same variable
            // 3. Better readability for equality checks
            // 4. Compiler can optimize switch better (jump table)
            // 5. shows mutually exclusive cases

            #endregion

            #region Sort and Search with IndexOf and LastIndexOf
            int[] array01 = { 45, 12, 78, 34, 12, 90, 23, 12, 56 };

            foreach (int item in array01)
            {
                Console.Write($"{item} ");
            }
            Console.WriteLine();

            // Sort the array
            Array.Sort(array01);
            foreach (int item in array01)
            {
                Console.Write($"{item} ");
            }
            Console.WriteLine();

            int searchValue = 12;
            Console.WriteLine($"Searching for: {searchValue}");

            // dfirst occurrence
            int firstIndex = Array.IndexOf(array01, searchValue);
            if (firstIndex != -1)
            {
                Console.WriteLine($"first occurrence at {firstIndex}");
            }
            else
            {
                Console.WriteLine("not found");
            }

            // find last occurrence
            int lastIndexSearch = Array.LastIndexOf(array01, searchValue);
            if (lastIndexSearch != -1)
            {
                Console.WriteLine($"Last occurrence at: {lastIndexSearch}");
            }
            else
            {
                Console.WriteLine("not found");
            }
            Console.WriteLine();

            // Search for value not in array
            int notFound = 100;
            Console.WriteLine($"Searching for value: {notFound}");
            int notFoundIndex = Array.IndexOf(array01, notFound);
            Console.WriteLine($"Result: {(notFoundIndex == -1 ? "Not found" : $"Found at index {notFoundIndex}")}");
            Console.WriteLine();

            // Question Answer:
            // Time complexity of Array.Sort():
            // Average case: O(n log n) - uses QuickSort algorithm
            // Worst case: O(n^2) but its rare, when reverse sorted
            // Best case: O(n log n)
            // Space complexity: O(log n) due to recursion stack
            #endregion

            #region Sum Calclation
            int[] numbers = { 10, 20, 30, 40, 50, 60, 70, 80, 90, 100 };

            // for loop
            int sumFor = 0;
            for (int i = 0; i < numbers.Length; i++)
            {
                sumFor += numbers[i];
            }
            Console.WriteLine($"Sum = {sumFor}");
            Console.WriteLine();

            // foreach loop
            int sumForeach = 0;
            foreach (int num in numbers)
            {
                sumForeach += num;
            }
            Console.WriteLine($"Sum = {sumForeach}");
            Console.WriteLine();

            // Question Answer:
            // For simple sum calculation, foreach is generally better because:
            // 1. Cleaner and more readable code
            // 2. No risk of index errors
            // 3. Shows intent clearly (we're reading all elements)
            // 4. Modern compilers optimize both similarly
            // 
            // from performance-wise:
            // - For arrays of value types, performance is nearly identical
            // - For loop has slight edge in some cases (direct memory access)
            // - foreach has overhead of GetEnumerator() but negligible for arrays
            // - Difference is so small that code readability should be the deciding factor

            #endregion

        }
    }
}