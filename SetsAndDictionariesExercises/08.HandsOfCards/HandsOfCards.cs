using System;
using System.Collections.Generic;
using System.Linq;

namespace _08.HandsOfCards
{
    public class HandsOfCards
    {
        public static void Main(string[] args)
        {
            var input = Console.ReadLine();
            var playerCards = new Dictionary<string, List<string>>();
            char[] seps = { ' ', ',' };

            while (!input.Equals("JOKER"))
            {
                var command = input.Split(':').ToList();
                var name = command[0];
                var cardList = command[1].Trim().Split(seps, StringSplitOptions.RemoveEmptyEntries).ToList();

                if (playerCards.ContainsKey(name))
                {
                    playerCards[name].AddRange(cardList);
                }
                else
                {
                    playerCards[name] = cardList;
                }

                input = Console.ReadLine();
            }

            foreach (var item in playerCards)
            {
                var cardValues = item.Value.Distinct().ToList();
                var sum = SumAllCards(cardValues);

                Console.WriteLine($"{item.Key}: {sum}");
            }
        }

        private static int SumAllCards(List<string> cardValues)
        {
            var sum = 0;
            foreach (var card in cardValues)
            {
                int rank = GetCardRank(card.Substring(0, card.Length - 1));
                int suite = GetCardSuite(card.Substring(card.Length - 1));
                int result = rank * suite;
                sum += result;
            }
            return sum;
        }

        private static int GetCardSuite(string suite)
        {
            switch (suite)
            {
                case "S": return 4; break;
                case "H": return 3; break;
                case "D": return 2; break;
                case "C": return 1; break;
                default:
                    break;
            }
            return 0;
        }

        private static int GetCardRank(string rank)
        {
            switch (rank)
            {
                case "2": return 2; break;
                case "3": return 3; break;
                case "4": return 4; break;
                case "5": return 5; break;
                case "6": return 6; break;
                case "7": return 7; break;
                case "8": return 8; break;
                case "9": return 9; break;
                case "10": return 10; break;
                case "J": return 11; break;
                case "Q": return 12; break;
                case "K": return 13; break;
                case "A": return 14; break;
                default:
                    break;
            }
            return 0;
        }

    }
}
