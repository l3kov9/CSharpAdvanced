using System;

namespace _02.StringLength
{
    public class StringLength
    {
        public static void Main()
        {
            Console.WriteLine(Console.ReadLine().PadRight(20, '*').Substring(0, 20));
        }
    }
}
