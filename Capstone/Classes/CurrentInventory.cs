using Capstone.Classes.Children;
using Capstone.Classes.Parents;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;

namespace Capstone.Classes
{
    public class CurrentInventory
    {
        // Properties
        public string Inventory { get; }

        // Constructors
        public CurrentInventory() { }

        // Methods

        public Dictionary<string, Product> GenerateInventory()
        {
            Inventory Inventory = new Inventory();
            Dictionary<string, Product> CurrentInventory = Inventory.ReadInventory();

            return CurrentInventory;
        }

        public Dictionary<string, int> GenerateStock()
        {
            Inventory Inventory = new Inventory();
            Dictionary<string, Product> CurrentInventory = Inventory.ReadInventory();

            Dictionary<string, int> StockQuantity = new Dictionary<string, int>();

            foreach (KeyValuePair<string, Product> item in CurrentInventory)
            {
                StockQuantity.Add(item.Key, 5);
            }

            return StockQuantity;
        }

        public void PrintInventory()
        {
            Inventory Inventory = new Inventory();
            Dictionary<string, Product> CurrentInventory = Inventory.ReadInventory();

            foreach (Product item in CurrentInventory.Values)
            {
                Console.WriteLine($"{item.Location} | {item.Name} | ${item.Price} | {item.Type}");
            }
        }
    }
}
