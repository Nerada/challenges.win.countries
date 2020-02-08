using System;

namespace Challenge1
{
    class Program
    {
        static void Main(string[] args)
        {
            var run = new Runnable();

            Console.WriteLine($"{Environment.NewLine}Amount of regions: {run.Solution(run.CreateData())}");
            Console.ReadKey();

            Environment.Exit(0);
        }
    }
}
