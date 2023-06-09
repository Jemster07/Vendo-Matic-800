using Capstone.Classes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;

namespace Capstone
{
    class Program
    {
        static void Main(string[] args)
        {
            PurchaseMenu vendingMachine = new PurchaseMenu();
            vendingMachine.CallPurchaseMenu();
            
            //DisplayItems VendingMachine = new DisplayItems();
            //VendingMachine.CallCurrentInventory();
        }
    }
}
