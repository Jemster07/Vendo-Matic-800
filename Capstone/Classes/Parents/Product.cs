using System;
using System.Collections.Generic;
using System.Text;

namespace Capstone.Classes.Parents
{
    public abstract class Product
    {
        public string Name { get; private set; }
        public decimal Price { get; private set; }
        public string Type { get; private set; }
        public string Message { get; private set; }

        public Product(string name, decimal price, string type, string message)
        {
            Name = name;
            Price = price;
            Type = type;
            Message = message;
        }
    }
}
