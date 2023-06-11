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
        Logging log = new Logging();
        Dictionary<string, VendingMachineSlot> InventoryItem = new Dictionary<string, VendingMachineSlot>();

        // Property
        public decimal Balance { get; private set; }

        // Constructor
        public VendingMachine(decimal balance)
        {
            Balance = balance;

            int quantity = 5;
            string inventorySourceFile = ".\\Data\\vendingmachine.csv";

            try
            {
                using (StreamReader sr = new StreamReader(inventorySourceFile))
                {
                    while (!sr.EndOfStream)
                    {
                        string line = sr.ReadLine();
                        string[] productSourceArray = line.Split('|');

                        string productLocation = productSourceArray[0];
                        string productName = productSourceArray[1];
                        decimal productPrice = decimal.Parse(productSourceArray[2]);
                        string productType = productSourceArray[3];

                        if (productSourceArray[3] == "Chip")
                        {
                            Chip Chip = new Chip(productName, productPrice, productType);
                            VendingMachineSlot newVendingMachineSlot = new VendingMachineSlot(quantity, Chip);
                            InventoryItem.Add(productLocation, newVendingMachineSlot);
                        }
                        else if (productSourceArray[3] == "Candy")
                        {
                            Candy Candy = new Candy(productName, productPrice, productType);
                            VendingMachineSlot newVendingMachineSlot = new VendingMachineSlot(quantity, Candy);
                            InventoryItem.Add(productLocation, newVendingMachineSlot);
                        }
                        else if (productSourceArray[3] == "Drink")
                        {
                            Drink Drink = new Drink(productName, productPrice, productType);
                            VendingMachineSlot newVendingMachineSlot = new VendingMachineSlot(quantity, Drink);
                            InventoryItem.Add(productLocation, newVendingMachineSlot);
                        }
                        else //(product[3] == "Gum")
                        {
                            Gum Gum = new Gum(productName, productPrice, productType);
                            VendingMachineSlot newVendingMachineSlot = new VendingMachineSlot(quantity, Gum);
                            InventoryItem.Add(productLocation, newVendingMachineSlot);
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
            Console.Clear();
            Console.WriteLine("--- Vending Machine Items ---");
            Console.WriteLine();

            foreach (KeyValuePair<string, VendingMachineSlot> slot in InventoryItem)
            {
                Console.WriteLine($"{slot.Key} | {slot.Value.Product.Name} | ${slot.Value.Product.Price} | {slot.Value.Product.Type}");
            }

            Console.WriteLine();
        }

        public decimal FeedMoney(decimal balance)
        {
            bool endMenu = false;

            while (!endMenu)
            {
                Console.Clear();
                Console.WriteLine("--- Feed Money ---");
                Console.WriteLine();
                Console.WriteLine($"Current Balance: ${balance}");
                Console.WriteLine();
                Console.Write("Please Insert Money [$1,$5,$10,$20]: ");

                string userInput = Console.ReadLine();
                decimal insertedMoney = decimal.Parse(userInput);

                while (insertedMoney != 1.00M && insertedMoney != 5.00M && insertedMoney != 10.00M && insertedMoney != 20.00M)
                {
                    Console.Clear();
                    Console.WriteLine("--- Feed Money ---");
                    Console.WriteLine();
                    Console.WriteLine($"Current Balance: ${balance}");
                    Console.WriteLine();
                    Console.WriteLine("Invalid entry, please try again.");
                    Console.WriteLine();
                    Console.Write("Please Insert Money [$1,$5,$10,$20]: ");

                    userInput = Console.ReadLine();
                    insertedMoney = decimal.Parse(userInput);

                }

                balance += insertedMoney;
                Console.Clear();
                Console.WriteLine("--- Feed Money ---");
                Console.WriteLine();
                Console.WriteLine($"Current Balance: ${balance}");
                Console.WriteLine();

                log.FeedMoneyLog(userInput, balance);

                bool addMoreMoney = false;

                while (!addMoreMoney)
                {
                    Console.Write("Would you like to add more money? [Y/N]: ");
                    userInput = Console.ReadLine().ToLower();

                    while (!userInput.StartsWith("y") && !userInput.StartsWith("n"))
                    {
                        Console.Clear();
                        Console.WriteLine("--- Feed Money ---");
                        Console.WriteLine();
                        Console.WriteLine($"Current Balance: ${balance}");
                        Console.WriteLine();
                        Console.WriteLine("Invalid selection, please try again.");
                        Console.WriteLine();
                        Console.Write("Would you like to add more money? [Y/N]: ");

                        userInput = Console.ReadLine().ToLower();
                    }

                    if (userInput.StartsWith("n"))
                    {
                        return balance;
                    }
                    else
                    {
                        addMoreMoney = true;
                    }
                }
            }

            return balance;
        }

        public decimal SelectProduct(decimal balance)
        {
            PrintInventory();
            Console.WriteLine($"Current Balance: ${balance}");
            Console.WriteLine();
            Console.Write("Select your product: ");
            string userInput = Console.ReadLine();
            string userInputUpper = userInput.ToUpper();

            while (!InventoryItem.ContainsKey(userInputUpper))
            {
                Console.WriteLine();
                PrintInventory();
                Console.WriteLine($"Current Balance: ${balance}");
                Console.WriteLine("INVALID INPUT");
                Console.Write("Please select again: ");
                userInput = Console.ReadLine();
                userInputUpper = userInput.ToUpper();
            }

            if (InventoryItem[userInputUpper].Product.Price > balance)
            {
                Console.Clear();
                Console.WriteLine();
                PrintInventory();
                Console.WriteLine($"Current Balance: ${balance}");
                Console.WriteLine("INSUFFICIENT FUNDS");
                Console.Write("Press any key to return to the Purchase Menu.");
                Console.ReadKey(true);
                return balance;
            }
            else
            {
                if (InventoryItem[userInputUpper].Quantity > 0)
                {
                    InventoryItem[userInputUpper].DecrementQuantity();
                    balance -= InventoryItem[userInputUpper].Product.Price;

                    Console.WriteLine();
                    Console.WriteLine($"{InventoryItem[userInputUpper].Product.Name} | " +
                        $"${InventoryItem[userInputUpper].Product.Price} | ${balance} | " +
                        $"{InventoryItem[userInputUpper].Product.Message}");
                    Console.WriteLine();

                    log.SelectProductLog(userInputUpper, InventoryItem[userInputUpper].Product, balance);

                    Console.Write("Press any key to return to the Purchase Menu.");
                    Console.ReadKey(true);

                    return balance;
                }
                else
                {
                    Console.WriteLine();
                    Console.WriteLine("OUT OF STOCK");
                    Console.WriteLine();
                    Console.Write("Press any key to return to the Purchase Menu.");
                    Console.ReadKey(true);
                    return balance;
                }
            }
        }

        public decimal FinishTransaction(decimal balance)
        {
            int quarters = 0;
            int dimes = 0;
            int nickels = 0;

            log.GiveChangeLog(balance);

            while (balance > 0)
            {
                if (balance >= .25M)
                {
                    balance -= .25M;
                    quarters++;
                }
                else if (balance <= .24M && balance > .09M)
                {
                    balance -= .10M;
                    dimes++;
                }
                else if (balance == .05M)
                {
                    balance -= .05M;
                    nickels++;
                }
            }

            if (quarters >= 1 || dimes >= 1 || nickels >= 1)
            {
                Console.Clear();
                Console.WriteLine("--- Finish Transaction ---");
                Console.WriteLine();
                Console.WriteLine("Here is your change!");
                Console.WriteLine();

                if (quarters > 0)
                {
                    Console.WriteLine("Ca-CHING");
                    Console.WriteLine($"{quarters} Quarters");
                    Console.WriteLine();
                }
                if (dimes > 0)
                {
                    Console.WriteLine("Pa-PING");
                    Console.WriteLine($"{dimes} Dimes");
                    Console.WriteLine();
                }
                if (nickels > 0)
                {
                    Console.WriteLine("Plunk-Plunk");
                    Console.WriteLine($"{nickels} Nickels");
                    Console.WriteLine();
                }

                Console.WriteLine("Thank you! Enjoy!");
                Console.WriteLine();
                Console.Write("Press any key to return to the Main Menu.");
                Console.ReadKey(true);
                Console.WriteLine();

                return balance;
            }
            else
            {
                Console.Clear();
                Console.WriteLine("--- Finish Transaction ---");
                Console.WriteLine();
                Console.WriteLine("No change to dispense.");
                Console.WriteLine();
                Console.Write("Press any key to return to the Main Menu.");
                Console.ReadKey(true);
                Console.WriteLine();

                return balance;
            }
        }
    }
}
