using Capstone.Classes.Parents;
using System;
using System.Collections.Generic;
using System.Text;

namespace Capstone.Classes
{
    public class UI
    {
        public void CallUI()
        {
            bool endProgram = false;
            bool loopPurchaseMenu = false;
            decimal balance = 0.00M;
            VendingMachine instanceVendingMachine = new VendingMachine(balance);

            // Main Menu

            while (!endProgram)
            {
                Console.Clear();
                Console.WriteLine("Welcome to the Vendo-Matic 800!");
                Console.WriteLine();
                Console.WriteLine("--- Main Menu ---");
                Console.WriteLine();
                Console.WriteLine("[1] Display Vending Machine Items");
                Console.WriteLine("[2] Purchase");
                Console.WriteLine("[3] Exit");
                Console.WriteLine();
                Console.Write("Please make a selection: ");

                string userInput = Console.ReadLine();

                while (userInput == null)
                {
                    Console.Clear();
                    Console.WriteLine("Welcome to the Vendo-Matic 800!");
                    Console.WriteLine();
                    Console.WriteLine("[UNIT TYPE INVALID]");
                    Console.WriteLine();
                    Console.WriteLine("[1] Display Vending Machine Items");
                    Console.WriteLine("[2] Purchase");
                    Console.WriteLine("[3] Exit");
                    Console.WriteLine();
                    Console.Write("Please select again: ");

                    userInput = Console.ReadLine();
                }

                string userInputLower = userInput.ToLower();

                while (userInputLower != "display vending machine items"
                    && userInputLower != "purchase" && userInputLower != "exit"
                    && userInputLower != "1" && userInputLower != "2" && userInputLower != "3"
                    && userInputLower != "[1]" && userInputLower != "[2]" && userInputLower != "[3]")
                {
                    Console.Clear();
                    Console.WriteLine("Welcome to the Vendo-Matic 800!");
                    Console.WriteLine();
                    Console.WriteLine("[UNIT TYPE INVALID]");
                    Console.WriteLine();
                    Console.WriteLine("[1] Display Vending Machine Items");
                    Console.WriteLine("[2] Purchase");
                    Console.WriteLine("[3] Exit");
                    Console.WriteLine();
                    Console.Write("Please select again: ");

                    userInput = Console.ReadLine();
                    userInputLower = userInput.ToLower();
                }

                if (userInputLower == "display vending machine items" || userInputLower == "1" || userInputLower == "[1]")
                {
                    instanceVendingMachine.PrintInventory();
                    Console.Write("Press any key to return to the Purchase Menu.");
                    Console.ReadKey(true);
                    Console.WriteLine();
                }
                else if (userInputLower == "Purchase" || userInputLower == "2" || userInputLower == "[2]")
                {
                    loopPurchaseMenu = true;
                }
                else //Exit
                {
                    Console.Clear();
                    Console.WriteLine("Thank you for using the Vendo-Matic 800!");
                    Console.WriteLine();
                    Console.WriteLine("Shutting down...");
                    Console.WriteLine();
                    endProgram = true;
                }


                // Purchase Menu

                while (loopPurchaseMenu)
                {
                    Console.Clear();
                    Console.WriteLine("Welcome to the Vendo-Matic 800!");
                    Console.WriteLine();
                    Console.WriteLine("--- Purchase Menu ---");
                    Console.WriteLine();
                    Console.WriteLine("[1] Feed Money");
                    Console.WriteLine("[2] Select Product");
                    Console.WriteLine("[3] Finish Transaction");
                    Console.WriteLine();
                    Console.Write("Please make a selection: ");

                    string input = Console.ReadLine();
                    string lowerInput = input.ToLower();

                    while (lowerInput != "1" && lowerInput != "[1]" && lowerInput != "feed money"
                        && lowerInput != "2" && lowerInput != "[2]" && lowerInput != "select product"
                        && lowerInput != "3" && lowerInput != "[3]" && lowerInput != "finish transaction")
                    {
                        Console.Clear();
                        Console.WriteLine("Welcome to the Vendo-Matic 800!");
                        Console.WriteLine();
                        Console.WriteLine("[UNIT TYPE INVALID]");
                        Console.WriteLine();
                        Console.WriteLine("[1] Feed Money");
                        Console.WriteLine("[2] Select Product");
                        Console.WriteLine("[3] Finish Transaction");
                        Console.WriteLine();
                        Console.Write("Please select again: ");


                        input = Console.ReadLine();
                        lowerInput = input.ToLower();
                    }

                    if (lowerInput == "1" || lowerInput == "[1]" || lowerInput == "feed money")
                    {
                        balance += instanceVendingMachine.FeedMoney(balance);
                    }
                    else if (lowerInput == "2" || lowerInput == "[2]" || lowerInput == "select product")
                    {
                        balance = instanceVendingMachine.SelectProduct(balance);
                    }
                    else //Finish Transaction
                    {
                        balance = instanceVendingMachine.FinishTransaction(balance);
                        //balance = 0.00M;
                        loopPurchaseMenu = false;
                    }
                }
            }
        }
    }
}
