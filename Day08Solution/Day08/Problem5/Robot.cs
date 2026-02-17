using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day08.Problem5
{
    internal class Robot : IWalkable
    {
        // Robot's own Walk method (called on a Robot reference)
        public void Walk()
        {
            Console.WriteLine("Robot walking normally");
        }

        // Explicit implementation (only accessible through IWalkable reference)
        void IWalkable.Walk()
        {
            Console.WriteLine("Robot walking as IWalkable");
        }
    }
}
