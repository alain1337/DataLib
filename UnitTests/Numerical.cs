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

            Assert.IsTrue(NumericTypes.MakeSame(ref a, ref b));
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

            var op = new Int32Operations();
            Assert.AreEqual(150, op.Add(a, b));
            Assert.AreEqual(typeof(int), op.Add(a, b).GetType());
            Assert.AreEqual(90, op.Sub(a, b));
            Assert.AreEqual(3600, op.Mul(a, b));
            Assert.AreEqual(4, op.Div(a, b));
        }
    }
}
