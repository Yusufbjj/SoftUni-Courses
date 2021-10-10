using System;
using System.Collections.Generic;
using System.Linq;

namespace RawDate
{
    public class Program
    {
        public static void Main(string[] args)
        {
            List<Car> cars = new List<Car>();

            int n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                string[] input = Console.ReadLine().Split();

                string name = input[0];
                int engineSpeed = int.Parse(input[1]);
                int enginePower = int.Parse(input[2]);
                int cargoWeight = int.Parse(input[3]);
                string cargoType = input[4];

                List<Tire> tires = new List<Tire>();

                for (int tireIndex = 5; tireIndex <= 12; tireIndex += 2)
                {
                    double tirePressure = double.Parse(input[tireIndex]);
                    int tireAge = int.Parse(input[tireIndex + 1]);

                    Tire tire = new Tire(tireAge, tirePressure);
                    tires.Add(tire);
                }

                Engine engine = new Engine(engineSpeed, enginePower);

                Cargo cargo = new Cargo(cargoType, cargoWeight);

                Car car = new Car(name, engine, cargo, tires);

                cars.Add(car);

            }

            string cargoTypee = Console.ReadLine();

            if (cargoTypee == "fragile")
            {
                List<Car> fragileCars = cars
                    .Where(x => x.Cargo.Type == "fragile" && x.Tires.Any(t => t.Pressure < 1))
                    .ToList();

                foreach (var car in fragileCars)
                {
                    Console.WriteLine(car.Model);
                }
            }
            else
            {
                List<Car> flammableCars = cars
                    .Where(x => x.Cargo.Type == "flammable" && x.Engine.Power > 250)
                    .ToList();

                foreach (var car in flammableCars)
                {
                    Console.WriteLine(car.Model);
                }
            }

        }
    }
}
