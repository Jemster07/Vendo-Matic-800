using System;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using System.Text;

namespace Capstone.Classes
{
    public class PurchaseMenu
    {
        public void CallPurchaseMenu()
        {
            decimal balance = 0.00M;
            bool keepRunning = true;

            while (keepRunning == true)
            {
                Console.WriteLine();
                Console.WriteLine("What Would You Like to Do?:");
                Console.WriteLine();
                Console.WriteLine("(1) Feed Money");
                Console.WriteLine("(2) Select Product");
                Console.WriteLine("(3) Finish Transaction");

                string input = Console.ReadLine();
                string lowerInput = input.ToLower();

                while (lowerInput != "1" && lowerInput != "(1)" && lowerInput != "feed money"
                    && lowerInput != "2" && lowerInput != "(2)" && lowerInput != "select product"
                    && lowerInput != "3" && lowerInput != "(3)" && lowerInput != "finish transaction")
                {
                    Console.WriteLine("WRONG!!!! Try Again Dummy...");
                    input = Console.ReadLine();
                    lowerInput = input.ToLower();
                }

                FeedMoney userBalance = new FeedMoney();
                if (lowerInput == "1" || lowerInput == "(1)" || lowerInput == "feed money")
                {
                    balance += userBalance.CallFeedMoney(balance);
                }

                FinishTransaction remainingBalance = new FinishTransaction();
                if (lowerInput == "3" || lowerInput == "(3)" || lowerInput == "finish transaction")
                {
                    remainingBalance.CallFinishTransaction(balance);
                    balance = 0.00M;
                    keepRunning = false;
                }
            }
        }
    }
}
