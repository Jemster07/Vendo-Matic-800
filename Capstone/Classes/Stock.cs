using Capstone.Classes.Parents;
using System;
using System.Collections.Generic;
using System.Text;

namespace Capstone.Classes
{
    public class Stock
    {
        public void CurrentStock()
        {
            CurrentInventory currentInventory = new CurrentInventory();
            List<object> stock = currentInventory.GenerateCurrentInventory();

            foreach (Product item in stock)
            {
                Console.WriteLine($"{item.Location} | {item.Name} | ${item.Price} | {item.Type}");
            }
        }
    }
}
