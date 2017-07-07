using System;
using System.Linq;

namespace _02.DiagonalDifference
{
    public class DiagonalDifference
    {
        public static void Main()
        {
            var n = int.Parse(Console.ReadLine());
            var matrix = new int[n][];
            var primaryDiagonal = 0;
            var secondaryDiagonal = 0;


            for (int i = 0; i < matrix.Length; i++)
            {
                matrix[i] = Console.ReadLine().Split().Select(int.Parse).ToArray();
            }

            for (int i = 0; i < matrix.Length; i++)
            {
                primaryDiagonal += matrix[i][i];
                secondaryDiagonal += matrix[i][n-i-1];
            }

            Console.WriteLine(Math.Abs(primaryDiagonal-secondaryDiagonal));
        }
    }
}
