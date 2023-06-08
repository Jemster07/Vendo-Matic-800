using Capstone.Classes.Parents;
using System;
using System.Collections.Generic;
using System.Text;

namespace Capstone.Classes.Children
{
    public class Chip : Product
    {
        public Chip(string location, string name, decimal price, string type, string message = "Munch Munch, Yum!")
            : base(location, name, price, type, message) { }
    }
}
