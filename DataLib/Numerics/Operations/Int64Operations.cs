using System;
using System.Collections.Generic;
using System.Text;

namespace DataLib.Numerics.Operations
{
    class Int64Operations : INumericalOperation
    {
        public object Add(object a, object b)
        {
            NumericTypes.Instance.MakeSame(ref a, ref b);
            return (Int64)a + (Int64)b;
        }

        public object Sub(object a, object b)
        {
            NumericTypes.Instance.MakeSame(ref a, ref b);
            return (Int64)a - (Int64)b;
        }

        public object Mul(object a, object b)
        {
            NumericTypes.Instance.MakeSame(ref a, ref b);
            return (Int64)a * (Int64)b;
        }

        public object Div(object a, object b)
        {
            NumericTypes.Instance.MakeSame(ref a, ref b);
            return (Int64)a / (Int64)b;
        }

        public int Compare(object a, object b)
        {
            NumericTypes.Instance.MakeSame(ref a, ref b);
            return ((Int64)a).CompareTo(b);
        }
    }
}
