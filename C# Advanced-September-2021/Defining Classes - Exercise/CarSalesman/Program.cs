using System;
using System.Collections.Generic;
using System.Linq;

namespace CarSalesman
{
    public class Program
    {
        static void Main(string[] args)
        {
            List<Engine> engines = new List<Engine>();
            List<Car> cars = new List<Car>();

            int n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                string[] engineInfo = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);

                Engine engine = new Engine();

                string model = engineInfo[0];
                int power = int.Parse(engineInfo[1]);

                engine.Model = model;
                engine.Power = power;

                if (engineInfo.Length == 3)
                {

                    bool isNumber = int.TryParse(engineInfo[2], out int result);

                    if (isNumber)
                    {
                        int displacement = int.Parse(engineInfo[2]);
                        engine.Displacement = displacement;

                    }
                    else
                    {
                        string efficiency = engineInfo[2];
                        engine.Efficiency = efficiency;
                    }

                }

                if (engineInfo.Length == 4)
                {
                    int displacement = int.Parse(engineInfo[2]);
                    engine.Displacement = displacement;

                    string efficiency = engineInfo[3];
                    engine.Efficiency = efficiency;

                }

                engines.Add(engine);
            }

            int m = int.Parse(Console.ReadLine());

            for (int i = 0; i < m; i++)
            {
                string[] carInfo = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);

                Car car = new Car();

                string model = carInfo[0];
                string engine = carInfo[1];

                car.Model = model;
                car.Engine = engines.FirstOrDefault(x => x.Model == engine);

                if (carInfo.Length == 3)
                {
                    bool isNumber = int.TryParse(carInfo[2], out int result);

                    if (isNumber)
                    {
                        int weight = int.Parse(carInfo[2]);
                        car.Weight = weight;
                    }
                    else
                    {
                        string color = carInfo[2];
                        car.Color = color;
                    }

                }

                if (carInfo.Length == 4)
                {
                    int weight = int.Parse(carInfo[2]);
                    car.Weight = weight;

                    string color = carInfo[3];
                    car.Color = color;
                }

                cars.Add(car);
            }

            foreach (var car in cars)
            {
                Console.WriteLine(car);
            }
        }
    }
}
