using System;
using System.Collections.Generic;
using System.Text;

namespace DataLib.Numerics.Operations
{
    class ByteOperations : INumericalOperation
    {
        public object Add(object a, object b)
        {
            NumericTypes.Instance.MakeSame(ref a, ref b);
            return (byte)a + (byte)b;
        }

        public object Sub(object a, object b)
        {
            NumericTypes.Instance.MakeSame(ref a, ref b);
            return (byte)a - (byte)b;
        }

        public object Mul(object a, object b)
        {
            NumericTypes.Instance.MakeSame(ref a, ref b);
            return (byte)a * (byte)b;
        }

        public object Div(object a, object b)
        {
            NumericTypes.Instance.MakeSame(ref a, ref b);
            return (byte)a / (byte)b;
        }

        public int Compare(object a, object b)
        {
            NumericTypes.Instance.MakeSame(ref a, ref b);
            return ((byte)a).CompareTo(b);
        }
    }
}
