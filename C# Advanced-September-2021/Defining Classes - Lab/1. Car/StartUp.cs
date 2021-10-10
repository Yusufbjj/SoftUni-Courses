using System;
using System.Collections.Generic;
using System.Linq;

namespace CarManufacturer
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            /* string make = Console.ReadLine();
             string model = Console.ReadLine();
             int year = int.Parse(Console.ReadLine());
             double fuelQuantity = double.Parse(Console.ReadLine());
             double fuelConsumption = double.Parse(Console.ReadLine());

             Car bmw = new Car("bmw", "m3", 2020, 120, 12);
             Console.WriteLine(bmw.WhoAmI());
             Car defaCar = new Car();
             Console.WriteLine(defaCar.WhoAmI());
             Car car = new Car();
             car.Make = "VW";
             car.Model = "MK3";
             car.Year = 1992;
             car.FuelQuantity = 200;
             car.FuelConsumption = 200;
             car.Drive(0.5);
             Console.WriteLine(car.WhoAmI());



             Car firstCar = new Car();
             Car secondCar = new Car(make, model, year);
             Car thirdCar = new Car(make, model, year, fuelQuantity, fuelConsumption);
             Console.WriteLine(firstCar.Make);
             Console.WriteLine(secondCar.Model);
             Console.WriteLine(thirdCar.FuelQuantity);*/

            /* Tire[] tires = new Tire[4]
             {
                 new Tire(1, 2.5),
                 new Tire(1, 2.1),
                 new Tire(2, 0.5),
                 new Tire(2, 2.3),
             };*/

            /* Engine engine = new Engine(560, 6300);

             Car car = new Car("Lada", "Niva", 1970, 100, 10, engine, tires);
             foreach (var tire in car.Tires)
             {
                 Console.WriteLine(tire.Pressure);
             }*/


            var tires = new List<Tire[]>();
            var engines = new List<Engine>();
            List<Car> cars = new List<Car>();

            while (true)
            {
                string command = Console.ReadLine();

                var tiresPerCar = new List<Tire>();

                if (command == "No more tires")
                {
                    break;
                }

                var input = command.Split(" ", StringSplitOptions.RemoveEmptyEntries).ToList();

                for (int i = 0; i < input.Count; i += 2)
                {
                    tiresPerCar.Add(new Tire(int.Parse(input[0]), double.Parse(input[i + 1])));
                }

                tires.Add(tiresPerCar.ToArray());

            }


            while (true)
            {
                string command = Console.ReadLine();

                if (command == "Engines done")
                {
                    break;
                }

                var input = command.Split(" ", StringSplitOptions.RemoveEmptyEntries).ToList();

                var currentEngine = new Engine(int.Parse(input[0]), double.Parse(input[1]));

                engines.Add(currentEngine);
            }

            while (true)
            {
                string comand = Console.ReadLine();

                if (comand == "Show special")
                {
                    break;
                }

                var input = comand.Split(" ", StringSplitOptions.RemoveEmptyEntries).ToList();

                Car newCar = new Car(input[0], input[1], int.Parse(input[2]), double.Parse(input[3]),
                    double.Parse(input[4]), engines[int.Parse(input[5])], tires[int.Parse(input[6])]);
                cars.Add(newCar);
            }

            cars = cars.Where(car => car.Year >= 2017 && car.Engine.HorsePower > 330 && car.Tires.Sum(t => t.Pressure) >= 9 && car.Tires.Sum(t => t.Pressure) <= 10).ToList();

            foreach (Car car in cars)
            {
                car.Drive(20);
                Console.WriteLine(car.WhoAmI());
            }
        }
    }
}
