using System;
using System.Collections.Generic;

namespace _08._Balanced_Parenthesis
{
    class Program
    {
        static void Main(string[] args)
        {
            string sequence = Console.ReadLine();
            Stack<char> symbols = new Stack<char>();
            for (int i = 0; i < sequence.Length; i++)
            {
                if (sequence[i] == '{' || sequence[i] == '[' || sequence[i] == '(')
                {
                    symbols.Push(sequence[i]);
                }
                else
                {
                    if (symbols.Count != 0)
                    {
                        if (sequence[i] == '}' && symbols.Peek() == '{')
                        {
                            symbols.Pop();
                        }
                        else if (sequence[i] == ']' && symbols.Peek() == '[')
                        {
                            symbols.Pop();
                        }
                        else if (sequence[i] == ')' && symbols.Peek() == '(')
                        {
                            symbols.Pop();
                        }
                    }
                    else
                    {
                        Console.WriteLine("NO");
                        return;
                    }
                }
            }
            if (symbols.Count == 0)
            {
                Console.WriteLine("YES");
            }
            else
            {
                Console.WriteLine("NO");
            }
        }
    }
}
