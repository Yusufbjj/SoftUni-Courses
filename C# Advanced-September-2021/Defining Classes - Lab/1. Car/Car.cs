using System;
using System.Text;

namespace CarManufacturer
{
    public class Car
    {


        public string Make { get; set; }
        public string Model { get; set; }

        public int Year { get; set; }

        public double FuelQuantity { get; set; }
        public double FuelConsumption { get; set; }

        public Car()
        {
            Make = "VW";
            Model = "Golf";
            Year = 2025;
            FuelQuantity = 200;
            FuelConsumption = 10;
        }

        public Car(string make, string model, int year) : this()
        {
            Make = make;
            Model = model;
            Year = year;
        }

        public Car(string make, string model, int year, double fuelQuantity, double fuelConsumption) : this(make, model, year)
        {
            FuelQuantity = fuelQuantity;
            FuelConsumption = fuelConsumption;
        }
        public void Drive(double distance)
        {
            double fuelConsumed = distance * (FuelConsumption / 100);
            if (FuelQuantity - fuelConsumed >= 0)
            {
                FuelQuantity -= fuelConsumed;
            }
            else
            {
                Console.WriteLine("Not enough fuel to perform this trip!");
            }
        }

        public string WhoAmI()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append($"Make: {Make}\nModel: {Model}\nYear: {Year}\nFuelQuantity: {FuelQuantity:F2}L");
            return sb.ToString();
        }

    }
}
