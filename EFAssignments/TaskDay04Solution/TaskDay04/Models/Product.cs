using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskDay04.Models
{
    // Many to One with Category, CategoryId is FK
    // Many to Many with Order through OrderDetail
    // Id is a Primary Key + Identity(1,1)
    internal class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }

        // many Products belong to one Category -> FK
        public int CategoryId { get; set; }

        public Category Category { get; set; } // Many-to-One
        public ICollection<OrderDetail> OrderDetails { get; set; } // Many-to-Many bridge
    }
}
