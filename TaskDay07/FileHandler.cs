using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day07
{
    internal interface IReadable { 
        void Read(); 
    }
    internal interface IWritable { 
        void Write(); 
    }

    internal class FileHandler : IReadable, IWritable
    {
        public string FileName { get; set; }
        public FileHandler(string fileName) 
        { 
            FileName = fileName; 
        }

        public void Read()
        {
            Console.WriteLine($"Reading from {FileName}");
        }
        public void Write()
        {
            Console.WriteLine($"Writing to {FileName}");
        }
    }
}
