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

            Inventory CurrentInventory = new Inventory();
            List<object> ProductInventory = CurrentInventory.CreateInventory(inventoryFile);

            foreach (Product item in ProductInventory)
            {
                Console.WriteLine($"{item.Location} | {item.Name} | ${item.Price} | {item.Type}");
            }
        }
    }
}
