using Capstone.Classes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;

namespace Capstone
{
    class Program
    {
        static void Main(string[] args)
        {
            MainMenu VendingMachine = new MainMenu();
            VendingMachine.CallMainMenu();
        }
    }
}
