using System;
using System.Collections.Generic;
using System.Text;

namespace Capstone.Classes
{
    public class Stock
    {
        public void CurrentStock()
        {
            DisplayItems ItemInventory = new DisplayItems();
            ItemInventory.CallCurrentInventory();
        }
    }
}
