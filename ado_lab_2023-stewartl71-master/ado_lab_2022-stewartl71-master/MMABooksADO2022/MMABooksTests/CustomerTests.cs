using System;
using System.Collections.Generic;
using System.Text;

using NUnit.Framework;
using MMABooksBusinessClasses;

namespace MMABooksTests
{
    [TestFixture]
    public class CustomerTests
    {
        private Customer def;
        private Customer c;

        [SetUp]
        
        public void SetUp()
        {
            def = new Customer();
            c = new Customer(1, "Donald, Duck", "101 Main Street", "Orlando", "FL", "10001");
        }

        [Test]
        public void TestConstructors() 
        { 
            Assert.IsNotNull(def);
            Assert.AreEqual(null, def.Name);
            Assert.AreEqual(null, def.Address);
            Assert.AreEqual(null, def.City);
            Assert.AreEqual(null, def.State);
            Assert.AreEqual(null, def.ZipCode);

            Assert.IsNotNull(c);
            Assert.AreNotEqual(null, def.Name);
            Assert.AreEqual("Donald, Duck", c.Name);
            Assert.AreEqual(null, def.Address);
            Assert.AreEqual(null, def.City);
            Assert.AreEqual(null, def.State);
            Assert.AreEqual(null, def.ZipCode);
        }

        [Test]
        public void TestNameSetter()
        {
            c.Name = "Dasie, Duck";
            Assert.AreNotEqual(c.Name, "Donald, Duck");
            Assert.AreEqual(c.Name, "Dasie, Duck");
        }

        [Test]
        public void TestSettersNameTooLong()
        {
            Assert.Throws<ArgumentOutOfRangeException>(()=> c.Name = "12345678901234567890123456789012345678901234567890123456789012345678901234567890123456789012345678901234567890");
        }
    }
}
