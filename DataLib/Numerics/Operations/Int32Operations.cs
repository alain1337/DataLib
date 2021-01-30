using System;
using System.Collections.Generic;
using System.Text;

namespace DataLib.Numerics.Operations
{
    public class Int32Operations : INumericalOperation
    {
        public object Add(object a, object b)
        {
            NumericTypes.Instance.MakeSame(ref a, ref b);
            return (int) a + (int) b;
        }

        public object Sub(object a, object b)
        {
            NumericTypes.Instance.MakeSame(ref a, ref b);
            return (int)a - (int)b;
        }

        public object Mul(object a, object b)
        {
            NumericTypes.Instance.MakeSame(ref a, ref b);
            return (int)a * (int)b;
        }

        public object Div(object a, object b)
        {
            NumericTypes.Instance.MakeSame(ref a, ref b);
            return (int)a / (int)b;
        }

        public int Compare(object a, object b)
        {
            NumericTypes.Instance.MakeSame(ref a, ref b);
            return ((int) a).CompareTo(b);
        }
    }
}
