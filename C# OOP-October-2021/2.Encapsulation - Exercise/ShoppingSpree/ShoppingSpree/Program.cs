using System;
using System.Collections.Generic;
using System.Linq;

namespace ShoppingSpree
{
    public class Program
    {
        static void Main(string[] args)
        {


            try
            {
                Dictionary<string, Person> people = new Dictionary<string, Person>();
                Dictionary<string, Product> products = new Dictionary<string, Product>();
                /* Peter=11;George=4
                   Bread=10;Milk=2;   */

                string[] inputPeople = Console.ReadLine().Split(";", StringSplitOptions.RemoveEmptyEntries);
                string[] inputProducts = Console.ReadLine().Split(";", StringSplitOptions.RemoveEmptyEntries);
                foreach (var currPerson in inputPeople)
                {
                    var values = currPerson.Split("=");

                    string name = values[0];
                    decimal money = decimal.Parse(values[1]);

                    Person person = new Person(name, money);
                    people.Add(person.Name, person);
                }

                foreach (var currProduct in inputProducts)
                {
                    var values = currProduct.Split("=");

                    string name = values[0];
                    decimal cost = decimal.Parse(values[1]);

                    Product product = new Product(name, cost);
                    products.Add(product.Name, product);
                }

                var command = Console.ReadLine();

                while (command != "END")
                {
                    var purchaseInfo = command.Split();

                    string personName = purchaseInfo[0];
                    string productName = purchaseInfo[1];

                    var person = people[personName];
                    var product = products[productName];

                    Console.WriteLine(person.BuyProduct(product));


                    command = Console.ReadLine();
                }

                foreach (var person in people)
                {
                    Console.Write($"{person.Key} - ");

                    var productsPerPerson = person.Value.BagOfProducts;

                    if (productsPerPerson.Count == 0)
                    {
                        Console.WriteLine("Nothing bought");
                    }
                    else
                    {
                        Console.WriteLine(string.Join(", ", productsPerPerson));

                    }
                }

            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);

            }


        }
    }
}
