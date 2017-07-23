using System;
using System.Linq;

namespace _04.AddVAT
{
    public class AddVAT
    {
        public static void Main()
        {
            Func<double, double> addVat = x => x * 20 / 100 + x;

            Console.ReadLine()
                .Split(new[]{' ',','},StringSplitOptions.RemoveEmptyEntries)
                .Select(double.Parse)
                .Select(addVat)
                .ToList()
                .ForEach(x=>Console.WriteLine($"{x:f2}"));
        }
    }
}
