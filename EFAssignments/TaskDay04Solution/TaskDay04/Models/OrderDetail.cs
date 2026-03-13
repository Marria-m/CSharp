using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskDay04.Models
{
    // Many to Many between Order and Product
    // Composite Primary Key (OrderId + ProductId) -> Fluent API
    // Quantity carries additional data on the relationship
    internal class OrderDetail
    {
        // FK to Order (Composite part 1)
        public int OrderId { get; set; }

        // FK to Product (Composite part 2)
        public int ProductId { get; set; }

        public int Quantity { get; set; }

        public Order Order { get; set; }
        public Product Product { get; set; }
    }
}
