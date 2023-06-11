using Capstone.Classes.Parents;
using System;
using System.Collections.Generic;
using System.Text;

namespace Capstone.Classes
{
    public class VendingMachineSlot
    {
        public int Quantity { get; private set; }
        public Product Product { get; private set; }

        // Constructor
        public VendingMachineSlot(int quantity, Product product)
        {
            Quantity = quantity;
            Product = product;
        }

        // Method
        public void DecrementQuantity()
        {
            Quantity--;
        }
    }
}
