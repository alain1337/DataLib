using System;
using System.Collections.Generic;
using System.Text;
using DataLib.Numerics;
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
    }
}
