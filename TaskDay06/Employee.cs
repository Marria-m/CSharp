using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day06
{
    internal class Employee
    {
        private int EmpId;
        private string Name;
        private decimal EmpSalary;

        public string GetName() 
        { 
            return Name;
        }

        public void SetName(string name) 
        {
            Name = name.Length < 10 ? name : name.Substring(0, 10);
        }
        public decimal Salary
        {
            get { return EmpSalary; }
            set { EmpSalary = value < 40000 ? 40000 : value; } 
        }

        public Employee(int _Id, string _Name, decimal _Salary)
        {
            EmpId = _Id;
            Name = _Name;
            EmpSalary = _Salary;
        }

        public Employee()  // if I didnt put this using it in main causes an error because it requirs parameters!!!!!
        {
        }

        public override string ToString()
        {
            return $"EmpId is {EmpId}, and their Name is {Name} with Salary {EmpSalary}";
        }

    }
}
