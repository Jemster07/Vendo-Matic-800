using Capstone.Classes.Parents;
using System;
using System.Collections.Generic;
using System.Text;

namespace Capstone.Classes
{
    public class CurrentInventory
    {
        // Properties
        public string Inventory { get; private set; }

        // Constructors
        public CurrentInventory() { }

        // Methods
        public List<object> GenerateCurrentInventory()
        {
            string inventoryFile = ".\\Data\\vendingmachine.csv";

            Inventory Inventory = new Inventory();
            List<object> CurrentInventory = Inventory.CreateInventory(inventoryFile);

            return CurrentInventory;
        }
    }
}
