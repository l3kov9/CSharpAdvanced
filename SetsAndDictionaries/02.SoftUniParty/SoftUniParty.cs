using System;
using System.Collections.Generic;

namespace _02.SoftUniParty
{
    public class SoftUniParty
    {
        public static void Main()
        {
            var guest = Console.ReadLine();
            var guests=new SortedSet<string>();

            while (!guest.Equals("PARTY"))
            {
                guests.Add(guest);

                guest = Console.ReadLine();
            }

            var realGuest = Console.ReadLine();

            while (!realGuest.Equals("END"))
            {
                guests.Remove(realGuest);

                realGuest = Console.ReadLine();
            }

            Console.WriteLine(guests.Count);
            foreach (var person in guests)
            {
                Console.WriteLine(person);
            }
        }
    }
}
