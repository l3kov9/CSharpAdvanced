using System;

namespace Demo
{
    public class Demo
    {
        public static void Main()
        {
            try
            {
                Console.Write("Enter first number: ");
                var firstNumber = int.Parse(Console.ReadLine());

                Console.Write("Enter second number: ");
                var secondNumber = int.Parse(Console.ReadLine());

                Console.WriteLine(SumPositiveNumbers(firstNumber, secondNumber));
            }
            catch (Exception e)
            {
                Console.WriteLine("Invalid numbers. Numbers cannot be less than zero.");
            }
            finally
            {
                Console.WriteLine("bye");
            }
        }

        public static int SumPositiveNumbers(int a, int b)
        {
            if (a < 0 || b < 0)
            {
                throw new ArgumentException("Numbers cannot be less than zero.");
            }

                return a + b;
        }
    }
}
