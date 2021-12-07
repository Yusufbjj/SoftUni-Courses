using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using OnlineShop.Models.Products.Components;
using OnlineShop.Models.Products.Peripherals;

namespace OnlineShop.Models.Products.Computers
{
    public abstract class Computer : Product, IComputer
    {
        private List<IComponent> components;
        private List<IPeripheral> peripherals;
        private double overallPerformance;

        protected Computer(int id, string manufacturer, string model, decimal price, double overallPerformance)
            : base(id, manufacturer, model, price, overallPerformance)
        {
            this.overallPerformance = overallPerformance;
            this.components = new List<IComponent>();
            this.peripherals = new List<IPeripheral>();
        }


        public IReadOnlyCollection<IComponent> Components { get => this.components; }
        public IReadOnlyCollection<IPeripheral> Peripherals { get => this.peripherals; }
        public void AddComponent(IComponent component)
        {

            if (this.components.FirstOrDefault(x => x.GetType().Name == component.GetType().Name) != null)
            {
                throw new ArgumentException($"Component {component.GetType().Name} already exists in {this.GetType().Name} with Id {Id}.");
            }

            Price += component.Price;

            this.components.Add(component);

            OverallPerformance = overallPerformance + this.components.Average(x => x.OverallPerformance);

        }

        public IComponent RemoveComponent(string componentType)
        {
            if (this.components.Count == 0)
            {
                throw new ArgumentException($"Component {componentType} does not exist in {this.GetType().Name} with Id {Id}.");
            }

            var component = this.components.FirstOrDefault(component => component.GetType().Name == componentType);

            if (component is null)
            {
                throw new ArgumentException($"Component {componentType} does not exist in {this.GetType().Name} with Id {Id}.");
            }


            Price -= component.Price;

            this.components.Remove(component);

            OverallPerformance = overallPerformance + this.components.Average(x => x.OverallPerformance);

            return component;
        }

        public void AddPeripheral(IPeripheral peripheral)
        {
            if (this.components.FirstOrDefault(x => x.GetType().Name == peripheral.GetType().Name) != null)
            {
                throw new ArgumentException($"Peripheral {peripheral.GetType().Name} already exists in {this.GetType().Name} with Id {Id}.");
            }

            Price += peripheral.Price;
            this.peripherals.Add(peripheral);
        }

        public IPeripheral RemovePeripheral(string peripheralType)
        {
            if (this.peripherals.Count == 0)
            {
                throw new ArgumentException($"Peripheral {peripheralType} does not exist in {this.GetType().Name} with Id {Id}.");
            }

            var peripheral = this.peripherals.FirstOrDefault(peripheral => peripheral.GetType().Name == peripheralType);

            if (peripheral is null)
            {
                throw new ArgumentException($"Peripheral {peripheralType} does not exist in {this.GetType().Name} with Id {Id}.");
            }

            Price -= peripheral.Price;
            this.peripherals.Remove(peripheral);

            return peripheral;
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"Overall Performance: {OverallPerformance:F2}. Price: {Price:F2} - {this.GetType().Name}: {Manufacturer} {Model} (Id: {Id})");

            sb.AppendLine($" Components ({this.components.Count}):");

            if (this.components.Any())
            {
                foreach (IComponent component in Components)
                {
                    sb.AppendLine(component.ToString());
                }
            }



            if (this.peripherals.Any())
            {
                sb.AppendLine($" Peripherals ({this.Peripherals.Count}); Average Overall Performance ({this.peripherals.Average(peripheral => peripheral.OverallPerformance)}):");
                foreach (IPeripheral peripheral in Peripherals)
                {
                    sb.AppendLine(peripheral.ToString());
                }
            }
            else
            {
                sb.AppendLine($" Peripherals ({this.Peripherals.Count}); Average Overall Performance (0.00):");
            }


            return sb.ToString().TrimEnd();
        }
    }
}
