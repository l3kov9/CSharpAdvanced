using System;
using System.Linq;

namespace _03.FirstName
{
    public class FirstName
    {
        public static void Main()
        {
            var names = Console.ReadLine()
                .Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                .ToList();

            var letters = Console.ReadLine()
                .Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                .ToList();

            foreach (var letter in letters.OrderBy(x=>x))
            {
                var searchedName = names.FirstOrDefault(x => x.StartsWith(letter, StringComparison.CurrentCultureIgnoreCase));
                if (searchedName != null)
                {
                    Console.WriteLine(searchedName);
                    return;
                }
            }

            Console.WriteLine("No match");
        }
    }
}
