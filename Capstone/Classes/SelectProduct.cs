using System;
using System.Collections.Generic;
using System.Text;

namespace Capstone.Classes
{
    public class SelectProduct
    {
        CurrentInventory currentInventory = new CurrentInventory();

        // Properties
        public decimal Balance { get; private set; }

        // Constructors
        public SelectProduct() { }

        // Methods
        public void BuyItem(decimal balance)
        {
            currentInventory.PrintInventory();

            Console.WriteLine();
            Console.Write("Select your product: ");
            Console.WriteLine();

        }
    }
}
