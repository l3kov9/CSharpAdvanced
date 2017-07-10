using System;

namespace Demo
{
    using System.IO;

    public class Demo
    {
        public static void Main()
        {
            //Reading files
            string[] numbers=File.ReadAllLines("../../numbers.txt");
            Console.WriteLine(string.Join("/n",numbers));

            var text = File.ReadAllText("test.txt");
            Console.WriteLine(text);

            //Copy,Move
            File.Copy("test.txt","copiedTest.txt",true);

            //Writing files,WriteAllLines-with array
            File.WriteAllText("writing.txt","testing to write");
            File.WriteAllLines("lines.txt",new string[]
            {
                "1 row",
                "2 row",
                "3 row"
            });

            //Streams

            using (var reader=new StreamReader("numbers.txt"))
            {
                string currentLine = reader.ReadLine();
                Console.WriteLine(currentLine.Length+" symbols: "+currentLine);
            }

            using (var writer = new StreamWriter("writerStream.txt"))
            {
                writer.WriteLine("kanari testing");
            }

            using (var writer=new StreamWriter("checkfile.txt"))
            {
                for (int i = 0; i < 20; i++)
                {
                    writer.WriteLine(Guid.NewGuid().ToString());
                }
            }

            //Directory
            Directory.CreateDirectory("Test");
            Console.WriteLine(Directory.Exists("test"));
            Directory.CreateDirectory("TestDirectories/Ai Kanari/Botev/1912");
            string[] dirs = Directory.GetDirectories("TestDirectories");
            string[] files = Directory.GetFiles("Test");
            foreach (var dir in dirs)
            {
                Console.WriteLine(dir);
            }

            Console.WriteLine(files.Length);

        }
    }
}
