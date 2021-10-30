using System;

namespace NeedForSpeed
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            Vehicle vehicle = new Vehicle(200, 100);
            Car car = new Car(150, 80);
            Motorcycle motorcycle = new Motorcycle(100, 50);

            RaceMotorcycle raceMotorcycle = new RaceMotorcycle(150, 90);
            CrossMotorcycle cross = new CrossMotorcycle(130, 70);
            FamilyCar familyCar = new FamilyCar(80, 80);
            SportCar sportCar = new SportCar(250, 200);

            Console.WriteLine(raceMotorcycle.FuelConsumption);


        }
    }
}
