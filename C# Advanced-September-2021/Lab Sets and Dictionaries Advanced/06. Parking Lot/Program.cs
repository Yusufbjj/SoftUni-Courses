using System;
using System.Collections.Generic;

namespace _06._Parking_Lot
{
    class Program
    {
        static void Main(string[] args)
        {
            string command = Console.ReadLine();
            HashSet<string> parkingLot = new HashSet<string>();

            while (command != "END")
            {
                string[] tokens = command.Split(", ", StringSplitOptions.RemoveEmptyEntries);
                string direction = tokens[0];
                string number = tokens[1];

                if (direction == "IN")
                {
                    parkingLot.Add(number);
                }
                else
                {
                    parkingLot.Remove(number);
                }

                command = Console.ReadLine();
            }

            if (parkingLot.Count == 0)
            {
                Console.WriteLine("Parking Lot is Empty");
            }

            foreach (var number in parkingLot)
            {
                Console.WriteLine(number);
            }
        }
    }
}
