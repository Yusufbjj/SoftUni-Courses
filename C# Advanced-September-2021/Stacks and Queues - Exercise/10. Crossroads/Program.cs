using System;
using System.Collections.Generic;

namespace _10._Crossroads
{
    class Program
    {
        static void Main(string[] args)
        {
            int greenLightSeconds = int.Parse(Console.ReadLine());
            int freeWindow = int.Parse(Console.ReadLine());
            string command = Console.ReadLine();
            Queue<string> queue = new Queue<string>();
            int totalCarsPassed = 0;
            char characterHit = ' ';
            bool isSafe = true;
            while (command != "END")
            {
                int secondsLeft = greenLightSeconds;
                if (command == "green")
                {
                    while (secondsLeft > 0 && queue.Count > 0)
                    {
                        string car = queue.Peek();
                        if (car.Length <= secondsLeft)
                        {
                            queue.Dequeue();
                            secondsLeft = secondsLeft - car.Length;
                            totalCarsPassed++;
                        }
                        else
                        {
                            car = car.Substring(secondsLeft);
                            secondsLeft = 0;
                            if (car.Length <= freeWindow)
                            {
                                queue.Dequeue();
                                totalCarsPassed++;
                            }
                            else
                            {
                                Console.WriteLine("A crash happened!");
                                Console.WriteLine($"{queue.Peek()} was hit at {car[freeWindow]}.");
                                return;
                            }
                        }
                    }
                }
                else
                {
                    string car = command;
                    queue.Enqueue(car);
                    secondsLeft = greenLightSeconds;

                }

                command = Console.ReadLine();
            }
            if (isSafe)
            {
                Console.WriteLine("Everyone is safe.");
                Console.WriteLine($"{totalCarsPassed} total cars passed the crossroads.");
            }

        }
    }
}
