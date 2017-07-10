using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace _03.WordCount
{
    public class WordCount
    {
        public static void Main()
        {
            using (var readerWords =new StreamReader("words.txt"))
            {
                using (var readerText=new StreamReader("text.txt"))
                {
                    using (var writer=new StreamWriter("result.txt"))
                    {
                        var words=readerWords.ReadToEnd().Split(new string[] { Environment.NewLine }, StringSplitOptions.RemoveEmptyEntries).ToArray();
                        var dictionary=new Dictionary<string,int>();
                        foreach (var word in words)
                        {
                                dictionary[word] = 0;
                        }

                        var currentLine = readerText.ReadLine();

                        while (currentLine!=null)
                        {
                            var array = currentLine.ToLower().Split(new[] {' ','.','-'}, StringSplitOptions.RemoveEmptyEntries).ToArray();
                            foreach (var word in array)
                            {
                                if (dictionary.ContainsKey(word))
                                {
                                    dictionary[word]++;
                                }
                            }

                            currentLine = readerText.ReadLine();
                        }

                        foreach (var kvp in dictionary.OrderByDescending(x=>x.Value))
                        {
                            writer.WriteLine($"{kvp.Key} - {kvp.Value}");
                        }
                    }
                }
            }
        }
    }
}
