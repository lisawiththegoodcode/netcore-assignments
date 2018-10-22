using System;

namespace Lesson3Prework1
{
    class Program
    {
        static void Main(string[] args)
        {
            System.Console.WriteLine("Starting");
            System.Threading.Tasks.Task.Run(() =>
            {
                System.Console.WriteLine("Hello World!");
                System.Threading.Tasks.Task.Delay(2000).Wait();
                System.Console.WriteLine("Hello Again!");
            });
            System.Console.WriteLine("Ending");
            System.Console.ReadKey();

        }
    }
}
