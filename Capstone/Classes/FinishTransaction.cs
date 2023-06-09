using System;
using System.Collections.Generic;
using System.Text;

namespace Capstone.Classes
{
    public class FinishTransaction
    {
        public decimal CallFinishTransaction(decimal balance)
        {
            int quarters = 0;
            int dimes = 0;
            int nickels = 0;
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
