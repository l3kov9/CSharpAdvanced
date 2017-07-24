using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace _10.PredicateParty
{
    public class Party
    {
        public static void Main()
        {
            var names = Console.ReadLine()
                .Split(new[] {' '}, StringSplitOptions.RemoveEmptyEntries)
                .ToList();

            var command = Console.ReadLine();

            Func<List<string>, string, string, string, List<string>> partyUpdate 
                = (nameList, action, criteria, letter) =>
                {
                    var list = nameList;

                if (action == "Remove")
                {
                    switch (criteria)
                    {
                        case "StartsWith":
                            nameList.RemoveAll(x => x.StartsWith(letter));
                            break;
                        case "EndsWith":
                            nameList.RemoveAll(x => x.EndsWith(letter));
                            break;
                        case "Length":
                            nameList.RemoveAll(x => x.Length == int.Parse(letter));
                            break;
                    }
                }
                if (action == "Double")
                {
                    switch (criteria)
                    {
                        case "StartsWith": nameList.AddRange(list.Where(x => x.StartsWith(letter)).ToList());
                            break;
                        case "EndsWith": nameList.AddRange(list.Where(x => x.EndsWith(letter)).ToList());
                            break;
                        case "Length": nameList.AddRange(list.Where(x=>x.Length == int.Parse(letter)).ToList());
                            break;
                    }
                }

                return nameList;
            };

            while (command != "Party!")
            {
                var tokens = command.Split();

                var action = tokens[0];
                var criteria = tokens[1];
                var letter = tokens[2];

                partyUpdate(names, action, criteria, letter);

                command = Console.ReadLine();
            }
            Console.WriteLine(names.Count > 0
                ? $"{string.Join(", ", names)} are going to the party!"
                : "Nobody is going to the party!");
        }
    }
}
