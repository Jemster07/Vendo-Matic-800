﻿using Capstone.Classes;
using Capstone.Classes.Parents;
using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.IO;
using System.Security.Cryptography.X509Certificates;
using System.Text;

namespace Capstone
{
    public class Logging
    {
        string filePath = ".\\Data\\log.txt";
        
        // TODO: Remove constructor if the log should NOT reset upon exit

        //public Logging()
        //{
        //    using StreamWriter sw = new StreamWriter(filePath, false) { };
        //}

        public void FeedMoneyLog(string insertedMoney, decimal balance)
        {
            using (StreamWriter sw = new StreamWriter(filePath, true))
            {
                sw.WriteLine($"{DateTime.Now.ToString("MM/dd/yyyy hh:mm:ss tt")} FEED MONEY ${insertedMoney}.00 ${balance}");
            }
        }

        public void SelectProductLog(string slot, Product product, decimal balance)
        {
            using (StreamWriter sw = new StreamWriter(filePath, true))
            {
                sw.WriteLine($"{DateAndTime.Now.ToString("MM/dd/yyyy hh:mm:ss tt")} {product.Name} {slot} ${product.Price} ${balance}");
            }
        }

        public void GiveChangeLog(decimal balance)
        {
            using (StreamWriter sw = new StreamWriter(filePath, true))
            {
                sw.WriteLine($"{DateTime.Now.ToString("MM/dd/yyyy hh:mm:ss tt")} GIVE CHANGE ${balance} $0.00");
            }
        }    
    }
}
