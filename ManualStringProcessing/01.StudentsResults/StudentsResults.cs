using System;
using System.Collections.Generic;
using System.Linq;

namespace _01.StudentsResults
{
    public class StudentsResults
    {
        public static void Main()
        {
            var n = int.Parse(Console.ReadLine());
            var dictionary=new Dictionary<string, List<double>>();

            for (int i = 0; i < n; i++)
            {
                var input = Console.ReadLine();
                var tokens = input.Split(new[] {',', '-', ' '}, StringSplitOptions.RemoveEmptyEntries);
                var name = tokens[0];

                dictionary[name]=new List<double>();
                dictionary[name].Add(double.Parse(tokens[1]));
                dictionary[name].Add(double.Parse(tokens[2]));
                dictionary[name].Add(double.Parse(tokens[3]));
            }

            Console.WriteLine(string.Format($"{"Name",-10}|{"CAdv",7}|{"COOP",7}|{"AdvOOP",7}|{"Average",7}"));

            foreach (var kvp in dictionary)
            {
                Console.WriteLine(string.Format($"{kvp.Key,-10}|{dictionary[kvp.Key][0],7:f2}|{dictionary[kvp.Key][1],7:f2}|{dictionary[kvp.Key][2],7:f2}|{dictionary[kvp.Key].Average(),7:f2}"));
            }
        }
    }
}
