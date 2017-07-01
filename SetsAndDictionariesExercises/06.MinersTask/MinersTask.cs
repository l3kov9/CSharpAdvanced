using System;
using System.Collections.Generic;

namespace _06.MinersTask
{
    public class MinersTask
    {
        public static void Main()
        {
            var resource = Console.ReadLine();
            var minerTask = new Dictionary<string, double>();

            while (!resource.Equals("stop"))
            {
                var quantity = double.Parse(Console.ReadLine());
                if (minerTask.ContainsKey(resource))
                {
                    minerTask[resource] += quantity;
                }
                else
                {
                    minerTask[resource] = quantity;
                }

                resource = Console.ReadLine();
            }

            foreach (var kvp in minerTask)
            {
                Console.WriteLine($"{kvp.Key} -> {kvp.Value}");
            }
        }
    }
}
