using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day07
{
    internal class Child : Parent
    {
        public int Z { get; set; }

        public Child(int _X,int _Y,int _Z) : base(_X,_Y)
        {
            Z = _Z;
        }

        public override string ToString()
        {
            return $" ({X} ,{Y} ,{Z}) ";
        }

        // for problem 4
        public new int Product()
        {
            return X * Y * Z;
        }

        public override int Sum()
        {
            return X+Y+Z;
        }
    }
}
