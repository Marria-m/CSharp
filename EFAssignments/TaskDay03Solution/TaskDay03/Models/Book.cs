using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

// Q1: Why did the property "Id" become a Primary Key without any explicit configuration?
/* Answer:
 EF Core follows a naming convention: if a property is named "Id" or "<EntityName>Id"
 (e.g., "BookId"), EF Core automatically treats it as the Primary Key.
 This is called Convention-based Mapping — EF Core scans the class and applies
 default rules without needing any [Key] attribute or Fluent API configuration.
 Since the property is also of type int (a numeric type), EF Core additionally
 configures it as an IDENTITY column (auto-increment) by default. */

// Q2: Why is "Country" nullable in the database while "Price" is not?
/* Answer:
 EF Core maps C# value types (like decimal, int, DateTime) as NOT NULL in the database
 because they cannot hold a null value in C# by default.
 Reference types(like string) are mapped as nullable(NULL) unless explicitly required,
 because in C# a string variable can be null.
 "Price" is a decimal (value type) -> NOT NULL
 "Country" in Author is a string? (nullable reference type, marked with?) -> NULL
 This reflects the direct mapping between C# nullability and database column nullability.*/

namespace TaskDay03.Models
{
    internal class Book
    {
        // "Id" is Primary Key + Identity(1,1) 
        public int Id { get; set; }

        // string -> nvarchar(max) (NULL by default)
        public string Title { get; set; }

        // decimal -> decimal(18,2) (NOT NULL)
        public decimal Price { get; set; }

        // DateTime? nullable value type
        public DateTime? PublishedDate { get; set; }
    }
}
