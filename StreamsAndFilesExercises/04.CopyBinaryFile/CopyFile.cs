using System.IO;

namespace _04.CopyBinaryFile
{
    public class CopyFile
    {
        public static void Main()
        {
            using (var source = new FileStream("image.jpg",FileMode.Open))
            {
                using (var destination=new FileStream("homer.jpg",FileMode.Create))
                {
                    var buffer = new byte[4096];

                    while (true)
                    {
                        var readBytes = source.Read(buffer, 0, buffer.Length);
                        if (readBytes == 0)
                        {
                            break;
                        }

                        destination.Write(buffer, 0, readBytes);
                    }
                }
            }
        }
    }
}
