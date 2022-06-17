using System;
using System.Collections.Generic;
using System.Text;

namespace Shopping_Spree
{
    public class Person
    {
        private string name;
        private decimal money;
        private readonly List<Product> products;
        public Person(string name, decimal money)
        {
            this.Name = name;
            this.Money = money;
            this.products = new List<Product>();
        }

        public IReadOnlyCollection<Product> ProductsCollection
            => this.products;

        public string Name
        {
            get 
            {
                return name;
            }
            private set 
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("Name cannot be empty");
                }
                name = value;
            }
        }

        public decimal Money
        {
            get
            {
                return money; 
            }
            private set 
            {
                if (value < 0)
                {
                    throw new ArgumentException("Money cannot be negative");
                }
                money = value;
            }
        }

        public bool AddProduct(Product product)
        {
            if (this.Money -product.Cost < 0)
            {
                return false;
            }
            products.Add(product);
            this.Money -= product.Cost;

            return true;
        }
    }
}
