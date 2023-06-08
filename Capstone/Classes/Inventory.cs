using Capstone.Classes.Children;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Channels;
using System.Xml.Linq;

namespace Capstone.Classes
{
    public class Inventory
    {
        // Properties

        // Constructor

        public void ReadInventoryFile()
        {
            string inventoryFile = ".\\Data\\vendingmachine.csv";
            Dictionary<string, object> ProductInventory = new Dictionary<string, object>();

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
                        }
                        else if (product[3] == "Candy")
                        {
                            Candy Candy = new Candy(product[0], product[1], price, product[3]);
                        }
                        else if (product[3] == "Drink")
                        {
                            Drink Drink = new Drink(product[0], product[1], price, product[3]);
                        }
                        else //(product[3] == "Gum")
                        {
                            Gum Gum = new Gum(product[0], product[1], price, product[3]);
                        }
                        //Add new object to ProductInventory dictionary
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
    }
}
