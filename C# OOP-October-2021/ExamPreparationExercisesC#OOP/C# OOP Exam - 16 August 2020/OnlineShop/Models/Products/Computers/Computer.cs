using OnlineShop.Common.Constants;
using OnlineShop.Models.Products.Components;
using OnlineShop.Models.Products.Peripherals;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OnlineShop.Models.Products.Computers
{
    public abstract class Computer : Product, IComputer
    {
        private List<IComponent> components;
        private List<IPeripheral> peripherals;
        private decimal price;
        private double overallPerformance;


        protected Computer(int id, string manufacturer, string model, decimal price, double overallPerformance)
            : base(id, manufacturer, model, price, overallPerformance)
        {
            this.components = new List<IComponent>();
            this.peripherals = new List<IPeripheral>();
            this.Price = price;
            this.OverallPerformance = overallPerformance;
        }

        public IReadOnlyCollection<IComponent> Components => this.components;


        public IReadOnlyCollection<IPeripheral> Peripherals => this.peripherals;

        public decimal Price
        {
            get
            {
                decimal finalPrice = this.price;
                if (this.components.Count > 0)
                {
                    finalPrice += this.components.Sum(x => x.Price);
                }
                if (this.peripherals.Count > 0)
                {
                    finalPrice += peripherals.Sum(x => x.Price);
                }
                return finalPrice;
            }
            set => this.price = value;
        }
        public double OverallPerformance
        {
            get
            {
                if (components.Count == 0)
                {
                    return this.overallPerformance;
                }
                return this.overallPerformance + components.Average(x => x.OverallPerformance);
            }
            private set => this.overallPerformance = value;
        }

        public void AddComponent(IComponent component)
        {
            if (components.Count > 0)
            {
                foreach (var item in components)
                {
                    if (item.GetType().Name == component.GetType().Name)
                    {
                        throw new ArgumentException($"Component {component.GetType().Name} already exists in {this.GetType().Name} with Id {this.Id}.");
                    }
                }
            }
            this.components.Add(component);
        }

        public void AddPeripheral(IPeripheral peripheral)
        {
            if (peripherals.Count > 0)
            {
                foreach (var item in peripherals)
                {
                    if (item.GetType().Name == peripheral.GetType().Name)
                    {
                        throw new ArgumentException($"Peripheral {peripheral.GetType().Name} already exists in {this.GetType().Name} with Id {this.Id}.");
                    }
                }
            }
            this.peripherals.Add(peripheral);
        }

        public IComponent RemoveComponent(string componentType)
        {
            if (this.components.Count == 0 || this.components.FirstOrDefault(x => x.GetType().Name == componentType) == null)
            {
                throw new ArgumentException($"Component {componentType} does not exist in {base.GetType().Name} with Id {base.Id}.");
            }
            var curentComponent = this.components.FirstOrDefault(x => x.GetType().Name == componentType);
            this.components.Remove(curentComponent);
            return curentComponent;
        }

        public IPeripheral RemovePeripheral(string peripheralType)
        {
            if (this.peripherals.Count == 0 || this.peripherals.FirstOrDefault(x => x.GetType().Name == peripheralType) == null)
            {
                throw new ArgumentException($"Peripheral {peripheralType} does not exist in {base.GetType().Name} with Id {base.Id}.");
            }
            var curentPeripheral = this.peripherals.FirstOrDefault(x => x.GetType().Name == peripheralType);
            this.peripherals.Remove(curentPeripheral);
            return curentPeripheral;
        }

        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.AppendLine($"Overall Performance: {this.OverallPerformance:f2}. Price: {this.Price:f2} - {this.GetType().Name}: {this.Manufacturer} {this.Model} (Id: {this.Id})");
            sb.AppendLine($" Components ({this.components.Count}):");
            foreach (var item in this.components)
            {
                sb.AppendLine($"  {item.ToString()}");
            }
            double result;
            if (this.peripherals.Count > 0)
            {
                result = this.peripherals.Average(x => x.OverallPerformance);
            }
            else
            {
                result = 0;
            }
            sb.AppendLine($" Peripherals ({this.peripherals.Count}); Average Overall Performance ({result:f2}):");
            foreach (var item in this.peripherals)
            {
                sb.AppendLine($"  {item.ToString()}");
            }
            return sb.ToString().TrimEnd();
        }
    }
}
