using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DataLib.Collections;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTests
{
    [TestClass]
    public class Dictionary
    {
        [TestMethod]
        public void Basics()
        {
            var d = new HyperDictionary<string, int>(3)
            {
                { 1, "Foo", "Blah", "Blubb" },
                { 2, "Bar", "Blah", "Blubb" },
                { 3, "Baz", "Blah", "Blubb" }
            };

            Assert.AreEqual(1, d["Foo", "Blah", "Blubb"]);
            Assert.AreEqual(2, d["Bar", "Blah", "Blubb"]);
            Assert.AreEqual(3, d["Baz", "Blah", "Blubb"]);

            Assert.ThrowsException<ArgumentException>(() => d.Add(3, "Baz", "Blah", "Blubb"));
            d["Baz", "Blah", "Blubb"] = 4;
            Assert.AreEqual(4, d["Baz", "Blah", "Blubb"]);
            Assert.ThrowsException<KeyNotFoundException>(() => d["a", "b", "c"]);

            Assert.AreEqual(3, d.Count);
            d.Clear();
            Assert.AreEqual(0, d.Count);
        }

        [TestMethod]
        public void Iterator()
        {
            var d1 = new[] { "Foo", "Bar", "Baz" };
            var d2 = new[] { "One", "Two", "Three", "Four", "Five" };
            var d3 = new[] { "Monday", "Tuesday", "Wednesday", "Thursday", "Friday", "Saturnday", "Sunday" };

            var d = new HyperDictionary<string, int>(3);
            var v = 1;
            foreach (var k1 in d1)
                foreach (var k2 in d2)
                    foreach (var k3 in d3)
                        d[k1, k2, k3] = v++;

            var l = d1.Length * d2.Length * d3.Length;
            Assert.AreEqual(l, d.Count);
            var c = 0;
            foreach (var kvp in d)
                Assert.AreEqual(c++ + 1,kvp.Value);
            Assert.AreEqual(l, c);
            Assert.AreEqual(l, d[d1.Reverse().First(), d2.Reverse().First(), d3.Reverse().First()]);
        }
    }
}
