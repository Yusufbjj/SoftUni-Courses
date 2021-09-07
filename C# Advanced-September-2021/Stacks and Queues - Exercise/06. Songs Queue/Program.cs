using System;
using System.Collections.Generic;
using System.Linq;

namespace _06._Songs_Queue
{
    class Program
    {
        static void Main(string[] args)
        {
            var songs = Console.ReadLine().Split(", ").ToArray();
            string firstSong = Console.ReadLine();
            Queue<string> songsQueue = new Queue<string>(songs);
            while (songsQueue.Count > 0)
            {
                if (firstSong.Contains("Play"))
                {
                    songsQueue.Dequeue();
                }
                else if (firstSong.Contains("Add"))
                {
                    if (songsQueue.Contains(firstSong.Substring(4)))
                    {
                        Console.WriteLine($"{firstSong.Substring(4)} is already contained!");
                    }
                    else
                    {
                        songsQueue.Enqueue(firstSong.Substring(4));

                    }
                }
                else if (firstSong.Contains("Show"))
                {
                    Console.WriteLine(string.Join(", ", songsQueue));
                }
                firstSong = Console.ReadLine();
            }
            Console.WriteLine("No more songs!");
        }
    }
}
