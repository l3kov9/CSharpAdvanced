using System;
using System.Collections.Generic;

namespace _05.Phonebook
{
    public class Phonebook
    {
        public static void Main()
        {
            var input = Console.ReadLine();
            var phoneBook=new Dictionary<string,string>();

            while (!input.Equals("search"))
            {
                var tokens = input.Split('-');
                var name = tokens[0].Trim();
                var phoneNumber = tokens[1].Trim();

                phoneBook[name] = phoneNumber;

                input = Console.ReadLine();
            }

            var searchedContact = Console.ReadLine();

            while (!searchedContact.Equals("stop"))
            {
                if (phoneBook.ContainsKey(searchedContact))
                {
                    Console.WriteLine($"{searchedContact} -> {phoneBook[searchedContact]}");
                }
                else
                {
                    Console.WriteLine($"Contact {searchedContact} does not exist.");
                }

                searchedContact = Console.ReadLine();
            }
        }
    }
}
