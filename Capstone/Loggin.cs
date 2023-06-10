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
    public class Loggin
    {
        string filePath = ".\\Data\\log.txt";

        public void FeedMoneyLog(string insertedMoney, decimal balance)
        {
            using (StreamWriter sw = new StreamWriter(filePath, true))
            {
                sw.WriteLine($"{DateTime.Now.ToString("MM/dd/yyyy hh:mm:ss tt")} FEED MONEY ${insertedMoney} ${balance}");
            }
        }

        public void SelectProductLog()
        {
            using (StreamWriter sw = new StreamWriter(filePath, true))
            {
                sw.WriteLine($"{DateAndTime.Now} //product and slot //product price //new balance");
            }
        }
        public void GiveChangeLog(decimal balance)
        {
            using (StreamWriter sw = new StreamWriter(filePath, true))
            {
                sw.WriteLine($"{DateTime.Now.ToString("MM/dd/yyyy hh:mm:ss tt")} GIVE CHANGE ${balance} $0");
            }
        }

            
    }
}
