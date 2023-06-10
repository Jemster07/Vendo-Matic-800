using Capstone.Classes.Children;
using Capstone.Classes.Parents;
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Runtime.CompilerServices;
using System.Text;

namespace Capstone.Classes
{
    public class Inventory
    {
        Dictionary<string, Product> ReadInventory = new Dictionary<string, Product>();
        Dictionary<string, int> StockQuantity = new Dictionary<string, int>();

        public Dictionary<string, Product> GenerateInventory()
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
                            Chip Chip = new Chip(product[0], product[1], price, product[3]);
                            ReadInventory.Add(product[0], Chip);
                        }
                        else if (product[3] == "Candy")
                        {
                            Candy Candy = new Candy(product[0], product[1], price, product[3]);
                            ReadInventory.Add(product[0], Candy);
                        }
                        else if (product[3] == "Drink")
                        {
                            Drink Drink = new Drink(product[0], product[1], price, product[3]);
                            ReadInventory.Add(product[0], Drink);
                        }
                        else //(product[3] == "Gum")
                        {
                            Gum Gum = new Gum(product[0], product[1], price, product[3]);
                            ReadInventory.Add(product[0], Gum);
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

            return ReadInventory;
        }

        public Dictionary<string, int> GenerateStock()
        {
            foreach (KeyValuePair<string, Product> item in ReadInventory)
            {
                StockQuantity.Add(item.Key, 5);
            }

            return StockQuantity;
        }

        public void PrintInventory()
        {
            foreach (Product item in ReadInventory.Values)
            {
                Console.WriteLine($"{item.Location} | {item.Name} | ${item.Price} | {item.Type}");
            }
        }
    }
}
