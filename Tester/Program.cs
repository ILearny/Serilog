using Logger;
using System;

namespace Tester
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            var logger = new SerilogAdapter();
            logger.LogMessage("Logging message");

            Console.ReadLine();
        }
    }
}
