using System;
using System.Collections.Generic;
using System.Linq;

namespace Animals
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            var input = Console.ReadLine();
            List<Animal> animals = new List<Animal>();

            while (input != "Beast!")
            {
                if (input == "Cat")
                {
                    input = Console.ReadLine();

                    var tokens = input.Split();
                    string name = tokens[0];
                    int age = int.Parse(tokens[1]);
                    string gender = tokens[2];

                    if (age < 0)
                    {
                        Console.WriteLine("Invalid input!");
                    }
                    else
                    {
                        Cat cat = new Cat(name, age, gender);
                        animals.Add(cat);

                    }



                }
                else if (input == "Dog")
                {
                    input = Console.ReadLine();

                    var tokens = input.Split();
                    string name = tokens[0];
                    int age = int.Parse(tokens[1]);
                    string gender = tokens[2];

                    if (age < 0)
                    {
                        Console.WriteLine("Invalid input!");
                    }
                    else
                    {

                        Dog dog = new Dog(name, age, gender);

                        animals.Add(dog);
                    }

                }
                else if (input == "Frog")
                {
                    input = Console.ReadLine();

                    var tokens = input.Split();
                    string name = tokens[0];
                    int age = int.Parse(tokens[1]);
                    string gender = tokens[2];

                    if (age < 0)
                    {
                        Console.WriteLine("Invalid input!");
                    }
                    else
                    {

                        Frog frog = new Frog(name, age, gender);

                        animals.Add(frog);
                    }

                }
                else if (input.Contains("Kitten"))
                {
                    input = Console.ReadLine();

                    var tokens = input.Split();
                    string name = tokens[0];
                    int age = int.Parse(tokens[1]);
                    string gender = tokens[2];

                    if (gender != null)
                    {
                        Kitten kitten = new Kitten(name, age);

                        animals.Add(kitten);
                    }

                }
                else if (input.Contains("Tomcat"))
                {
                    input = Console.ReadLine();

                    var tokens = input.Split();
                    string name = tokens[0];
                    int age = int.Parse(tokens[1]);
                    string gender = tokens[2];

                    if (gender != null)
                    {
                        Tomcat tomcat = new Tomcat(name, age);

                        animals.Add(tomcat);
                    }

                }
                else
                {
                    throw new Exception("Invalid input!");
                }



                input = Console.ReadLine();
            }

            foreach (var animal in animals)
            {
                Console.WriteLine(animal);
                Console.WriteLine($"{animal.Name} {animal.Age} {animal.Gender}");
                Console.WriteLine(animal.ProduceSound());
            }
        }
    }
}
