using System;
using System.Collections.Generic;
using System.Linq;

namespace _06.TruckTour
{
    public class TruckTour
    {
        public static void Main()
        {
            var watch = System.Diagnostics.Stopwatch.StartNew();

            for (int i = 0; i < 10000000; i++)
            {
             
            }

            watch.Stop();

            Console.WriteLine(watch.Elapsed);
        }
    }
}
