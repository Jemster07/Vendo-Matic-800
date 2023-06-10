using Capstone.Classes.Parents;
using System;
using System.Collections.Generic;
using System.Text;

namespace Capstone.Classes.Children
{
    public class Candy : Product
    {
        public Candy(string name, decimal price, string type, string message = "Crunch Crunch, Yum!")
            : base(name, price, type, message) { }
    }
}
