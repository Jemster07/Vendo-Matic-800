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
        Dictionary<string, VendingMachineSlot> InventoryItem = new Dictionary<string, VendingMachineSlot>();
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
            foreach (KeyValuePair<string, VendingMachineSlot> slot in InventoryItem)
            {
                Console.WriteLine($"{slot.Key} | {slot.Value.Product.Name} | ${slot.Value.Product.Price} | {slot.Value.Product.Type}");
            }

            Console.WriteLine();
        }
        public decimal FeedMoney(decimal balance)
        {
            bool forward = true;
            while (forward)
            {
                try
                {
                    Logging log = new Logging();
                    Console.WriteLine();
                    Console.Write("Please Insert Money ($1,$5,$10,$20): ");
                    string insertedMoney = Console.ReadLine();
                    decimal moneyEntered = decimal.Parse(insertedMoney);

                    if (moneyEntered != 1.00M && moneyEntered != 5.00M && moneyEntered != 10.00M && moneyEntered != 20.00M)
                    {
                        Console.WriteLine("YOU EEEDIOT!!! Try Again");
                    }
                    if (moneyEntered == 1.00M || moneyEntered == 5.00M || moneyEntered == 10.00M || moneyEntered == 20.00M)
                    {
                        balance += moneyEntered;
                        Console.WriteLine($"Balance: {balance}");
                        log.FeedMoneyLog(insertedMoney, balance);
                        bool moreMoney = true;
                        while (moreMoney)
                        {
                            Console.Write("Would you like to add more money? (Y/N): ");
                            string keepGoing = Console.ReadLine().ToLower();
                            if (keepGoing != "y" && keepGoing != "n")
                            {
                                Console.WriteLine();
                                Console.WriteLine("YOU EEEDIOT!!! Try Again");
                            }

                            if (keepGoing == "y")
                            {
                                forward = true;
                                moreMoney = false;
                            }

                            if (keepGoing == "n")
                            {
                                moreMoney = false;
                                forward = false;
                                return balance;
                            }
                        }
                    }
                }
                catch
                {
                    Console.WriteLine("WHOOPSIEE! Try again");
                }
            }

            return balance;
        }
        public decimal SelectProduct(decimal balance)
        {
            Console.WriteLine();
            PrintInventory();
            Console.WriteLine();
            Console.Write("Select your product: ");
            string userInput = Console.ReadLine();
            string userInputUpper = userInput.ToUpper();

            while (!InventoryItem.ContainsKey(userInputUpper))
            {
                Console.WriteLine();
                PrintInventory();
                Console.WriteLine();
                Console.WriteLine("INVALID INPUT");
                Console.WriteLine();
                Console.Write("Select your product: ");
                userInput = Console.ReadLine();
                userInputUpper = userInput.ToUpper();
            }

            if (InventoryItem[userInputUpper].Product.Price > balance)
            {
                Console.WriteLine();
                Console.WriteLine("INSUFFICIENT FUNDS");
                Console.WriteLine();
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

                    Console.WriteLine($"{InventoryItem[userInputUpper].Product.Name}, " +
                        $"${InventoryItem[userInputUpper].Product.Price}, ${balance}, " +
                        $"{InventoryItem[userInputUpper].Product.Message}");

                    // TODO: Instantiate a new Logging object in VendingMachine so it can stay its own class
                    // call the method to log the transaction

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
            Logging log = new Logging();
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

            Console.WriteLine("Here is your change!");
            if (quarters > 0)
            {
                Console.WriteLine("Ca-CHING");
                Console.WriteLine($"{quarters} Quarters");
            }
            if (dimes > 0)
            {
                Console.WriteLine("Pa-PINGping");
                Console.WriteLine($"{dimes} Dimes");
            }
            if (nickels > 0)
            {
                Console.WriteLine("plunk-plunk");
                Console.WriteLine($"{nickels} Nickels");
            }
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine("Thank you! Enjoy!");
            Console.WriteLine();

            return balance;
        }
    }
}
