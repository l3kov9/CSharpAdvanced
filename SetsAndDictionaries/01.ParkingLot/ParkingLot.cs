using System;
using System.Collections.Generic;

namespace _01.ParkingLot
{
    public class ParkingLot
    {
        public static void Main()
        {
            var input = Console.ReadLine();
            var parking=new SortedSet<string>();

            while (!input.Equals("END"))
            {
                var commands = input.Split(',');
                var direction = commands[0].Trim();
                var carNumber = commands[1].Trim();

                if (direction.Equals("IN"))
                {
                    parking.Add(carNumber);
                }
                else
                {
                    parking.Remove(carNumber);
                }

                input = Console.ReadLine();
            }

            Console.WriteLine(parking.Count>0 ? string.Join("\n",parking) : "Parking Lot is Empty");
        }
    }
}
