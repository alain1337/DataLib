using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataLib.Numerics
{
    public static class NumericTypes
    {
        public static Type[] SupportedTypes { get; } = 
        { 
            typeof(byte), 
            typeof(Int16), 
            typeof(Int32), 
            typeof(Int64), 
            typeof(float), 
            typeof(double), 
            typeof(decimal) 
        };

        public static Dictionary<Type, int> TypeMap { get; } = new Dictionary<Type, int>();

        public static object Upgrade(object n, Type toType)
        {
            var si = GetTypeIndex(n);
            var ti = GetTypeIndex(toType);
            if (si > ti)
                throw new Exception("Cannot upgrade to lesser type");
            return si != ti ? Convert.ChangeType(n, Type.GetTypeCode(SupportedTypes[ti])) : n;
        }

        public static bool MakeSame(ref object a, ref object b)
        {
            var ta = GetTypeIndex(a);
            var tb = GetTypeIndex(b);
            if (ta == tb)
            {
                return false;
            }
            else if (ta > tb)
            {
                b = Upgrade(b, SupportedTypes[ta]);
                return true;
            }
            else
            {
                a = Upgrade(a, SupportedTypes[tb]);
                return true;
            }
        }

        static int GetTypeIndex(object o)
        {
            return GetTypeIndex(o.GetType());
        }

        static int GetTypeIndex(Type t)
        {
            if (!TypeMap.ContainsKey(t))
                throw new Exception("Unsupported type: " + t.Name);
            return TypeMap[t];
        }

        static NumericTypes()
        {
            for (var i = 0; i < SupportedTypes.Length; i++)
                TypeMap.Add(SupportedTypes[i], i);
        }
    }
}
