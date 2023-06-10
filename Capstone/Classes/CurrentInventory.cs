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
        Inventory Inventory = new Inventory();
        Dictionary<string, Product> currentInventory = new Dictionary<string, Product>();
        Dictionary<string, int> StockQuantity = new Dictionary<string, int>();

        public Dictionary<string, Product> GenerateInventory()
        {
            return currentInventory;
        }

        public Dictionary<string, int> GenerateStock()
        {
            foreach (KeyValuePair<string, Product> item in currentInventory)
            {
                StockQuantity.Add(item.Key, 5);
            }

            return StockQuantity;
        }

        public void PrintInventory()
        {
            foreach (Product item in currentInventory.Values)
            {
                Console.WriteLine($"{item.Location} | {item.Name} | ${item.Price} | {item.Type}");
            }
        }
    }
}
