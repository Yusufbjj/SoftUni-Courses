using System;
using System.Collections.Generic;

namespace BorderControl
{
    public class Program
    {
        static void Main(string[] args)
        {
            List<IIdentifiable> allIdentifiables = new List<IIdentifiable>();
            List<IBirthdable> allBirthdables = new List<IBirthdable>();
            Dictionary<string, IBuyer> buyers = new Dictionary<string, IBuyer>();

            var n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                string[] input = Console.ReadLine().Split();
                if (input.Length == 4)//citizen
                {
                    string name = input[0];
                    int age = int.Parse(input[1]);
                    string id = input[2];
                    string birthdate = input[3];

                    buyers.Add(name, new Citizen(name, age, id, birthdate));

                }
                else //rebel
                {
                    string name = input[0];
                    int age = int.Parse(input[1]);
                    string group = input[2];

                    buyers.Add(name, new Rebel(name, age, group));

                }
            }

            string inputLine = Console.ReadLine();

            while (inputLine != "End")
            {
                string name = inputLine;

                if (buyers.ContainsKey(name))
                {
                    buyers[name].BuyFood();
                }

                inputLine = Console.ReadLine();
            }


            int sum = 0;
            foreach (var members in buyers)
            {

                sum += members.Value.Food;
            }

            Console.WriteLine(sum);

        }
    }
}
