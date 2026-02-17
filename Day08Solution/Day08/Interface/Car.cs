using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day08.Interface
{
    internal class Car : IVehicle
    {
        public string Brand { get; set; }
        public Car(string brand) { 
            Brand = brand; 
        }

        public void StartEngine()
        { 
            Console.WriteLine(Brand + " car started"); 
        }
        public void StopEngine()
        { 
            Console.WriteLine(Brand + " car stopped"); 
        }
    }
}
