using System;
using System.Collections.Generic;

namespace _01.UniqueUsernames
{
    public class UniqueUsernames
    {
        public static void Main()
        {
            var n = int.Parse(Console.ReadLine());
            var set = new HashSet<string>();

            for (int i = 0; i < n; i++)
            {
                var user = Console.ReadLine();

                set.Add(user);
            }

            foreach (var userName in set)
            {
                Console.WriteLine(userName);
            }       
        }
    }
}
