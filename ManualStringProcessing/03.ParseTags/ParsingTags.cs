using System;

namespace _03.ParseTags
{
    public class ParsingTags
    {
        public static void Main()
        {
            var text = Console.ReadLine();
            var openTag = "<upcase>";
            var closeTag = "</upcase>";

            while (text.IndexOf(openTag) != -1 && text.IndexOf(closeTag) != -1 && text.IndexOf(openTag)< text.IndexOf(closeTag))
            {
                var upperText = text.Substring(text.IndexOf(openTag),
                    text.IndexOf(closeTag) + closeTag.Length - text.IndexOf(openTag));

                var newText = upperText.Replace(openTag, String.Empty);
                newText = newText.Replace(closeTag, String.Empty);


                text=text.Replace(upperText, newText.ToUpper());
            }

            Console.WriteLine(text);
        }
    }
}
