using System;
using System.Collections.Generic;
using System.Text;

namespace DataLib.Numerics.Operations
{
    class FloatOperations : INumericalOperation
    {
        public object Add(object a, object b)
        {
            NumericTypes.Instance.MakeSame(ref a, ref b);
            return (float)a + (float)b;
        }

        public object Sub(object a, object b)
        {
            NumericTypes.Instance.MakeSame(ref a, ref b);
            return (float)a - (float)b;
        }

        public object Mul(object a, object b)
        {
            NumericTypes.Instance.MakeSame(ref a, ref b);
            return (float)a * (float)b;
        }

        public object Div(object a, object b)
        {
            NumericTypes.Instance.MakeSame(ref a, ref b);
            return (float)a / (float)b;
        }

        public int Compare(object a, object b)
        {
            NumericTypes.Instance.MakeSame(ref a, ref b);
            return ((float)a).CompareTo(b);
        }
    }
}
