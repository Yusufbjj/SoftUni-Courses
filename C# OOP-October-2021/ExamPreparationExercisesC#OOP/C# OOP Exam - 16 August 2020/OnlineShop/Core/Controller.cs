using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using OnlineShop.Common.Enums;
using OnlineShop.Models.Products.Components;
using OnlineShop.Models.Products.Computers;
using OnlineShop.Models.Products.Peripherals;

namespace OnlineShop.Core
{
    public class Controller : IController
    {
        private List<IComputer> computers;
        private List<IComponent> components;
        private List<IPeripheral> peripherals;
        public Controller()
        {
            this.computers = new List<IComputer>();
            this.components = new List<IComponent>();
            this.peripherals = new List<IPeripheral>();
        }

        public string AddComputer(string computerType, int id, string manufacturer, string model, decimal price)
        {
            if (this.computers.FirstOrDefault(x => x.Id == id) != null)
            {
                throw new ArgumentException("Computer with this id already exist.");
            }

            IComputer computer = null;

            if (computerType == ComputerType.DesktopComputer.ToString())
            {
                computer = new DesktopComputer(id, manufacturer, model, price);
            }
            else if (computerType == ComputerType.Laptop.ToString())
            {
                computer = new Laptop(id, manufacturer, model, price);
            }
            else
            {
                throw new ArgumentException("Computer type is invalid.");
            }

            this.computers.Add(computer);

            return $"Computer with id {id} added successfully.";
        }

        public string AddPeripheral(int computerId, int id, string peripheralType, string manufacturer, string model, decimal price, double overallPerformance, string connectionType)
        {
            var computer = this.computers.FirstOrDefault(x => x.Id == computerId);

            if (computer == null)
            {
                throw new ArgumentException("Computer with this id does not exist.");
            }

            var neededPeripheral = this.peripherals.FirstOrDefault(x => x.Id == id);

            if (neededPeripheral != null)
            {
                return "Peripheral with this id already exists.";
            }

            IPeripheral peripheral = null;

            if (peripheralType == PeripheralType.Headset.ToString())
            {
                peripheral = new Headset(id, manufacturer, model, price, overallPerformance, connectionType);
            }
            else if (peripheralType == PeripheralType.Keyboard.ToString())
            {
                peripheral = new Keyboard(id, manufacturer, model, price, overallPerformance, connectionType);
            }
            else if (peripheralType == PeripheralType.Monitor.ToString())
            {
                peripheral = new Monitor(id, manufacturer, model, price, overallPerformance, connectionType);
            }
            else if (peripheralType == PeripheralType.Mouse.ToString())
            {
                peripheral = new Mouse(id, manufacturer, model, price, overallPerformance, connectionType);
            }
            else
            {
                throw new ArgumentException("Peripheral type is invalid.");
            }

            computer.AddPeripheral(peripheral);

            this.peripherals.Add(peripheral);

            return $"Peripheral {peripheralType} with id {id} added successfully in computer with id {computer.Id}.";

        }

        public string RemovePeripheral(string peripheralType, int computerId)
        {
            var computer = this.computers.FirstOrDefault(x => x.Id == computerId);

            if (computer == null)
            {
                throw new ArgumentException("Computer with this id does not exist.");
            }

            var peripheral = computer.Peripherals.FirstOrDefault(x => x.GetType().Name == peripheralType);

            computer.RemovePeripheral(peripheralType);

            this.peripherals.Remove(peripheral);

            return $"Successfully removed {peripheralType} with id {peripheral.Id}.";
        }

        public string AddComponent(int computerId, int id, string componentType, string manufacturer, string model, decimal price, double overallPerformance, int generation)
        {
            var computer = this.computers.FirstOrDefault(x => x.Id == computerId);

            if (computer == null)
            {
                throw new ArgumentException("Computer with this id does not exist.");
            }

            var componentNeeded = this.components.FirstOrDefault(x => x.Id == id);

            if (componentNeeded != null)
            {
                return "Component with this id already exists.";
            }

            IComponent component = null;

            if (componentType == ComponentType.CentralProcessingUnit.ToString())
            {
                component = new CentralProcessingUnit(id, manufacturer, model, price, overallPerformance, generation);
            }
            else if (componentType == ComponentType.Motherboard.ToString())
            {
                component = new Motherboard(id, manufacturer, model, price, overallPerformance, generation);
            }
            else if (componentType == ComponentType.PowerSupply.ToString())
            {
                component = new PowerSupply(id, manufacturer, model, price, overallPerformance, generation);
            }
            else if (componentType == ComponentType.RandomAccessMemory.ToString())
            {
                component = new RandomAccessMemory(id, manufacturer, model, price, overallPerformance, generation);
            }
            else if (componentType == ComponentType.SolidStateDrive.ToString())
            {
                component = new SolidStateDrive(id, manufacturer, model, price, overallPerformance, generation);
            }
            else if (componentType == ComponentType.VideoCard.ToString())
            {
                component = new VideoCard(id, manufacturer, model, price, overallPerformance, generation);
            }
            else
            {
                throw new ArgumentException("Component type is invalid.");
            }

            computer.AddComponent(component);

            this.components.Add(component);

            return $"Component {componentType} with id {id} added successfully in computer with id {computer.Id}.";

        }

        public string RemoveComponent(string componentType, int computerId)
        {
            var computer = this.computers.FirstOrDefault(x => x.Id == computerId);

            if (computer == null)
            {
                throw new ArgumentException("Computer with this id does not exist.");
            }

            var component = computer.Components.FirstOrDefault(x => x.GetType().Name == componentType);

            computer.RemoveComponent(componentType);

            this.components.Remove(component);

            return $"Successfully removed {componentType} with id {computerId}.";
        }

        public string BuyComputer(int id)
        {
            var computer = this.computers.FirstOrDefault(x => x.Id == id);

            if (computer == null)
            {
                throw new ArgumentException("Computer with this id does not exist.");
            }

            this.computers.Remove(computer);

            return computer.ToString();
        }

        public string BuyBest(decimal budget)
        {
            var sortedComputers = this.computers.OrderByDescending(x => x.OverallPerformance).ToList();

            var computer = sortedComputers.FirstOrDefault(x => x.Price <= budget);

            if (sortedComputers.Count == 0 || computer == null)
            {
                throw new ArgumentException(" Can't buy a computer with a budget of ${budget}.");
            }

            this.computers.Remove(computer);

            return computer.ToString();

        }

        public string GetComputerData(int id)
        {
            var computer = this.computers.FirstOrDefault(x => x.Id == id);

            if (computer == null)
            {
                throw new ArgumentException("Computer with this id does not exist.");
            }

            return computer.ToString();
        }
    }
}
