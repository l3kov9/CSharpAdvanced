using System;
using System.IO;

namespace _02.LineNumbers
{
    public class LineNumbers
    {
        public static void Main()
        {
            using (var writer = new StreamWriter("testfile.txt"))
            {
                for (int i = 0; i < 20; i++)
                {
                    writer.WriteLine(Guid.NewGuid().ToString());
                }
            }

            using (var reader = new StreamReader("testfile.txt"))
            {
                using (var write = new StreamWriter("modifiedtestfile.txt"))
                {
                    var currentLine = reader.ReadLine();
                    var row = 0;

                    while (currentLine!=null)
                    {
                        var line = $"{row}: {currentLine}";
                        row++;

                        write.WriteLine(line);

                        currentLine = reader.ReadLine();
                    }
                }
            }
        }
    }
}
