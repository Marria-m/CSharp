using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day08.Problem7
{
    internal interface ILogger
    {
        void Log(string message);
    }

    // Abstract base
    internal abstract class LoggerBase : ILogger
    {
        public virtual void Log(string message)
        {
            Console.WriteLine("default log " + message);
        }
    }

    // ConsoleLogger overrides the default
    internal class ConsoleLogger : LoggerBase
    {
        public override void Log(string message)
        {
            Console.WriteLine("Consol " + DateTime.Now.ToShortTimeString() + " > " + message);
        }
    }

    // no override needed
    internal class SilentLogger : LoggerBase { }
}
