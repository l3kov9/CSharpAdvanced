using System;
using System.Collections.Generic;
using System.Linq;

namespace _08.MapDistricts
{
    public class MapDistricts
    {
        public static void Main()
        {
            var populations = Console.ReadLine()
                .Split(new[] {' '}, StringSplitOptions.RemoveEmptyEntries)
                .ToList();

            var cityPopulation=new Dictionary<string, List<long>>();

            foreach (var item in populations)
            {
                var tokens = item
                    .Split(':')
                    .ToList();
                var city = tokens[0];
                var population = long.Parse(tokens[1]);

                if (!cityPopulation.ContainsKey(city))
                {
                    cityPopulation[city]=new List<long>();
                }

                cityPopulation[city].Add(population);
            }

            var lowerBorder = long.Parse(Console.ReadLine());

            foreach (var cityPop in cityPopulation.Where(x=>x.Value.Sum()>lowerBorder).OrderByDescending(x=>x.Value.Sum()))
            {
                Console.WriteLine($"{cityPop.Key}: {string.Join(" ",cityPop.Value.OrderByDescending(x=>x).Take(5))}");
            }
        }
    }
}
