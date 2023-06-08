using System;
using System.Collections.Generic;
using System.Text;

namespace Capstone.Classes.Parents
{
    public abstract class Product
    {
        // Each product as location, food name, price, and food type
        // food type determines what sound displays after consumption

        public string Location { get; private set; }
        public string Name { get; private set; }
        public decimal Price { get; private set; }
        public string Type { get; private set; }
        public string Message { get; private set; }

        public Product(string location, string name, decimal price, string type, string message)
        {
            Location = location;
            Name = name;
            Price = price;
            Type = type;
            Message = message;
        }
    }
}
