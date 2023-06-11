using Capstone.Classes.Parents;
using System;
using System.Collections.Generic;
using System.Text;

namespace Capstone.Classes.Children
{
    public class Chip : Parents.Product
    {
        public Chip(string name, decimal price, string type, string message = "Munch Munch, Yum!")
            : base(name, price, type, message) { }
    }
}
