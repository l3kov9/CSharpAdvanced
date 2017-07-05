using System;
using System.Collections.Generic;
using System.Linq;

namespace _10.PopulationCounter
{
    public class PopulationCounter
    {
        public static void Main()
        {
            var input = Console.ReadLine();
            var dictionary=new Dictionary<string,Dictionary<string,int>>();

            while (!input.Equals("report"))
            {
                var tokens = input.Split('|');
                var city = tokens[0];
                var country = tokens[1];
                var population = int.Parse(tokens[2]);

                AddToDictionary(dictionary, country, city, population);

                input = Console.ReadLine();
            }

            foreach (var kvp in dictionary.OrderByDescending(x=>x.Value.Values.Sum()))
            {
                Console.WriteLine($"{kvp.Key} (total population: {kvp.Value.Values.Sum()})");

                foreach (var cityAndPopulation in kvp.Value.OrderByDescending(x=>x.Value))
                {
                    Console.WriteLine($"=>{cityAndPopulation.Key}: {cityAndPopulation.Value}");
                }
            }
        }

        private static void AddToDictionary(Dictionary<string, Dictionary<string, int>> dictionary,
            string country, string city, int population)
        {
            if (!dictionary.ContainsKey(country))
            {
                dictionary[country]=new Dictionary<string, int>();
            }

            if (!dictionary[country].ContainsKey(city))
            {
                dictionary[country][city] = 0;
            }

            dictionary[country][city] += population;
        }
    }
}
