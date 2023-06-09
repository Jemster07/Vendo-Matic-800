using System;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using System.Text;

namespace Capstone.Classes
{
    public class PurchaseMenu

    {
        decimal Balance { get; set; } = 0.00M;
        public PurchaseMenu(decimal balance)
        {
            Balance = balance;
        }
        public void CallPurchaseMenu()
        {
            

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
            }

            
        }
    }
}
