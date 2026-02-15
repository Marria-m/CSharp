using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day07
{
    internal interface IMovable
    {
        void Move();
    }

    internal class Car : IMovable
    {
        #region attributes
        private int id; 
        private string brand; 
        private double price; 
        #endregion

        #region Properties
        public int Id
        {
            get { return id; }
            set { id = value; }
        }
        public string Brand
        {
            get { return brand; }
            set { brand = value; }
        }
        public int Price
        {
            get { return price; }
            set { price = value; }
        }
        #endregion

        #region Constructor
        // 1. Default constructor 
        public Car() : this(0, "unknown", 0.0) { }

        // 2. One parameter
        public Car(int _Id) : this(_Id, "unknown", 0.0) { }

        // 3. Two parameters
        public Car(int _Id, string _Brand) : this(_Id, _Brand, 0.0) { }

        // 4. All three parameters
        public Car(int _Id, string _Brand, double _Price)
        {
            id = _Id;
            brand = _Brand;
            price = _Price;
        }


        public Car(string _Brand) : this(0, _Brand, 0.0) {}
        #endregion

        #region Methods
        public override string ToString()
        {
            return $"Id: {Id}, Brand: {Brand}, Price: {Price}";
        }

        // from problem 8
        public void Move()
        {
            Console.WriteLine($"{Brand} is moving");
        }
        #endregion

    }
}
