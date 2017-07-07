using System;
using System.Linq;
using System.Runtime.InteropServices;

namespace _04.MaximalSum
{
    public class MaxSum
    {
        public static void Main()
        {
            var numbers = Console.ReadLine().Split().Select(int.Parse).ToArray();
            var rows = numbers[0];
            var cols = numbers[1];
            var matrix = new int[rows][];

            for (int i = 0; i < matrix.Length; i++)
            {
                matrix[i] = Console.ReadLine().Split(new []{' '},StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
            }

            var maxMatrix = new int[3,3];
            var maxSum=int.MinValue;

            for (int i = 0; i < matrix.Length-2; i++)
            {
                for (int j = 0; j < matrix[i].Length-2; j++)
                {
                    int[,] threeMatrix =
                    {
                        {matrix[i][j],matrix[i][j+1],matrix[i][j+2] },
                        {matrix[i+1][j],matrix[i+1][j+1],matrix[i+1][j+2] },
                        {matrix[i+2][j],matrix[i+2][j+1],matrix[i+2][j+2] }
                    };

                    var sum = 0;

                    for (int k = 0; k < threeMatrix.GetLength(0); k++)
                    {
                        for (int l = 0; l < threeMatrix.GetLength(1); l++)
                        {
                            sum += threeMatrix[k,l];
                        }
                    }

                    if (sum > maxSum)
                    {
                        maxSum = sum;
                        maxMatrix = threeMatrix;
                    }
                }

                
            }

            Console.WriteLine($"Sum = {maxSum}");
            for (int i = 0; i < maxMatrix.GetLength(0); i++)
            {
                for (int j = 0; j < maxMatrix.GetLength(1); j++)
                {
                    Console.Write(maxMatrix[i,j]+" ");
                }
                Console.WriteLine();
            }
            
        }
    }
}
