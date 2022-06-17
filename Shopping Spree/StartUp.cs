using System;
using System.Collections.Generic;
using System.Linq;

namespace Shopping_Spree
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            Dictionary<string, Person> personKvp = new Dictionary<string, Person>();

            Dictionary<string, Product> productKvp = new Dictionary<string, Product>();


            try
            {
                string[] people = Console.ReadLine()
                    .Split(new char[] { '=', ';' }, StringSplitOptions.RemoveEmptyEntries);

                for (int i = 0; i < people.Length; i += 2)
                {
                    string name = people[i];
                    decimal money = decimal.Parse(people[i + 1]);

                    Person person = new Person(name, money);

                    personKvp.Add(name, person);
                }


                string[] products = Console.ReadLine()
                    .Split(new char[] { '=', ';' }, StringSplitOptions.RemoveEmptyEntries);

                for (int i = 0; i < products.Length; i += 2)
                {
                    string name = products[i];
                    decimal cost = decimal.Parse(products[i + 1]);

                    Product product = new Product(name, cost);

                    productKvp.Add(name, product);
                }


                string command = Console.ReadLine();

                while (command != "END")
                {
                    string[] commandInfo = command.Split(" ", StringSplitOptions.RemoveEmptyEntries);

                    string personName = commandInfo[0];
                    string productName = commandInfo[1];

                    Person person = personKvp[personName];
                    Product product = productKvp[productName];

                    bool isAdded = person.AddProduct(product);

                    if (!isAdded)
                    {
                        Console.WriteLine($"{personName} can't afford {productName}");
                    }
                    else
                    {
                        Console.WriteLine($"{personName} bought {productName}");
                    }
                    command = Console.ReadLine();
                }

                foreach (var (name , person) in personKvp)
                {
                    string productsInfo = person.ProductsCollection.Count > 0
                        ? string.Join(", ", person.ProductsCollection.Select(x => x.Name))
                        : "Nothing bought";

                    Console.WriteLine($"{name} - {productsInfo}");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
