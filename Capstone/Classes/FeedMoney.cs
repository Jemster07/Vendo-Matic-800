using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Channels;

namespace Capstone.Classes
{
    public class FeedMoney : PurchaseMenu

    { public FeedMoney(decimal balance) : base(balance)
        {

        }
        public void CallFeedMoney()
        {


            Console.Write("Please Insert Money ($1,$5,$10,$20): ");
            string input = Console.ReadLine();
            while (input != "1" && input != "5" && input != "10" && input != "20")
            {
                Console.WriteLine("YOU EEEDIOT!!! Try Again");
                Console.Write("Please Insert Money ($1,$5,$10,$20): ");
                input = Console.ReadLine();

            }
            Console.WriteLine($"${input}");
        }





    }
}
