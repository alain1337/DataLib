using System;
using System.Collections.Generic;
using System.Text;
using DataLib.Numerics;
using DataLib.Numerics.Operations;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTests
{
    [TestClass]
    public class Numerical
    {
        [TestMethod]
        public void Basics()
        {
            object a = (byte)1;
            object b = (int)2;

            Assert.AreEqual(typeof(int), NumericTypes.Instance.MakeSame(ref a, ref b));
            Assert.AreEqual(typeof(int), a.GetType());
            Assert.AreEqual(typeof(int), b.GetType());
            Assert.AreEqual(1, a);
            Assert.AreEqual(2, b);
        }

        [TestMethod]
        public void Aritmetic()
        {
            object a = (byte)120;
            object b = (int)30;

            Assert.AreEqual(150, NumericTypes.Instance.Add(a, b));
            Assert.AreEqual(typeof(int), NumericTypes.Instance.Add(a, b).GetType());
            Assert.AreEqual(90, NumericTypes.Instance.Sub(a, b));
            Assert.AreEqual(3600, NumericTypes.Instance.Mul(a, b));
            Assert.AreEqual(4, NumericTypes.Instance.Div(a, b));

            Assert.AreEqual(0, NumericTypes.Instance.Compare(a, a));
            Assert.AreEqual(1, NumericTypes.Instance.Compare(a, b));
            Assert.AreEqual(-1, NumericTypes.Instance.Compare(b, a));
        }

        [TestMethod]
        public void AllTypes()
        {
            object[] valuesA = { (byte)12, (short)12, (int)12, (long)12, (float)12, (double)12, (decimal)12 };
            object[] valuesB = { (byte)4, (short)4, (int)4, (long)4, (float)4, (double)4, (decimal)4 };

            foreach (var valA in valuesA)
                foreach (var valB in valuesB)
                {
                    Assert.AreEqual(0, NumericTypes.Instance.Compare(16, NumericTypes.Instance.Add(valA, valB)));
                    Assert.AreEqual(0, NumericTypes.Instance.Compare(8, NumericTypes.Instance.Sub(valA, valB)));
                    Assert.AreEqual(0, NumericTypes.Instance.Compare(48, NumericTypes.Instance.Mul(valA, valB)));
                    Assert.AreEqual(0, NumericTypes.Instance.Compare(3, NumericTypes.Instance.Div(valA, valB)));
                }
        }
    }
}
