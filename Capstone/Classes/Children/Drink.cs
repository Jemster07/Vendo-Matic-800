using Capstone.Classes.Parents;
using System;
using System.Collections.Generic;
using System.Text;

namespace Capstone.Classes.Children
{
    public class Drink : Product
    {
        public Drink(string name, decimal price, string type, string message = "Glug Glug, Yum!")
            : base(name, price, type, message) { }
    }
}
