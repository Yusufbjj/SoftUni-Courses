using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace _09._Simple_Text_Editor
{
    class Program
    {
        static void Main(string[] args)
        {
            Stack<string> text = new Stack<string>();
            string emptyText = "";
            int n = int.Parse(Console.ReadLine());
            for (int i = 0; i < n; i++)
            {
                string[] command = Console.ReadLine().Split().ToArray();
                int comm = int.Parse(command[0]);
                if (comm == 1)
                {
                    text.Push(emptyText);
                    emptyText += command[1];
                }
                else if (comm == 2)
                {
                    text.Push(emptyText);
                    int index = int.Parse(command[1]);
                    emptyText = text.Peek().Substring(0, emptyText.Length - index);
                }
                else if (comm == 3)
                {
                    int index = int.Parse(command[1]) - 1;
                    Console.WriteLine(emptyText[index]);
                }
                else if (comm == 4)
                {
                    emptyText = text.Pop();
                }
            }
        }
    }
}
