using System;

namespace _04.PascalTriangle
{
    public class PascalTriangle
    {
        public static void Main()
        {
            var rows = int.Parse(Console.ReadLine());
            var pascal = new int[rows][];
            var cols = 2;
            pascal[0] = new int[1];
            pascal[0][0] = 1;
           
            for (int i = 1; i < pascal.Length; i++)
            {
                pascal[i] = new int[cols];
                pascal[i][0] = 1;
                pascal[i][cols - 1] = 1;

                if (pascal[i - 1].Length > 1)
                {
                    for (int j = 1; j < cols - 1; j++)
                    {
                        pascal[i][j] = pascal[i - 1][j - 1] + pascal[i - 1][j];
                    }
                }
  
                cols ++;
            }

            for (int i = 0; i < pascal.Length; i++)
            {
                Console.WriteLine(string.Join(" ",pascal[i]));
            }
        }
    }
}
