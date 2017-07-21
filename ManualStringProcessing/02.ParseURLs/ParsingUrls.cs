using System;
using System.Linq;

namespace _02.ParseURLs
{
    public class ParsingUrls
    {
        public static void Main()
        {
            var address = Console.ReadLine();
            var pattern = "://";
            var tokens = address.Split(new[] {pattern}, StringSplitOptions.RemoveEmptyEntries);

            if(tokens.Length!=2 || tokens[1].IndexOf("/") == -1)
            {
                Console.WriteLine("Invalid URL");
                return;
            }

            var protocol = tokens[0];
            var server = tokens[1].Substring(0, tokens[1].IndexOf("/"));
            var resources = tokens[1].Substring(tokens[1].IndexOf("/") + 1);

            Console.WriteLine($"Protocol = {protocol}");
            Console.WriteLine($"Server = {server}");
            Console.WriteLine($"Resources = {resources}");
        }
    }
}
