using System;
using System.IO;

namespace CopyBinaryFile
{
    class Program
    {
        static void Main(string[] args)
        {
            string path = Path.Combine("Data", "copyMe.png");

            using FileStream reader = new FileStream(path, FileMode.Open);

            string pathNewFile = Path.Combine("Data", "newFile.png");
            using FileStream writer = new FileStream(pathNewFile, FileMode.Create);

            byte[] buffer = new byte[4096];

            while (reader.CanRead)
            {
                int bytesRead = reader.Read(buffer, 0, buffer.Length);

                if (bytesRead == 0)
                {
                    break;
                }

                writer.Write(buffer);
                //writer.Write(buffer, 0, buffer.Length);
            }
        }
    }
}
