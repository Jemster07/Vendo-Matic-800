using Capstone.Classes.Parents;
using System;
using System.Collections.Generic;
using System.Text;

namespace Capstone.Classes.Children
{
    public class Gum : Product
    {
        public Gum(string location, string name, decimal price, string type, string message = "Chew Chew, Yum!")
            : base(location, name, price, type, message) { }
    }
}
