using System;
using System.Collections.Generic;
using CustomStack;

namespace CustomStack
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            StackOfStrings stack = new StackOfStrings();
            List<string> list = new List<string>() { "1", "2", "3" };

            stack.AddRange(list);
        }
    }
}
