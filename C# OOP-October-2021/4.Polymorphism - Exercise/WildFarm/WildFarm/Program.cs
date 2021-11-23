using System;
using System.Collections.Generic;
using WildFarm.Animals;
using WildFarm.Food;

namespace WildFarm
{
    public class Program
    {
        static void Main(string[] args)
        {
            List<IAnimal> animals = new List<IAnimal>();

            string input = Console.ReadLine();

            while (input != "End")
            {
                string[] inputInfo = input.Split();
                string[] foodInfo = Console.ReadLine().Split();

                string animalType = inputInfo[0];
                string name = inputInfo[1];
                double weight = double.Parse(inputInfo[2]);

                string foodType = foodInfo[0];
                int quantity = int.Parse(foodInfo[1]);

                try
                {
                    IAnimal animal = null;

                    if (animalType == "Cat" || animalType == "Tiger")
                    {
                        string livingRegion = inputInfo[3];
                        string breed = inputInfo[4];

                        if (animalType == "Cat")
                        {
                            animal = new Cat(name, weight, livingRegion, breed);
                        }
                        else
                        {
                            animal = new Tiger(name, weight, livingRegion, breed);
                        }
                    }
                    else if (animalType == "Owl" || animalType == "Hen")
                    {
                        double wingSize = double.Parse(inputInfo[3]);

                        if (animalType == "Owl")
                        {
                            animal = new Owl(name, weight, wingSize);
                        }
                        else if (animalType is "Hen")
                        {
                            animal = new Hen(name, weight, wingSize);
                        }
                    }
                    else if (animalType == "Mouse" || animalType == "Dog")
                    {
                        string livingRegion = inputInfo[3];

                        if (animalType == "Mouse")
                        {
                            animal = new Mouse(name, weight, livingRegion);
                        }
                        else if (animalType is "Dog")
                        {
                            animal = new Dog(name, weight, livingRegion);
                        }
                    }

                    Console.WriteLine(animal.ProduceSound());

                    animals.Add(animal);

                    IFood food = null;

                    if (foodType == "Fruit")
                    {
                        food = new Fruit(quantity);
                    }
                    else if (foodType == "Meat")
                    {
                        food = new Meat(quantity);
                    }
                    else if (foodType == "Seeds")
                    {
                        food = new Seeds(quantity);
                    }
                    else if (foodType == "Vegetable")
                    {
                        food = new Vegetable(quantity);
                    }

                    animal.Eat(food);
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }

                input = Console.ReadLine();
            }

            foreach (IAnimal animal in animals)
            {
                Console.WriteLine(animal.ToString());
            }
        }
    }
}
