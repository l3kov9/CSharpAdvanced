using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;

namespace _04.AcademyGraduation
{
    public class AcademyGraduation
    {
        public static void Main()
        {
            var n = int.Parse(Console.ReadLine());
            var students=new SortedDictionary<string,List<double>>();

            for (int i = 0; i < n; i++)
            {
                var name = Console.ReadLine();

                var grades = Console.ReadLine()
                    .Split(new []{' '},StringSplitOptions.RemoveEmptyEntries)
                    .Select(num => double.Parse(num,CultureInfo.InvariantCulture))
                    .ToList();

                AddToDictionary(students, name, grades);
            }

            foreach (var kvp in students)
            {
                Console.WriteLine($"{kvp.Key} is graduated with {kvp.Value.Average()}");
            }
        }

        private static void AddToDictionary(SortedDictionary<string, List<double>> students, string name, List<double> grades)
        {
            if (!students.ContainsKey(name))
            {
                students[name]=new List<double>();
            }

            students[name].AddRange(grades);
        }
    }
}
