using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskDay04.Models
{
    // Many to one with Customer (CustomerId is the FK)
    // Many to many with Product (through OrderDetail (junction table)
    // Convention: Id ias Primary Key + Identity(1,1)
    internal class Order
    {
        public int Id { get; set; }
        public DateTime OrderDate { get; set; }

        // FK (many Orders belong to one Customer)
        public int CustomerId { get; set; }

        public Customer Customer { get; set; } // Many to One 
        public ICollection<OrderDetail> OrderDetails { get; set; } // Many to Many bridge
    }
}
