using Capstone.Classes.Parents;
using System;
using System.Collections.Generic;
using System.Text;

namespace Capstone.Classes
{
    public class DisplayItems
    {
        public void CallCurrentInventory()
        {
            string inventoryFile = ".\\Data\\vendingmachine.csv";

            Inventory CurrentStock = new Inventory();
            List<object> ProductInventory = CurrentStock.CreateInventory(inventoryFile);

            foreach (Product item in ProductInventory)
            {
                Console.WriteLine($"{item.Location} | {item.Name} | ${item.Price} | {item.Type}");
            }
        }
    }
}
