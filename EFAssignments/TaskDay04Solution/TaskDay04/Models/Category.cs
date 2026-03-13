using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskDay04.Models
{
    internal class Category
    {
        public int Id { get; set; }
        public string Name { get; set; }

        // One to Many (the One side)
        // uses this to build the fk relationship on the Product table
        public ICollection<Product> Products { get; set; }
    }
}
