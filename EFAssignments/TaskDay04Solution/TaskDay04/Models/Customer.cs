using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskDay04.Models
{
    // one Customer has Many Orders
    internal class Customer
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }

        // One-to-Many
        public ICollection<Order> Orders { get; set; }
    }
}
