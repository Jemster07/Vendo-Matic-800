using Capstone.Classes.Children;
using Capstone.Classes.Parents;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Capstone.Classes
{
    public class VendingMachine
    {
        Dictionary<string, Product> InventoryItems = new Dictionary<string, Product>();
        Dictionary<string, int> SetSlots = new Dictionary<string, int>();

        private string SlotQuantity { get; }
        private decimal InsertedMoney { get; }

        public VendingMachine()
        {
            string inventoryFile = ".\\Data\\vendingmachine.csv";

            try
            {
                using (StreamReader sr = new StreamReader(inventoryFile))
                {
                    while (!sr.EndOfStream)
                    {
                        string line = sr.ReadLine();
                        string[] product = line.Split('|');
                        decimal price = decimal.Parse(product[2]);

                        if (product[3] == "Chip")
                        {
                            Chip Chip = new Chip(product[1], price, product[3]);
                            InventoryItems.Add(product[0], Chip);
                        }
                        else if (product[3] == "Candy")
                        {
                            Candy Candy = new Candy(product[1], price, product[3]);
                            InventoryItems.Add(product[0], Candy);
                        }
                        else if (product[3] == "Drink")
                        {
                            Drink Drink = new Drink(product[1], price, product[3]);
                            InventoryItems.Add(product[0], Drink);
                        }
                        else //(product[3] == "Gum")
                        {
                            Gum Gum = new Gum(product[1], price, product[3]);
                            InventoryItems.Add(product[0], Gum);
                        }
                    }
                }
            }
            catch (IOException)
            {
                Console.WriteLine("Error reading inventory file!");
            }
            catch (Exception)
            {
                Console.WriteLine("Something went wrong while creating the inventory.");
            }
        }

        // Methods
        public void PrintInventory()
        {
            foreach (Product item in InventoryItems.Values)
            {
                Console.WriteLine($"{item.Name} | ${item.Price} | {item.Type}");
            }
        }
    }
}
