using System;
using System.Collections.Generic;
using System.Text;

namespace OnlineShop.Models.Products
{
    public abstract class Product : IProduct
    {
        private int id;
        private string manufacturer;
        private string model;
        private decimal price;
        private double overallPerformance;

        protected Product(int id, string manufacturer, string model, decimal price, double overallPerformance)
        {
            this.Id = id;
            this.Manufacturer = manufacturer;
            this.Model = model;
            this.Price = price;
            this.OverallPerformance = overallPerformance;
        }

        public int Id
        {
            get => this.id;
            private set
            {
                if (value <= 0)
                {
                    throw new ArgumentException("Id can not be less or equal than 0.");
                }

                this.id = value;
            }
        }

        public string Manufacturer
        {
            get => this.manufacturer;
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("Manufacturer can not be empty.");
                }

                this.manufacturer = value;
            }
        }

        public string Model
        {
            get => this.model;
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("Model can not be empty.");
                }

                this.model = value;
            }
        }
        public virtual decimal Price
        {
            get => this.price;
            protected set
            {
                if (value <= 0)
                {
                    throw new ArgumentException("Price can not be less or equal than 0.");
                }

                this.price = value;
            }
        }
        public virtual double OverallPerformance
        {
            get => this.overallPerformance;
            protected set
            {
                if (value <= 0)
                {
                    throw new ArgumentException("Overall Performance can not be less or equal than 0.");
                }

                this.overallPerformance = value;
            }
        }

        public override string ToString()
        {
            return $"Overall Performance: {OverallPerformance}. Price: {Price} - {this.GetType().Name}: {Manufacturer} {Model} (Id: {Id})";
        }
    }
}
