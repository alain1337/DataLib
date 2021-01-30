using System;
using System.Collections.Generic;
using System.Text;
using DataLib.Collections;
using DataLib.Pivot;
using DataLib.Pivot.Aggregators;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTests
{
    [TestClass]
    public class PivotTest
    {
        readonly HyperDictionary<string, int> _data;
        public PivotTest()
        {
            _data = new HyperDictionary<string, int>(2)
            {
                ["AMER", "Boston"] = 200,
                ["AMER", "Chicago"] = 130,
                ["AMER", "New York"] = 500,
                ["AMER", "Miami"] = 170,
                ["CH", "Bern"] = 50,
                ["CH", "Zürich"] = 80
            };
        }

        [TestMethod]
        public void Basics()
        {
            var pivot = new Pivot<string, int>(_data, new[] { "Counter" });
            Assert.AreEqual(_data.Count, pivot.GrandTotal[0].Value);

            pivot = new Pivot<string, int>(_data, new[] { "Sum" });
            Assert.AreEqual(1130, pivot.GrandTotal[0].Value);

            pivot = new Pivot<string, int>(_data, new[] { "Average" });
            Assert.AreEqual(188.33333m, Math.Round(Convert.ToDecimal(pivot.GrandTotal[0].Value), 5));

            pivot = new Pivot<string, int>(_data, new[] { "Median" });
            Assert.AreEqual(150m, Math.Round(Convert.ToDecimal(pivot.GrandTotal[0].Value), 5));
        }
    }
}
