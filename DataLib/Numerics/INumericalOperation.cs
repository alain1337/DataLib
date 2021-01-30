using System;
using System.Collections.Generic;
using System.Text;

namespace DataLib.Numerics
{
    public interface INumericalOperation
    {
        object Add(object a, object b);
        object Sub(object a, object b);
        object Mul(object a, object b);
        object Div(object a, object b);
        int Compare(object a, object b);
    }
}
