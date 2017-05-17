using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace Assignment3
{
    public class Scheduler
    {
        public int timeDelay = 60000;    // Time delay in milliseconds
        public bool rateMet = false;    // Was the target rate met on the last check?

        private TradeBroker tradeBroker = new TradeBroker();

        public void OnTimerTick()
        {
            float currentRate = tradeBroker.ReadXML();  // Read currentRate from XML
            while (currentRate == 0)    // Checks if user-defined pair is valid
            {
                Console.WriteLine("Invalid Pair");
                Console.Write("Enter a valid pair: ");
                Program.rateSymbol = Console.ReadLine();    // Get new pair from user
                currentRate = tradeBroker.ReadXML();
            }
            if (currentRate >= Program.targetRate && rateMet == false)  // Checks if target rate has been reached
            {
                Console.WriteLine("Target has been reached!");
                rateMet = true;
            }
            if (currentRate < Program.targetRate && rateMet == true)    // Checks if rate has dropped below target rate
            {
                rateMet = false;
            }
            Thread.Sleep(timeDelay);    // Sleep for time delay
        }
    }
}
