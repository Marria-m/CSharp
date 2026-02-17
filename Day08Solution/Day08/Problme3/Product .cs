using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day08.Problme3
{
    internal class Product : IComparable
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public double Price { get; set; }

        public Product(int _Id, string _Name, double _Price)
        {
            Id = _Id;
            Name = _Name;
            Price = _Price;
        }

        public int CompareTo(object obj)
        {
            Product PessedPd = (Product)obj;
            if (Price > PessedPd.Price)
            {
                return 1;
            }
            else if (Price < PessedPd.Price)
            {
                return -1;
            }
            else
            {
                return 0;
            }
        }

        override public string ToString()
        {
            return $"Id: {Id}, Name: {Name}, Price: {Price}";
        }
    }
}
