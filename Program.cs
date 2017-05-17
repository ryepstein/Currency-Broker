using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment3
{
    public class Program
    {
        public static String rateSymbol = "";
        public static float targetRate = 0.0f;

        static void Main(string[] args)
        {
            Scheduler scheduler = new Scheduler();  // Initialize Scheduler

            Console.Write("Enter a pair: ");
            rateSymbol = Console.ReadLine();
            Console.WriteLine();
            while (targetRate <= 0.0f)
            {
                Console.Write("Enter a target rate: ");
                targetRate = float.Parse(Console.ReadLine());
                if (targetRate <= 0.0f)
                {
                    Console.WriteLine("Invalid target rate: Must be greater than 0");
                }
            }

            do
            {
                while (!Console.KeyAvailable)   // Loop if key is not pressed
                {
                    scheduler.OnTimerTick();    // Run scheduler
                }
            } while (Console.ReadKey(true).Key != ConsoleKey.Escape);   // Exit loop if Escape key is pressed
        }
    }
}
