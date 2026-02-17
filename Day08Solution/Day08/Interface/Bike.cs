using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day08.Interface
{
    internal class Bike : IVehicle
    {
        public string Brand { get; set; }
        public Bike(string brand) 
        { 
            Brand = brand; 
        }

        public void StartEngine()
        { 
            Console.WriteLine(Brand + " bike started"); 
        }
        public void StopEngine()
        { 
            Console.WriteLine(Brand + " bike stopped"); 
        }
    }
}
