using MMABooksBusinessClasses;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace MMABooksTests
{
    [TestFixture]
    public class ProductTests
    {
        private Product def;
        private Product p;

        [SetUp]

        public void SetUp()
        {
            //set default constructor and overloaded constructor w/ values
            def = new Product();
            p = new Product("aaaa", "gnome tracker", 1.1, 100);
        }

        [Test]
        public void TestConstructors()
        {
            //checks default constructor to make sure all properties are null
            Assert.IsNotNull(def);
            Assert.AreEqual(null, def.ProductCode);
            Assert.AreEqual(null, def.Description);
            Assert.AreEqual(null, def.UnitPrice);
            Assert.AreEqual(null, def.OnHandQuantity);
            //checks overloaded construtor to make sure values are set to expected values
            Assert.IsNotNull(p);
            Assert.AreNotEqual(null, p.ProductCode);
            Assert.AreEqual("aaaa" , p.ProductCode);
            Assert.AreNotEqual(null, p.Description);
            Assert.AreEqual("gnome tracker", p.Description);
            Assert.AreNotEqual(null, p.UnitPrice);
            Assert.AreEqual(1.1, p.UnitPrice);
            Assert.AreNotEqual(null, p.OnHandQuantity);
            Assert.AreEqual(100, p.OnHandQuantity);
        }

        [Test]
        public void TestDescriptionSettet()
        {
            p.Description = "gnome containment";
            Assert.AreNotEqual(p.Description, "gnome tracker");
            Assert.AreEqual(p.Description, "gnome containment");
        }

        [Test]
        public void TestSettersDescriptionTooLong()
        {
            Assert.Throws<ArgumentOutOfRangeException>(() => p.Description = "12345678901234567890123456789012345678901234567890123456789012345678901234567890123456789012345678901234567890");
        }
    }
}
