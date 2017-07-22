using System;
using System.Numerics;

namespace _08.MultiplyBigNumber
{
    public class BigNumsMultiply
    {
        public static void Main()
        {
            BigInteger firstNum = BigInteger.Parse(Console.ReadLine()) * int.Parse(Console.ReadLine());

            Console.WriteLine(firstNum);
        }
    }
}
