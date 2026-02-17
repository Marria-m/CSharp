using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day08.Problem4
{
    internal class Student
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Grade { get; set; }

        public Student(int _Id, string _Name, int _Grade)
        {
            Id = _Id;
            Name = _Name;
            Grade = _Grade;
        }

        // Copy constructor (deep copy)
        public Student(Student other)
        {
            Id = other.Id;
            Name = other.Name;   // this is safe cuz string is immutable
            Grade = other.Grade;
        }

        public override string ToString()
        {
            return $"Id: {Id}, Name: {Name}, Grade: {Grade}";
        }
    }
}
