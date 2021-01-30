using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DataLib.Numerics.Operations;

namespace DataLib.Numerics
{
    public class NumericTypes : INumericalOperation
    {
        public static NumericTypes Instance { get; } = new NumericTypes();

        public Type[] SupportedTypes { get; } =
        {
            typeof(byte),
            typeof(Int16),
            typeof(Int32),
            typeof(Int64),
            typeof(float),
            typeof(double),
            typeof(decimal)
        };

        readonly Dictionary<Type, int> _typeMap = new Dictionary<Type, int>();
        readonly INumericalOperation[] _operations;

        public object Upgrade(object n, Type toType)
        {
            var si = GetTypeIndex(n);
            var ti = GetTypeIndex(toType);
            if (si > ti)
                throw new Exception("Cannot upgrade to lesser type");
            return si != ti ? Convert.ChangeType(n, Type.GetTypeCode(SupportedTypes[ti])) : n;
        }

        public Type MakeSame(ref object a, ref object b)
        {
            var ta = GetTypeIndex(a);
            var tb = GetTypeIndex(b);
            if (ta == tb)
            {
                return SupportedTypes[ta];
            }
            else if (ta > tb)
            {
                b = Upgrade(b, SupportedTypes[ta]);
                return SupportedTypes[ta];
            }
            else
            {
                a = Upgrade(a, SupportedTypes[tb]);
                return SupportedTypes[tb];
            }
        }

        int GetTypeIndex(object o)
        {
            return GetTypeIndex(o.GetType());
        }

        int GetTypeIndex(Type t)
        {
            if (!_typeMap.ContainsKey(t))
                throw new Exception("Unsupported type: " + t.Name);
            return _typeMap[t];
        }

        NumericTypes()
        {
            for (var i = 0; i < SupportedTypes.Length; i++)
                _typeMap.Add(SupportedTypes[i], i);
            _operations = SupportedTypes.Select(NumericalOperationsFactory.Get).ToArray();
            //_operations = SupportedTypes.Select(t => new Int32Operations()).ToArray();
        }

        public object Add(object a, object b)
        {
            return Invoke2(a, b, o => o.Add(a, b));
        }

        public object Sub(object a, object b)
        {
            return Invoke2(a, b, o => o.Sub(a, b));
        }

        public object Mul(object a, object b)
        {
            return Invoke2(a, b, o => o.Mul(a, b));
        }

        public object Div(object a, object b)
        {
            return Invoke2(a, b, o => o.Div(a, b));
        }

        object Invoke2(object a, object b, Func<INumericalOperation, object> function)
        {
            var t = GetTypeIndex(MakeSame(ref a, ref b));
            return function(_operations[t]);
        }
    }
}
