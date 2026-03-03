using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using static TaskLINQ02.ListGenerators;

namespace TaskLINQ02
{
    internal class LinqAssignment
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Restriction Operators\n");

            Console.WriteLine("1. Find all products that are out of stock");
            var outOfStock = ListGenerators.ProductList
                .Where(p => p.UnitsInStock == 0);
            foreach (var p in outOfStock)
                Console.WriteLine(p);

            Console.WriteLine("\n2. Find all products that are in stock and cost more than 3.00 per unit");
            var inStockAndExpensive = ListGenerators.ProductList
                .Where(p => p.UnitsInStock > 0 && p.UnitPrice > 3.00M);
            foreach (var p in inStockAndExpensive)
                Console.WriteLine(p);

            Console.WriteLine("\n3. Returns digits whose name is shorter than their value");
            string[] digitsArr = { "zero", "one", "two", "three", "four", "five", "six", "seven", "eight", "nine" };
            var shortNameDigits = digitsArr
                .Where((d, index) => d.Length < index);
            foreach (var d in shortNameDigits)
                Console.WriteLine(d);

            // -----------------------------------------------------------------------

            Console.WriteLine("\nElement Operators\n");

            Console.WriteLine("1. Get first Product out of Stock");
            var firstOutOfStock = ListGenerators.ProductList
                .First(p => p.UnitsInStock == 0);
            Console.WriteLine(firstOutOfStock);

            Console.WriteLine("\n2. Return the first product whose Price > 1000, or null if none.");
            var firstExpensive = ListGenerators.ProductList
                .FirstOrDefault(p => p.UnitPrice > 1000);
            Console.WriteLine(firstExpensive != null ? firstExpensive.ToString() : "null");

            Console.WriteLine("\n3. Retrieve the second number greater than 5");
            int[] numArr = { 5, 4, 1, 3, 9, 8, 6, 7, 2, 0 };
            var secondGreaterThan5 = numArr
                .Where(n => n > 5)
                .Skip(1)
                .First();
            Console.WriteLine(secondGreaterThan5);

            // -----------------------------------------------------------------------

            Console.WriteLine("\nAggregate Operators\n");

            Console.WriteLine("1. Uses Count to get the number of odd numbers in the array");
            int[] aggArr = { 5, 4, 1, 3, 9, 8, 6, 7, 2, 0 };
            int oddCount = aggArr.Count(n => n % 2 != 0);
            Console.WriteLine($"Odd numbers count: {oddCount}");

            Console.WriteLine("\n2. Return a list of customers and how many orders each has");
            var customerOrders = ListGenerators.CustomerList
                .Select(c => new { c.Name, OrderCount = c.Orders.Length });
            foreach (var co in customerOrders)
                Console.WriteLine($"{co.Name}: {co.OrderCount} orders");

            Console.WriteLine("\n3. Return a list of categories and how many products each has");
            var categoryCount = ListGenerators.ProductList
                .GroupBy(p => p.Category)
                .Select(g => new { Category = g.Key, Count = g.Count() });
            foreach (var cc in categoryCount)
                Console.WriteLine($"{cc.Category}: {cc.Count} products");

            Console.WriteLine("\n4. Get the total of the numbers in an array");
            int total = aggArr.Sum();
            Console.WriteLine($"Total: {total}");

            Console.WriteLine("\n5. Get the total number of characters of all words in dictionary_english.txt");
            string path = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "dictionary_english.txt");  // path is .../bin/Debug/net5.0/dictionary_english.txt
            string[] dictWords = File.ReadAllLines(path);
            int totalChars = dictWords.Sum(w => w.Length);
            Console.WriteLine($"Total characters: {totalChars}");

            Console.WriteLine("\n6. Get the total units in stock for each product category");
            var unitsPerCategory = ListGenerators.ProductList
                .GroupBy(p => p.Category)
                .Select(g => new { Category = g.Key, TotalUnits = g.Sum(p => p.UnitsInStock) });
            foreach (var u in unitsPerCategory)
                Console.WriteLine($"{u.Category}: {u.TotalUnits} units");

            Console.WriteLine("\n7. Get the length of the shortest word in dictionary_english.txt");
            int shortestLen = dictWords.Min(w => w.Length);
            Console.WriteLine($"Shortest word length: {shortestLen}");

            Console.WriteLine("\n8. Get the cheapest price among each category's products");
            var cheapestPerCategory = ListGenerators.ProductList
                .GroupBy(p => p.Category)
                .Select(g => new { Category = g.Key, CheapestPrice = g.Min(p => p.UnitPrice) });
            foreach (var c in cheapestPerCategory)
                Console.WriteLine($"{c.Category}: {c.CheapestPrice:C}");

            Console.WriteLine("\n9. Get the products with the cheapest price in each category (Use Let)");
            var cheapestProducts =
                from p in ListGenerators.ProductList
                group p by p.Category into g
                let minPrice = g.Min(p => p.UnitPrice)
                select new
                {
                    Category = g.Key,
                    CheapestProducts = g.Where(p => p.UnitPrice == minPrice)
                };
            foreach (var cp in cheapestProducts)
            {
                Console.WriteLine($"{cp.Category}:");
                foreach (var p in cp.CheapestProducts)
                    Console.WriteLine($"  {p.ProductName} - {p.UnitPrice:C}");
            }

            Console.WriteLine("\n10. Get the length of the longest word in dictionary_english.txt");
            int longestLen = dictWords.Max(w => w.Length);
            Console.WriteLine($"Longest word length: {longestLen}");

            Console.WriteLine("\n11. Get the most expensive price among each category's products");
            var mostExpensivePerCategory = ListGenerators.ProductList
                .GroupBy(p => p.Category)
                .Select(g => new { Category = g.Key, MaxPrice = g.Max(p => p.UnitPrice) });
            foreach (var m in mostExpensivePerCategory)
                Console.WriteLine($"{m.Category}: {m.MaxPrice:C}");

            Console.WriteLine("\n12. Get the products with the most expensive price in each category");
            var mostExpensiveProducts =
                from p in ListGenerators.ProductList
                group p by p.Category into g
                let maxPrice = g.Max(p => p.UnitPrice)
                select new
                {
                    Category = g.Key,
                    MostExpensive = g.Where(p => p.UnitPrice == maxPrice)
                };
            foreach (var mep in mostExpensiveProducts)
            {
                Console.WriteLine($"{mep.Category}:");
                foreach (var p in mep.MostExpensive)
                    Console.WriteLine($"  {p.ProductName} - {p.UnitPrice:C}");
            }

            Console.WriteLine("\n13. Get the average length of the words in dictionary_english.txt");
            double avgLen = dictWords.Average(w => w.Length);
            Console.WriteLine($"Average word length: {avgLen:F2}");

            Console.WriteLine("\n14. Get the average price of each category's products");
            var avgPricePerCategory = ListGenerators.ProductList
                .GroupBy(p => p.Category)
                .Select(g => new { Category = g.Key, AvgPrice = g.Average(p => p.UnitPrice) });
            foreach (var ap in avgPricePerCategory)
                Console.WriteLine($"{ap.Category}: {ap.AvgPrice:C}");

            // -----------------------------------------------------------------------

            Console.WriteLine("\nOrdering Operators\n");

            Console.WriteLine("1. Sort a list of products by name");
            var sortedByName = ListGenerators.ProductList
                .OrderBy(p => p.ProductName);
            foreach (var p in sortedByName)
                Console.WriteLine(p.ProductName);

            Console.WriteLine("\n2. Uses a custom comparer to do a case-insensitive sort of the words in an array");
            string[] wordsArr = { "aPPLE", "AbAcUs", "bRaNcH", "BlUeBeRrY", "ClOvEr", "cHeRry" };
            var caseInsensitiveSorted = wordsArr
                .OrderBy(w => w, StringComparer.OrdinalIgnoreCase);
            foreach (var w in caseInsensitiveSorted)
                Console.WriteLine(w);

            Console.WriteLine("\n3. Sort a list of products by units in stock from highest to lowest");
            var sortedByStock = ListGenerators.ProductList
                .OrderByDescending(p => p.UnitsInStock);
            foreach (var p in sortedByStock)
                Console.WriteLine($"{p.ProductName}: {p.UnitsInStock}");

            Console.WriteLine("\n4. Sort a list of digits, first by length of their name, and then alphabetically by the name itself");
            string[] digits = { "zero", "one", "two", "three", "four", "five", "six", "seven", "eight", "nine" };
            var sortedDigits = digits
                .OrderBy(d => d.Length)
                .ThenBy(d => d);
            foreach (var d in sortedDigits)
                Console.WriteLine(d);

            Console.WriteLine("\n5. Sort first by word length and then by a case-insensitive sort of the words in an array");
            var sortedByLengthThenCI = wordsArr
                .OrderBy(w => w.Length)
                .ThenBy(w => w, StringComparer.OrdinalIgnoreCase);
            foreach (var w in sortedByLengthThenCI)
                Console.WriteLine(w);

            Console.WriteLine("\n6. Sort a list of products, first by category, and then by unit price, from highest to lowest");
            var sortedByCategoryThenPrice = ListGenerators.ProductList
                .OrderBy(p => p.Category)
                .ThenByDescending(p => p.UnitPrice);
            foreach (var p in sortedByCategoryThenPrice)
                Console.WriteLine($"{p.Category}, {p.ProductName}, {p.UnitPrice:C}");

            Console.WriteLine("\n7. Sort first by word length and then by a case-insensitive descending sort of the words in an array");
            var sortedByLengthThenCIDesc = wordsArr
                .OrderBy(w => w.Length)
                .ThenByDescending(w => w, StringComparer.OrdinalIgnoreCase);
            foreach (var w in sortedByLengthThenCIDesc)
                Console.WriteLine(w);

            Console.WriteLine("\n8. Create a list of all digits whose second letter is 'i' that is reversed from the order in the original array");
            string[] digitsArr2 = { "zero", "one", "two", "three", "four", "five", "six", "seven", "eight", "nine" };
            var secondLetterI = digitsArr2
                .Where(d => d.Length >= 2 && d[1] == 'i')
                .Reverse();
            foreach (var d in secondLetterI)
                Console.WriteLine(d);

            // -----------------------------------------------------------------------

            Console.WriteLine("\nTransformation Operators\n");

            Console.WriteLine("1. Return a sequence of just the names of a list of products");
            var productNames = ListGenerators.ProductList
                .Select(p => p.ProductName);
            foreach (var name in productNames)
                Console.WriteLine(name);

            Console.WriteLine("\n2. Produce a sequence of the uppercase and lowercase versions of each word in the original array (Anonymous Types)");
            string[] words2 = { "aPPLE", "BlUeBeRrY", "cHeRry" };
            var upperLower = words2
                .Select(w => new { Upper = w.ToUpper(), Lower = w.ToLower() });
            foreach (var w in upperLower)
                Console.WriteLine($"Upper: {w.Upper}, Lower: {w.Lower}");

            Console.WriteLine("\n3. Produce a sequence containing some properties of Products, including UnitPrice which is renamed to Price");
            var productProjection = ListGenerators.ProductList
                .Select(p => new { p.ProductName, p.Category, Price = p.UnitPrice });
            foreach (var p in productProjection)
                Console.WriteLine($"{p.ProductName}, {p.Category}, {p.Price:C}");

            Console.WriteLine("\n4. Determine if the value of ints in an array match their position in the array");
            int[] posArr = { 5, 4, 1, 3, 9, 8, 6, 7, 2, 0 };
            var inPlace = posArr
                .Select((n, index) => new { Number = n, InPlace = n == index });
            Console.WriteLine("Number: In-place?");
            foreach (var item in inPlace)
                Console.WriteLine($"{item.Number}: {item.InPlace}");

            Console.WriteLine("\n5. Returns all pairs of numbers from both arrays such that the number from numbersA is less than the number from numbersB");
            int[] numbersA = { 0, 2, 4, 5, 6, 8, 9 };
            int[] numbersB = { 1, 3, 5, 7, 8 };
            var pairs = numbersA
                .SelectMany(a => numbersB.Where(b => a < b),
                            (a, b) => new { A = a, B = b });
            Console.WriteLine("Pairs where a < b:");
            foreach (var pair in pairs)
                Console.WriteLine($"{pair.A} is less than {pair.B}");

            Console.WriteLine("\n6. Select all orders where the order total is less than 500.00");
            var cheapOrders = ListGenerators.CustomerList
                .SelectMany(c => c.Orders,
                            (c, o) => new { c.Name, Order = o })
                .Where(co => co.Order.Total < 500.00);
            foreach (var co in cheapOrders)
                Console.WriteLine($"{co.Name}, {co.Order}");

            Console.WriteLine("\n7. Select all orders where the order was made in 1998 or later");
            var recentOrders = ListGenerators.CustomerList
                .SelectMany(c => c.Orders,
                            (c, o) => new { c.Name, Order = o })
                .Where(co => co.Order.OrderDate.Year >= 1998);
            foreach (var co in recentOrders)
                Console.WriteLine($"{co.Name}, {co.Order}");

            // -----------------------------------------------------------------------

            Console.WriteLine("\nPartitioning Operators\n");

            Console.WriteLine("1. Get the first 3 orders from customers in Washington");
            var first3Orders = ListGenerators.CustomerList
                .SelectMany(c => c.Orders)
                .Take(3);
            foreach (var o in first3Orders)
                Console.WriteLine(o);

            Console.WriteLine("\n2. Get all but the first 2 orders from customers in Washington");
            var skipFirst2 = ListGenerators.CustomerList
                .SelectMany(c => c.Orders)
                .Skip(2);
            foreach (var o in skipFirst2)
                Console.WriteLine(o);

            Console.WriteLine("\n3. Return elements starting from the beginning of the array until a number is hit that is less than its position in the array");
            int[] numbers = { 5, 4, 1, 3, 9, 8, 6, 7, 2, 0 };
            var takeWhile = numbers.TakeWhile((n, index) => n >= index);
            foreach (var n in takeWhile)
                Console.WriteLine(n);

            Console.WriteLine("\n4. Get the elements of the array starting from the first element divisible by 3");
            var skipUntilDivisibleBy3 = numbers.SkipWhile(n => n % 3 != 0);
            foreach (var n in skipUntilDivisibleBy3)
                Console.WriteLine(n);

            Console.WriteLine("\n5. Get the elements of the array starting from the first element less than its position");
            var skipWhileGtePosition = numbers.SkipWhile((n, index) => n >= index);
            foreach (var n in skipWhileGtePosition)
                Console.WriteLine(n);

            // -----------------------------------------------------------------------

            Console.WriteLine("\nQuantifiers\n");

            Console.WriteLine("1. Determine if any of the words in dictionary_english.txt contain the substring 'ei'");
            bool hasEi = dictWords.Any(w => w.Contains("ei"));
            Console.WriteLine($"Contains 'ei': {hasEi}");

            Console.WriteLine("\n2. Return a grouped list of products only for categories that have at least one product that is out of stock");
            var categoriesWithOutOfStock = ListGenerators.ProductList
                .GroupBy(p => p.Category)
                .Where(g => g.Any(p => p.UnitsInStock == 0))
                .Select(g => new { Category = g.Key, Products = g.ToList() });
            foreach (var cat in categoriesWithOutOfStock)
            {
                Console.WriteLine($"{cat.Category}:");
                foreach (var p in cat.Products)
                    Console.WriteLine($"  {p.ProductName} (Stock: {p.UnitsInStock})");
            }

            Console.WriteLine("\n3. Return a grouped list of products only for categories that have all of their products in stock");
            var categoriesAllInStock = ListGenerators.ProductList
                .GroupBy(p => p.Category)
                .Where(g => g.All(p => p.UnitsInStock > 0))
                .Select(g => new { Category = g.Key, Products = g.ToList() });
            foreach (var cat in categoriesAllInStock)
            {
                Console.WriteLine($"{cat.Category}:");
                foreach (var p in cat.Products)
                    Console.WriteLine($"  {p.ProductName} (Stock: {p.UnitsInStock})");
            }
        }
    }
}