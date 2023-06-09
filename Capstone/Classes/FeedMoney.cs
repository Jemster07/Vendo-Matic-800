using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Channels;

namespace Capstone.Classes
{
    public class FeedMoney
    {
        public decimal Balance { get; private set; }

        public FeedMoney()
        {
            //Balance = balance;
            //InsertedMoney = insertedMoney;
        }
        public decimal CallFeedMoney(decimal balance)
        {
            Console.WriteLine();
            Console.Write("Please Insert Money ($1,$5,$10,$20): ");
            string insertedMoney = Console.ReadLine();
            decimal moneyEntered = decimal.Parse(insertedMoney);

            while (moneyEntered != 1.00M && moneyEntered != 5.00M && moneyEntered != 10.00M && moneyEntered != 20.00M)
            {
                Console.WriteLine("YOU EEEDIOT!!! Try Again");
                Console.Write("Please Insert Money ($1,$5,$10,$20): ");
                insertedMoney = Console.ReadLine();
                moneyEntered = decimal.Parse(insertedMoney);
            }
           
            balance += moneyEntered;
            Console.WriteLine($"Balance: {balance}");
            Console.WriteLine("Would you like to add more money?");
            string keepGoing = Console.ReadLine().ToLower();
            
            while (keepGoing != "no" && keepGoing != "n")
            {   
                Console.WriteLine();
                Console.Write("Please Insert Money ($1,$5,$10,$20 or type '0' to return to purchase menu: ");
                insertedMoney = Console.ReadLine();
                
                if(insertedMoney == "0")
                {
                    return balance;
                }
                
                moneyEntered = decimal.Parse(insertedMoney);
                
                while (moneyEntered != 1.00M && moneyEntered != 5.00M && moneyEntered != 10.00M && moneyEntered != 20.00M)
                {
                    Console.WriteLine("YOU EEEDIOT!!! Try Again");
                    Console.Write("Please Insert Money ($1,$5,$10,$20): ");
                    insertedMoney = Console.ReadLine();
                    moneyEntered = decimal.Parse(insertedMoney);
                }

                balance += moneyEntered;
                Console.WriteLine($"Balance: {balance}");
                Console.WriteLine("Would you like to add more money?");
                keepGoing = Console.ReadLine().ToLower();
            }

            return balance;
        }
    }

   





}

