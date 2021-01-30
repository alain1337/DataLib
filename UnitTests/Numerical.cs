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
        }
    }
}
