using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;

namespace _05.FilterByAge
{
    public class FilterByAge
    {
        public static void Main()
        {
            var counter = int.Parse(Console.ReadLine());
            var dictionary=new Dictionary<string,int>();

            for (int i = 0; i < counter; i++)
            {
                var tokens = Console.ReadLine().Split(new []{' ',','},StringSplitOptions.RemoveEmptyEntries);
                dictionary[tokens[0]] = int.Parse(tokens[1]);
            }

            var condition = Console.ReadLine();
            var age = int.Parse(Console.ReadLine());
            var format = Console.ReadLine().Split();

            Func<int, bool> tester = CreateTester(condition, age);
            Print(tester,dictionary,format);
        }
        
        private static void Print(Func<int, bool> tester, Dictionary<string, int> dictionary, string[] format)
        {
            foreach (var kvp in dictionary)
            {
                if (tester(kvp.Value))
                {
                    if (format.Length == 2)
                    {
                        Console.WriteLine($"{kvp.Key} - {kvp.Value}");
                    }
                    else if (format[0]=="name")
                    {
                        Console.WriteLine($"{kvp.Key}");
                    }
                    else
                    {
                        Console.WriteLine($"{kvp.Key}");
                    }
                }
            }
        }

        private static Func<int, bool> CreateTester(string condition, int age)
        {
            switch (condition)
            {
                case "younger": return x => x < age;
                case "older": return x => x >= age;
                default: return null;
            }
        }
    }
}
