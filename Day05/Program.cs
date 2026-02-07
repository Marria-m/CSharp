using System;

namespace CSharpAssignmentSolution
{
    internal class Program
    {
        static void Main()
        {

            // to test individual problems uncomment the method calls

            // Part 01
            //Problem01_DivisionWithException();
            //Problem02_DefensiveCode();
            //Problem03_NullableTypes();
            //Problem04_ArrayOutOfBounds();
            //Problem05_MultiDimensionalArray();
            //Problem06_JaggedArray();
            //Problem07_NullableReferenceTypes();
            //Problem08_BoxingUnboxing();
            //Problem09_OutParameters();
            //Problem10_OptionalParameters();
            //Problem11_NullPropagation();
            //Problem12_SwitchExpression();
            //Problem13_ParamsKeyword();

            // Part 02
            //Problem14_PrintRange();
            //Problem15_MultiplicationTable();
            //Problem16_EvenNumbers();
            //Problem17_Exponentiation();
            //Problem18_ReverseString();
            //Problem19_ReverseInteger();
            Problem20_LongestDistance();
            //Problem21_ReverseWords();

            Console.ReadKey();
        }

        #region Problem 01: Division with Exception Handling
        // Question: What is the purpose of the finally block?
        // Answer: The finally block executes regardless of whether an exception occurs or not.
        // It's used for cleanup operations like closing files, releasing resources, etc.

        public static void Problem01_DivisionWithException()
        {
            try
            {
                Console.WriteLine("Enter first number:");
                int num1 = int.Parse(Console.ReadLine());

                Console.WriteLine("Enter second number:");
                int num2 = int.Parse(Console.ReadLine());

                int result = num1 / num2;
                Console.WriteLine($"Result: {result}");
            }
            catch (DivideByZeroException ex)
            {
                Console.WriteLine("Cannot divide by zero");
                Console.WriteLine($"Exception Message: {ex.Message}");
            }
            catch (FormatException ex)
            {
                Console.WriteLine("Please enter valid integers");
                Console.WriteLine($"Exception Message: {ex.Message}");
            }
            finally
            {
                Console.WriteLine("Operation complete");
            }
        }
        #endregion

        #region Problem 02: Defensive Code with Validation
        // Question: How does int.TryParse() improve program robustness compared to int.Parse()?
        // Answer: int.TryParse() returns a boolean indicating success/failure without throwing exceptions,
        // making it safer for user input validation. int.Parse() throws FormatException on invalid input.
        // TryParse is better for defensive programming as it handles invalid input gracefully.

        public static void TestDefensiveCode()
        {
            int X, Y, Z;

            do
            {
                Console.WriteLine("Enter first positive Number (X):");
            }
            while (int.TryParse(Console.ReadLine(), out X) || X <= 0);

            // Ensure Y is greater than 1
            do
            {
                Console.WriteLine("Enter Second Number (Y > 1):");
            }
            while (int.TryParse(Console.ReadLine(), out Y) || Y <= 1);

            Z = X / Y;
            Console.WriteLine($"Result: {X} / {Y} = {Z}");
        }

        public static void Problem02_DefensiveCode()
        {
            TestDefensiveCode();
        }
        #endregion

        #region Problem 03: Nullable Types
        // Question: What exception occurs when trying to access Value on a null Nullable<T>?
        // Answer: InvalidOperationException is thrown when accessing Value property of a null Nullable<T>.

        public static void Problem03_NullableTypes()
        {
            // Declare a nullable integer
            int? nullableInt = null;

            Console.WriteLine("Enter a number (or press Enter to skip):");
            string input = Console.ReadLine();

            if (string.IsNullOrEmpty(input) && int.TryParse(input, out int value))
            {
                nullableInt = value;
            }

            // Using null-coalescing operator (??)
            int result = nullableInt ?? 100;
            Console.WriteLine($"Value using ?? operator: {result}");

            Console.WriteLine("\nDemonstrating HasValue and Value");

            if (nullableInt.HasValue)
            {
                Console.WriteLine($"HasValue is true");
                Console.WriteLine($"Value property: {nullableInt.Value}");
            }
            else
            {
                Console.WriteLine($"HasValue is false");
                Console.WriteLine($"Cannot access Value property (would throw InvalidOperationException)");
            }

            // Safe access example
            int safeValue = nullableInt.HasValue ? nullableInt.Value : 0;
            Console.WriteLine($"Safe value access: {safeValue}");
        }
        #endregion

        #region Problem 04: Array Out of Bounds
        // Question: Why is it necessary to check array bounds before accessing elements?
        // Answer: Accessing an array with an invalid index throws IndexOutOfRangeException,
        // which crashes the program if not handled. Checking bounds prevents runtime errors.

        public static void Problem04_ArrayOutOfBounds()
        {
            int[] arr = new int[5];

            Console.WriteLine("Enter 5 numbers:");
            for (int i = 0; i < arr.Length; i++)
            {
                Console.Write($"Element {i}: ");
                arr[i] = int.Parse(Console.ReadLine());
            }

            Console.WriteLine("\nEnter an index to access:");
            int index = int.Parse(Console.ReadLine());

            try
            {
                Console.WriteLine($"Value at index {index}: {arr[index]}");
            }
            catch (IndexOutOfRangeException ex)
            {
                Console.WriteLine($"Index {index} is out of bounds");
                Console.WriteLine($"Valid range is 0 to {arr.Length - 1}");
                Console.WriteLine($"Exception: {ex.Message}");
            }

            // Defensive approach
            Console.WriteLine("\nDefensive Approach");
            if (index >= 0 && index < arr.Length)
            {
                Console.WriteLine($"Value at index {index}: {arr[index]}");
            }
            else
            {
                Console.WriteLine($"Index {index} is out of range");
            }
        }
        #endregion

        #region Problem 05: Multi-Dimensional Array
        // Question: How is the GetLength(dimension) method used in multi-dimensional arrays?
        // Answer: GetLength(0) returns rows count, GetLength(1) returns columns count.
        // It's used to iterate through specific dimensions of the array.

        public static void Problem05_MultiDimensionalArray()
        {
            int[,] arr = new int[3, 3];

            // Input values
            Console.WriteLine("Enter values for a 3x3 array:");
            for (int i = 0; i < arr.GetLength(0); i++)
            {
                for (int j = 0; j < arr.GetLength(1); j++)
                {
                    Console.Write($"Element [{i},{j}]: ");
                    arr[i, j] = int.Parse(Console.ReadLine());
                }
            }

            // Display array
            Console.WriteLine("\nArray:");
            for (int i = 0; i < arr.GetLength(0); i++)
            {
                for (int j = 0; j < arr.GetLength(1); j++)
                {
                    Console.Write($"{arr[i, j]}\t");
                }
                Console.WriteLine();
            }

            // Calculate row sums
            Console.WriteLine("\nRow Sums");
            for (int i = 0; i < arr.GetLength(0); i++)
            {
                int rowSum = 0;
                for (int j = 0; j < arr.GetLength(1); j++)
                {
                    rowSum += arr[i, j];
                }
                Console.WriteLine($"Row {i} sum: {rowSum}");
            }

            // Calculate column sums
            Console.WriteLine("\nColumn Sums");
            for (int j = 0; j < arr.GetLength(1); j++)
            {
                int colSum = 0;
                for (int i = 0; i < arr.GetLength(0); i++)
                {
                    colSum += arr[i, j];
                }
                Console.WriteLine($"Column {j} sum: {colSum}");
            }
        }
        #endregion

        #region Problem 06: Jagged Array
        // Question: How does the memory allocation differ between jagged arrays and rectangular arrays?
        // Answer: Jagged arrays are arrays of arrays - each row can have different length and is stored
        // separately in memory. Rectangular arrays are single blocks with fixed dimensions in contiguous memory.

        public static void Problem06_JaggedArray()
        {
            int[][] jaggedArr = new int[3][];

            Console.WriteLine("Creating jagged array with varying row sizes:");
            Console.WriteLine("Row 0: 2 elements");
            Console.WriteLine("Row 1: 4 elements");
            Console.WriteLine("Row 2: 3 elements\n");

            jaggedArr[0] = new int[2];
            jaggedArr[1] = new int[4];
            jaggedArr[2] = new int[3];

            // Populate each row
            for (int i = 0; i < jaggedArr.Length; i++)
            {
                Console.WriteLine($"\nEnter {jaggedArr[i].Length} values for row {i}:");
                for (int j = 0; j < jaggedArr[i].Length; j++)
                {
                    Console.Write($"Element [{i}][{j}]: ");
                    jaggedArr[i][j] = int.Parse(Console.ReadLine());
                }
            }

            // Print all values
            Console.WriteLine("\nJagged Array Values");
            for (int i = 0; i < jaggedArr.Length; i++)
            {
                Console.Write($"Row {i}: ");
                for (int j = 0; j < jaggedArr[i].Length; j++)
                {
                    Console.Write($"{jaggedArr[i][j]}\t");
                }
                Console.WriteLine();
            }
        }
        #endregion

        #region Problem 07: Nullable Reference Types
        // Question: What is the purpose of nullable reference types in C#?
        // Answer: Nullable reference types help prevent NullReferenceException by providing
        // compiler warnings when null values might be used unsafely. They distinguish between nullable
        // and non-nullable references at compile time. However, this is a compiler feature and doesn't
        // change runtime behavior. In practice, defensive coding with null checks is still essential.

        public static void Problem07_NullableReferenceTypes()
        {
            // Nullable string (can be null)
            string nullableString = null;

            Console.WriteLine("Do you want to enter a name? (yes/no):");
            string input = Console.ReadLine();

            if (input?.ToLower() == "yes")
            {
                Console.WriteLine("Enter your name:");
                nullableString = Console.ReadLine();
            }

            Console.WriteLine("\nSafe Access Patterns");

            // Pattern 1: Null check before access
            if (nullableString is null)
            {
                Console.WriteLine($"Name length (safe): {nullableString.Length}");
                Console.WriteLine($"Name: {nullableString}");
            }
            else
            {
                Console.WriteLine("No name was entered");
            }

            // Pattern 2: Null propagation operator
            int? length = nullableString?.Length;
            Console.WriteLine($"Length using ?. operator: {length ?? -1}");

            // Pattern 3: Null coalescing
            string safeName = nullableString ?? "Anonymous";
            Console.WriteLine($"Name with default: {safeName}");
        }
        #endregion

        #region Problem 08: Boxing and Unboxing
        // Question: What is the performance impact of boxing and unboxing in C#?
        // Answer: Boxing allocates memory on the heap and copies value type data, causing overhead.
        // Unboxing requires type checking and copying. Frequent boxing/unboxing degrades performance
        // and creates garbage collection pressure. Use generics instead when possible.

        public static void Problem08_BoxingUnboxing()
        {
            // Boxing: value type -> reference type (object)
            Console.WriteLine("Boxing Example");
            int valueType = 100;
            Console.WriteLine($"Value type (int): {valueType}");

            object boxedValue = valueType; // Boxing occurs here
            Console.WriteLine($"Boxed to object: {boxedValue}");
            Console.WriteLine($"Boxed value is stored on heap");

            // Unboxing: object -> value type
            Console.WriteLine("\nUnboxing Example");
            try
            {
                int unboxedValue = (int)boxedValue; // Unboxing
                Console.WriteLine($"Unboxed back to int: {unboxedValue}");

                // exception example
                Console.WriteLine("\nInvalid Cast Example");
                object boxedDouble = 3.14;
                Console.WriteLine($"Boxed double: {boxedDouble}");

                // This will throw InvalidCastException
                int invalidUnbox = (int)boxedDouble;
            }
            catch (InvalidCastException ex)
            {
                Console.WriteLine($"Cannot unbox double to int");
                Console.WriteLine($"Exception: {ex.Message}");
            }

            // Correct unboxing
            object boxedDouble2 = 3.14;
            double correctUnbox = (double)boxedDouble2;
            Console.WriteLine($"Correct unboxing: {correctUnbox}");
        }
        #endregion

        #region Problem 09: Out Parameters
        // Question: Why must out parameters be initialized inside the method?
        // Answer: 'out' parameters are treated as uninitialized when passed to the method.
        // The method MUST assign a value before returning, ensuring the caller receives valid data.
        // This is enforced by the compiler.

        public static void SumAndMultiply(int num1, int num2, out int sum, out int product)
        {
            sum = num1 + num2;
            product = num1 * num2;
        }

        public static void Problem09_OutParameters()
        {
            Console.WriteLine("Enter first number:");
            int a = int.Parse(Console.ReadLine());

            Console.WriteLine("Enter second number:");
            int b = int.Parse(Console.ReadLine());

            // out parameters don't need to be initialized before calling
            SumAndMultiply(a, b, out int resultSum, out int resultProduct);

            Console.WriteLine($"\nResults:");
            Console.WriteLine($"Sum: {resultSum}");
            Console.WriteLine($"Product: {resultProduct}");

            SumAndMultiply(a, b, out _, out int prodOnly);
            Console.WriteLine($"\nUsing discard for sum, product only: {prodOnly}");
        }
        #endregion

        #region Problem 10: Optional Parameters
        // Question: Why must optional parameters always appear at the end of a method's parameter list?
        // Answer: This ensures parameters can be passed by position unambiguously. If optional parameters
        // came first, it would be unclear which parameters were being provided when calling the method.

        public static void PrintString(string text, int repeat = 5)
        {
            Console.WriteLine($"\nPrinting '{text}' {repeat} times:");
            for (int i = 0; i < repeat; i++)
            {
                Console.WriteLine($"{i + 1}. {text}");
            }
        }

        public static void Problem10_OptionalParameters()
        {
            Console.WriteLine("Enter a string to print:");
            string input = Console.ReadLine();

            // Using default value (5)
            Console.WriteLine("\nUsing default repeat value");
            PrintString(input);

            // Providing custom value
            Console.WriteLine("\nUsing custom repeat value");
            Console.Write("How many times to repeat? ");
            int times = int.Parse(Console.ReadLine());
            PrintString(input, times);

            // Using named parameters
            Console.WriteLine("\nUsing named parameters");
            PrintString(repeat: 3, text: "Hello");
        }
        #endregion

        #region Problem 11: Null Propagation Operator
        // Question: How does the null propagation operator prevent NullReferenceException?
        // Answer: The ?. operator checks if the object is null before accessing members.
        // If null, it short-circuits and returns null instead of throwing NullReferenceException.

        public static void Problem11_NullPropagation()
        {
            int[] nullableArray = null;

            Console.WriteLine("Without Null Propagation");
            // This would throw NullReferenceException:
            // int length = nullableArray.Length;

            Console.WriteLine("With Null Propagation");
            int? safeLength = nullableArray?.Length;
            Console.WriteLine($"Length using ?. operator: {safeLength ?? -1}");

            Console.WriteLine("\nDo you want to create an array? (yes/no):");
            string response = Console.ReadLine();

            if (response?.ToLower() == "yes")
            {
                Console.Write("Enter array size: ");
                int size = int.Parse(Console.ReadLine());
                nullableArray = new int[size];

                Console.WriteLine($"\nArray created with {nullableArray.Length} elements");
            }

            // Combining null propagation with null coalescing
            int finalLength = nullableArray?.Length ?? 0;
            Console.WriteLine($"Final length (using ?. and ??): {finalLength}");

            // Safe property access
            Console.WriteLine($"Is array null? {nullableArray == null}");
            Console.WriteLine($"Array length (safe): {nullableArray?.Length ?? 0}");
        }
        #endregion

        #region Problem 12: Switch Statement
        // Question: When is a switch expression preferred over a traditional if statement?
        // Answer: Switch statements are preferred when you have multiple discrete cases to check
        // against a single value. They're more readable than long if-else chains and make the
        // code's intent clearer. Switch expressions (C# 8.0+) are even more concise but we use
        // traditional switch here for .NET 5 compatibility.

        public static void Problem12_SwitchExpression()
        {
            Console.WriteLine("Enter a day of the week:");
            string day = Console.ReadLine();

            int dayNumber;

            // Using traditional switch statement
            switch (day?.ToLower())
            {
                case "monday":
                    dayNumber = 1;
                    break;
                case "tuesday":
                    dayNumber = 2;
                    break;
                case "wednesday":
                    dayNumber = 3;
                    break;
                case "thursday":
                    dayNumber = 4;
                    break;
                case "friday":
                    dayNumber = 5;
                    break;
                case "saturday":
                    dayNumber = 6;
                    break;
                case "sunday":
                    dayNumber = 7;
                    break;
                default:
                    dayNumber = 0;
                    break;
            }

            if (dayNumber > 0)
            {
                Console.WriteLine($"{day} is day number {dayNumber}");
            }
            else
            {
                Console.WriteLine("Invalid day entered");
            }

            // Traditional if-else for comparison
            Console.WriteLine("\nTraditional If-Else Equivalent");
            int dayNumberTraditional;
            string dayLower = day?.ToLower();

            if (dayLower == "monday") dayNumberTraditional = 1;
            else if (dayLower == "tuesday") dayNumberTraditional = 2;
            else if (dayLower == "wednesday") dayNumberTraditional = 3;
            else if (dayLower == "thursday") dayNumberTraditional = 4;
            else if (dayLower == "friday") dayNumberTraditional = 5;
            else if (dayLower == "saturday") dayNumberTraditional = 6;
            else if (dayLower == "sunday") dayNumberTraditional = 7;
            else dayNumberTraditional = 0;

            Console.WriteLine($"Traditional approach result: {dayNumberTraditional}");
        }
        #endregion

        #region Problem 13: Params Keyword
        // Question: What are the limitations of the params keyword in method definitions?
        // Answer: Only ONE params parameter is allowed per method, and it MUST be the LAST parameter.
        // The params array cannot be ref or out. It's used for variable-length argument lists.

        public static int SumArray(params int[] numbers)
        {
            int sum = 0;
            for (int i = 0; i < numbers?.Length; i++)
            {
                sum += numbers[i];
            }
            return sum;
        }

        public static void Problem13_ParamsKeyword()
        {
            Console.WriteLine("Calling with individual values");
            int result1 = SumArray(1, 2, 3, 4, 5);
            Console.WriteLine($"Sum of 1, 2, 3, 4, 5 = {result1}");

            Console.WriteLine("\nCalling with an array");
            int[] numbers = { 10, 20, 30, 40 };
            int result2 = SumArray(numbers);
            Console.WriteLine($"Sum of array {{10, 20, 30, 40}} = {result2}");

            Console.WriteLine("\nCalling with no arguments");
            int result3 = SumArray();
            Console.WriteLine($"Sum of no arguments = {result3}");

            Console.WriteLine("\nCalling with mixed values");
            int result4 = SumArray(5, 15, 25);
            Console.WriteLine($"Sum of 5, 15, 25 = {result4}");
        }
        #endregion

        // Part02

        #region Problem 14: Print Numbers in Range
        public static void Problem14_PrintRange()
        {
            Console.WriteLine("Enter a positive integer:");
            int n = int.Parse(Console.ReadLine());

            Console.Write("Output: ");
            for (int i = 1; i <= n; i++)
            {
                Console.Write(i);
                if (i < n)
                    Console.Write(", ");
            }
            Console.WriteLine();
        }
        #endregion

        #region Problem 15: Multiplication Table
        public static void Problem15_MultiplicationTable()
        {
            Console.WriteLine("Enter an integer:");
            int n = int.Parse(Console.ReadLine());

            Console.Write("Output: ");
            for (int i = 1; i <= 12; i++)
            {
                Console.Write(n * i);
                if (i < 12)
                    Console.Write(", ");
            }
            Console.WriteLine();
        }
        #endregion

        #region Problem 16: Even Numbers
        public static void Problem16_EvenNumbers()
        {
            Console.WriteLine("Enter a number:");
            int n = int.Parse(Console.ReadLine());

            Console.Write("Output: ");
            bool first = true;
            for (int i = 2; i <= n; i += 2)
            {
                if (first)
                    Console.Write(", ");
                Console.Write(i);
                first = false;
            }
            Console.WriteLine();
        }
        #endregion

        #region Problem 17: Exponentiation
        public static void Problem17_Exponentiation()
        {
            Console.WriteLine("Enter base number:");
            int baseNum = int.Parse(Console.ReadLine());

            Console.WriteLine("Enter exponent:");
            int exponent = int.Parse(Console.ReadLine());

            int result = 1;
            for (int i = 0; i < exponent; i++)
            {
                result *= baseNum;
            }

            Console.WriteLine($"Output: {result}");
        }
        #endregion

        #region Problem 18: Reverse String
        public static void Problem18_ReverseString()
        {
            Console.WriteLine("Enter a string:");
            string input = Console.ReadLine();

            string reversed = "";
            for (int i = input.Length - 1; i >= 0; i--)
            {
                reversed += input[i];
            }

            Console.WriteLine($"Output: \"{reversed}\"");
        }
        #endregion

        #region Problem 19: Reverse Integer
        public static void Problem19_ReverseInteger()
        {
            Console.WriteLine("Enter an integer:");
            int number = int.Parse(Console.ReadLine());

            int reversed = 0;
            while (number > 0)
            {
                int digit = number % 10;
                reversed = reversed * 10 + digit;
                number /= 10;
            }

            Console.WriteLine($"Output: {reversed}");
        }
        #endregion

        #region Problem 20: Longest Distance Between Matching Elements
        public static void Problem20_LongestDistance()
        {
            Console.WriteLine("Enter array size:");
            int size = int.Parse(Console.ReadLine());

            int[] arr = new int[size];
            Console.WriteLine("Enter array elements:");
            for (int i = 0; i < size; i++)
            {
                Console.Write($"Element {i}: ");
                arr[i] = int.Parse(Console.ReadLine());
            }

            int maxDistance = 0;
            int value1 = 0, value2 = 0;

            // Find longest distance between matching elements
            for (int i = 0; i < arr.Length; i++)
            {
                for (int j = i + 1; j < arr.Length; j++)
                {
                    if (arr[i] == arr[j])
                    {
                        int distance = j - i - 1;
                        if (distance > maxDistance)
                        {
                            maxDistance = distance;
                            value1 = arr[i];
                        }
                    }
                }
            }

            Console.WriteLine($"\nLongest distance: {maxDistance} cells");
            Console.WriteLine($"Between matching elements with value: {value1}");
        }
        #endregion

        #region Problem 21: Reverse Words in Sentence
        public static void Problem21_ReverseWords()
        {
            Console.WriteLine("Enter a sentence:");
            string sentence = Console.ReadLine();

            // Split the sentence into words
            string[] words = sentence.Split(' ');

            // Reverse the array of words
            string[] reversedWords = new string[words.Length];
            for (int i = 0; i < words.Length; i++)
            {
                reversedWords[i] = words[words.Length - 1 - i];
            }

            // Single Console.WriteLine as required
            Console.WriteLine(string.Join(" ", reversedWords));
        }
        #endregion
    }
}