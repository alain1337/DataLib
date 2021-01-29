using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DataLib;
using DataLib.Poco;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTests
{
    [TestClass]
    public class Reader
    {
        [TestMethod]
        public void Basics()
        {
            var objects = Enumerable.Range(0, 10).Select(i => new TestPoco { Foo = "#" + i, Bar = i }).ToList();
            var reader = new PocoReader(objects);
            for (var i = 0; i < objects.Count; i++)
            {
                Assert.IsTrue(reader.Read());
                Assert.AreEqual("#" + i, reader["foo"]);
                Assert.AreEqual(i, reader["bar"]);
            }

            Assert.IsFalse(reader.Read());
            Assert.AreEqual(objects.Count - 1, reader["bar"]);
        }
    }
}
