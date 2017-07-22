using System;

namespace _03.FormattingNumbers
{
    public class FormatNumbers
    {
        public static void Main()
        {
            var numbers = Console.ReadLine().Split(new []{' '},StringSplitOptions.RemoveEmptyEntries);
            var firstNum = int.Parse(numbers[0]);
            var secondNum = double.Parse(numbers[1]);
            var thirdNum = double.Parse(numbers[2]);

            Console.WriteLine($"|{firstNum,-10:X}|{Convert.ToString(firstNum,2).PadLeft(10,'0')}|{secondNum,10:f2}|{thirdNum,-10:f3}|");
        }
    }
}
