using OnlineShop.Common.Enums;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using OnlineShop.Common.Constants;
using System.ComponentModel;
using OnlineShop.Models.Products.Computers;
using OnlineShop.Models.Products.Peripherals;
using OnlineShop.Models.Products.Components;
using Component = OnlineShop.Models.Products.Components.Component;
using IComponent = OnlineShop.Models.Products.Components.IComponent;

namespace OnlineShop.Core
{
    public class Controller : IController
    {
        private List<Computer> computers;
        private List<IComponent> components;
        private List<IPeripheral> peripherals;
        public Controller()
        {
            computers = new List<Computer>();
            components = new List<IComponent>();
            peripherals = new List<IPeripheral>();
        }
        public string AddComputer(string computerType, int id, string manufacturer, string model, decimal price)
        {
            var currentComputer = computers.FirstOrDefault(x => x.Id == id);
            if (currentComputer != null)
            {
                throw new ArgumentException(ExceptionMessages.ExistingComputerId);
            }
            switch (computerType)
            {
                case "DesktopComputer":
                    computers.Add(new DesktopComputer(id, manufacturer, model, price, 0));
                    break;
                case "Laptop":
                    computers.Add(new Laptop(id, manufacturer, model, price, 0));
                    break;
                default: throw new ArgumentException(ExceptionMessages.InvalidComputerType);
            }
            return $"Computer with id {id} added successfully.";
        }

        public string AddComponent(int computerId, int id, string componentType, string manufacturer, string model, decimal price, double overallPerformance, int generation)
        {
            var currentComputer = computers.FirstOrDefault(x => x.Id == computerId);
            if (currentComputer == null)
            {
                throw new ArgumentException(ExceptionMessages.NotExistingComputerId);
            }
            if (components.FirstOrDefault(x => x.Id == id) != null)
            {
                throw new ArgumentException(ExceptionMessages.ExistingComponentId);
            }
            switch (componentType)
            {
                case "CentralProcessingUnit":
                    components.Add(new CentralProcessingUnit(id, manufacturer, model, price, overallPerformance, generation));
                    currentComputer.AddComponent(components.FirstOrDefault(x => x.Id == id));
                    break;
                case "Motherboard":
                    components.Add(new Motherboard(id, manufacturer, model, price, overallPerformance, generation));
                    currentComputer.AddComponent(components.FirstOrDefault(x => x.Id == id));
                    break;
                case "PowerSupply":
                    components.Add(new PowerSupply(id, manufacturer, model, price, overallPerformance, generation));
                    currentComputer.AddComponent(components.FirstOrDefault(x => x.Id == id));
                    break;
                case "RandomAccessMemory":
                    components.Add(new RandomAccessMemory(id, manufacturer, model, price, overallPerformance, generation));
                    currentComputer.AddComponent(components.FirstOrDefault(x => x.Id == id));
                    break;
                case "SolidStateDrive":
                    components.Add(new SolidStateDrive(id, manufacturer, model, price, overallPerformance, generation));
                    currentComputer.AddComponent(components.FirstOrDefault(x => x.Id == id));
                    break;
                case "VideoCard":
                    components.Add(new VideoCard(id, manufacturer, model, price, overallPerformance, generation));
                    currentComputer.AddComponent(components.FirstOrDefault(x => x.Id == id));
                    break;
                default: throw new ArgumentException(ExceptionMessages.InvalidComponentType);
            }
            return $"Component {componentType} with id {id} added successfully in computer with id {computerId}.";
        }
        public string RemoveComponent(string componentType, int computerId)
        {
            var currentComputer = computers.FirstOrDefault(x => x.Id == computerId);
            if (currentComputer == null)
            {
                throw new ArgumentException(ExceptionMessages.NotExistingComputerId);
            }
            IComponent curentComponent = currentComputer.RemoveComponent(componentType);
            components.Remove(curentComponent);
            return $"Successfully removed {componentType} with id {curentComponent.Id}.";
        }

        public string AddPeripheral(int computerId, int id, string peripheralType, string manufacturer, string model, decimal price, double overallPerformance, string connectionType)
        {
            var currentComputer = computers.FirstOrDefault(x => x.Id == computerId);
            if (currentComputer == null)
            {
                throw new ArgumentException(ExceptionMessages.NotExistingComputerId);
            }
            if (peripherals.FirstOrDefault(x => x.Id == id) != null)
            {
                throw new ArgumentException(ExceptionMessages.ExistingPeripheralId);
            }
            switch (peripheralType)
            {
                case "Headset":
                    peripherals.Add(new Headset(id, manufacturer, model, price, overallPerformance, connectionType));
                    currentComputer.AddPeripheral(peripherals.FirstOrDefault(x => x.Id == id));
                    break;
                case "Keyboard":
                    peripherals.Add(new Keyboard(id, manufacturer, model, price, overallPerformance, connectionType));
                    currentComputer.AddPeripheral(peripherals.FirstOrDefault(x => x.Id == id));
                    break;
                case "Monitor":
                    peripherals.Add(new Monitor(id, manufacturer, model, price, overallPerformance, connectionType));
                    currentComputer.AddPeripheral(peripherals.FirstOrDefault(x => x.Id == id));
                    break;
                case "Mouse":
                    peripherals.Add(new Mouse(id, manufacturer, model, price, overallPerformance, connectionType));
                    currentComputer.AddPeripheral(peripherals.FirstOrDefault(x => x.Id == id));
                    break;
                default: throw new ArgumentException(ExceptionMessages.InvalidPeripheralType);
            }
            return $"Peripheral {peripheralType} with id {id} added successfully in computer with id {computerId}.";
        }
        public string RemovePeripheral(string peripheralType, int computerId)
        {
            var currentComputer = computers.FirstOrDefault(x => x.Id == computerId);
            if (currentComputer == null)
            {
                throw new ArgumentException(ExceptionMessages.NotExistingComputerId);
            }
            IPeripheral curentPeripheral = currentComputer.RemovePeripheral(peripheralType);
            peripherals.Remove(curentPeripheral);
            return $"Successfully removed {peripheralType} with id {curentPeripheral.Id}.";
        }
        public string BuyComputer(int id)
        {
            Computer targetComputer = computers.FirstOrDefault(x => x.Id == id);
            if (targetComputer == null)
            {
                throw new ArgumentException(ExceptionMessages.NotExistingComputerId);
            }
            computers.Remove(targetComputer);
            return targetComputer.ToString().TrimEnd();
        }
        public string BuyBest(decimal budget)
        {
            Computer targetComputer = computers.OrderByDescending(x => x.OverallPerformance)
                .FirstOrDefault(x => x.Price <= budget);
            if (computers.Count == 0 || targetComputer == null)
            {
                throw new ArgumentException(ExceptionMessages.CanNotBuyComputer);
            }
            computers.Remove(targetComputer);
            return targetComputer.ToString().TrimEnd();
        }
        public string GetComputerData(int id)
        {
            var currentComputer = computers.FirstOrDefault(x => x.Id == id);
            if (currentComputer == null)
            {
                throw new ArgumentException(ExceptionMessages.NotExistingComputerId);
            }
            return currentComputer.ToString().TrimEnd();
        }
    }
}
