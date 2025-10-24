using MMABooksBusinessClasses;
using MMABooksDBClasses;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace MMABooksTests
{
    public class ProductDBTests
    {
        [Test]
        public void TestGetProduct()
        {
            //gets product in collum 1
            Product p = ProductDB.GetProduct("A4CS");
            //checks that product code has expected value
            Assert.AreEqual("A4CS", p.ProductCode);
        }

        [Test]
        public void TestCreateProduct()
        {
            Product p = new Product();
            p.ProductCode = "aaaa";
            p.Description = "gnome catcher";
            p.UnitPrice = 1;
            p.OnHandQuantity = 100;

            string testProductCode = ProductDB.AddProduct(p);
            p = ProductDB.GetProduct("aaaa");
            Assert.AreEqual("gnome catcher", p.Description);
        }
    }
}
