using System;
using System.Collections.Generic;
using System.Text;

namespace DataLib.Numerics.Operations
{
    static class NumericalOperationsFactory
    {
        public static INumericalOperation Get(Type type)
        {
            if (type == typeof(byte))
                return new ByteOperations();
            if (type == typeof(Int16))
                return new Int16Operations();
            if (type == typeof(Int32))
                return new Int32Operations();
            if (type == typeof(Int64))
                return new Int64Operations();
            if (type == typeof(float))
                return new FloatOperations();
            if (type == typeof(double))
                return new DoubleOperations();
            if (type == typeof(decimal))
                return new DecimalOperations();
            throw new Exception("No numerical operations class for type: " + type.Name);
        }
    }
}