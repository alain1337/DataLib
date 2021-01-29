using System;
using DataLib;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTests
{
    [TestClass]
    public class Record
    {
        [TestMethod]
        public void Basics()
        {
            var poco = new TestPoco { Foo = "Foo", Bar = 42, Baz = true, Nullable = Math.PI };
            var adapter = new PocoAdapter(typeof(TestPoco));
            var record = new PocoRecord(adapter, poco);

            Assert.AreEqual("Foo", record["foo"]);
            Assert.AreEqual(42, record["bar"]);
            Assert.AreEqual(true, record["baz"]);
            Assert.ThrowsException<IndexOutOfRangeException>(() => record.GetOrdinal("WriteOnly"));
            Assert.ThrowsException<ArgumentException>(() => record["DoesntExist"]);
            Assert.AreEqual(Math.PI, record["Nullable"]);
            Assert.AreEqual(DBNull.Value, record["NullableNull"]);
        }

        [TestMethod]
        public void Shorthand()
        {
            var poco = new TestPoco { Foo = "Foo", Bar = 42, Baz = true };
            var record = new PocoRecord(poco);

            Assert.AreEqual("Foo", record["foo"]);
            Assert.AreEqual(42, record["bar"]);
            Assert.AreEqual(true, record["baz"]);
        }
    }
}
