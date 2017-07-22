using System;

namespace _15.MelrahShake
{
    public class MelrahShake
    {
        public static void Main()
        {
            var text = Console.ReadLine();
            var pattern = Console.ReadLine();

            while (true)
            {
                var firstMatch = text.IndexOf(pattern);
                var lastMatch = text.LastIndexOf(pattern);

                if (firstMatch == lastMatch || firstMatch==-1)
                {
                    Console.WriteLine("No shake.");
                    break;
                }

                Console.WriteLine("Shaked it.");

                text=text.Remove(lastMatch,pattern.Length);
                text=text.Remove(firstMatch, pattern.Length);

                if (pattern.Length > 1)
                {
                    pattern = pattern.Remove(pattern.Length / 2, 1);
                }
                else
                {
                    break;
                }
            }

            Console.WriteLine(text);

        }
    }
}
