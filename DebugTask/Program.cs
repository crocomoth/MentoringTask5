using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DebugTask
{
    class Program
    {
        static void Main(string[] args)
        {
            var generator = new Generator();
            var key = generator.Generate();
            Console.WriteLine(key);
            Console.Read();
        }
    }
}
