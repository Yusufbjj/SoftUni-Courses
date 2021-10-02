using System;
using System.IO;

namespace _5._Slice_a_File
{
    class Program
    {
        static void Main(string[] args)
        {
            using (FileStream streamReader = new FileStream("../../../slice.txt", FileMode.Open))
            {
                int chunkSize = (int)streamReader.Length / 4;
                for (int i = 0; i < 4; i++)
                {
                    byte[] buffer = new byte[1];
                    int count = 0;
                    using (FileStream streamWriter = new FileStream($"../../../slice-{i + 1}.txt", FileMode.Create, FileAccess.Write))
                    {

                        while (count < chunkSize)
                        {
                            streamReader.Read(buffer, 0, buffer.Length);
                            streamWriter.Write(buffer, 0, buffer.Length);
                            count++;
                        }
                    }
                }
            }
        }
    }
}
