using Capstone.Classes.Parents;
using System;
using System.Collections.Generic;
using System.Text;

namespace Capstone.Classes
{
    public class MainMenu
    {
        public void CallMainMenu()
        {
            CurrentInventory VendingMachine = new CurrentInventory();
            Dictionary<string, Product> inventory = VendingMachine.GenerateInventory();
            Dictionary<string, int> stock = VendingMachine.GenerateStock();

            // Create log file            

            bool endProgram = false;

            while (!endProgram)
            {
                Console.WriteLine("Welcome to the Vendo-Matic 800!");
                Console.WriteLine();
                Console.WriteLine("Please make a selection:");
                Console.WriteLine("[1] Display Vending Machine Items");
                Console.WriteLine("[2] Purchase");
                Console.WriteLine("[3] Exit");
                Console.WriteLine();

                string userInput = Console.ReadLine();

                while (userInput == null)
                {
                    Console.WriteLine();
                    Console.WriteLine("[UNIT TYPE INVALID]");
                    Console.WriteLine();
                    Console.WriteLine("Please Select Again");
                    Console.WriteLine("[1] Display Vending Machine Items");
                    Console.WriteLine("[2] Purchase");
                    Console.WriteLine("[3] Exit");
                    Console.WriteLine();

                    userInput = Console.ReadLine();
                }

                string userInputLower = userInput.ToLower();

                while (userInputLower != "display vending machine items"
                    && userInputLower != "purchase" && userInputLower != "exit"
                    && userInputLower != "1" && userInputLower != "2" && userInputLower != "3"
                    && userInputLower != "[1]" && userInputLower != "[2]" && userInputLower != "[3]")
                {
                    Console.WriteLine();
                    Console.WriteLine("[UNIT TYPE INVALID]");
                    Console.WriteLine();
                    Console.WriteLine("Please Select Again");
                    Console.WriteLine("[1] Display Vending Machine Items");
                    Console.WriteLine("[2] Purchase");
                    Console.WriteLine("[3] Exit");
                    Console.WriteLine();

                    userInput = Console.ReadLine();
                    userInputLower = userInput.ToLower();
                }

                if (userInputLower == "display vending machine items" || userInputLower == "1" || userInputLower == "[1]")
                {
                    VendingMachine.PrintInventory();
                    Console.WriteLine();
                }
                else if (userInputLower == "Purchase" || userInputLower == "2" || userInputLower == "[2]")
                {
                    //PurchaseMenu purchaseMenu = new PurchaseMenu();
                    //purchaseMenu.CallPurchaseMenu();
                }
                else //Exit
                {
                    Console.WriteLine();
                    Console.Write("Thank you for using the Vendo-Matic 800!");

                    Console.ReadKey(true);
                    endProgram = true;
                }
            }
        }
    }
}
