using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace _01.OddLines
{
    public class OddLines
    {
        public static void Main()
        {
            Directory.CreateDirectory("Odd Line Directory");

            using (var writer=new StreamWriter("Odd Line Directory/oddLineFile.txt"))
            {
                for (int i = 0; i < 10; i++)
                {
                    writer.WriteLine(Guid.NewGuid().ToString());
                }
            }

            using (var reader=new StreamReader("Odd Line Directory /oddLineFile.txt"))
            {
                string line = reader.ReadLine();
                var row = 0;

                while (line!=null)
                {
                    if (row % 2 == 1)
                    {
                        Console.WriteLine($"Row {row}: {line}");
                    }
                    line = reader.ReadLine();
                    row++;
                }
            }
        }
    }
}
