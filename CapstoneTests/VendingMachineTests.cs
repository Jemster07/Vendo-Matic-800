using Capstone.Classes;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;

namespace CapstoneTests
{
    [TestClass]
    public class VendingMachineTests
    {
        [TestMethod]
        public void SelectProduct_HappyPath()
        {
            decimal balance = 20.00M;
            
            VendingMachine sut = new VendingMachine(balance);

            //decimal expected = 

            //decimal actual = sut.SelectProduct(balance);

            //CollectionAssert.AreEqual(expected, actual);
        }
    }
}
