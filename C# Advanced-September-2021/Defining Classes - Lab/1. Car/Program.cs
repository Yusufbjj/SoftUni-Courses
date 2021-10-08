using System;

namespace CarManufacturer
{
    class Car
    {
        private string make;

        private string model;

        private int year;

        public string Make
        {
            get { return this.make; }
            set { this.make = value; }
        }

        public string Model
        {
            get { return this.model; }
            set { this.model = value; }
        }

        public int Year
        {
            get { return this.year; }
            set { this.year = value; }
        }
    }
    public class StartUp
    {
        public static void Main(string[] args)
        {
            Car car = new Car();
            car.Make = "BMW";
            car.Model = "M5";
            car.Year = 2021;
            Console.WriteLine($"My car is {car.Make} {car.Model} {car.Year}.");
        }
    }
}
