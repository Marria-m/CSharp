using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day06
{
    internal struct Point
    {
        public int x;
        public int y;

        // for problem 1

        // default ctor
        // this is not allowed in structs
        //public Point()
        //{
        //    x = 0;
        //    y = 0;
        //}

        // for problem 1 and 4
        public Point(int x, int y)
        {
            this.x = x;
            this.y = y;
        }

        // for problem 4
        public Point(int x)
        {
            this.x = x;
            y = 0;
        }

        // for problem 1 and 5
        public override string ToString()
        {
            return $"({x}, {y})";
        }

    }
}
