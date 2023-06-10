using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Channels;

namespace Capstone.Classes
{
    public class FeedMoney
    {
        public decimal Balance { get; private set; }

        public FeedMoney() { }

        public decimal CallFeedMoney(decimal balance)
        {
            {
                bool forward = true;
                while (forward)
                {
                    try
                    {
                        Loggin log = new Loggin();
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
                    }  catch
                    {
                        Console.WriteLine("WHOOPSIEE! Try again");
                    }


                }

            }
            return balance;

        }
    }
                    
                 


                    

                   


                
    
}

