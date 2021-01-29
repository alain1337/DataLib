using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;

namespace DataLib.Collections
{
    public class KeyComparer<T> : IEqualityComparer<ITuple>
    {
        public KeyComparer(IEqualityComparer<T> comparer = null)
        {
            Comparer = comparer ?? EqualityComparer<T>.Default;
        }

        public IEqualityComparer<T> Comparer { get; }

        public bool Equals(ITuple x, ITuple y)
        {
            if (x == null && y == null)
                return true;
            if (x == null || y == null)
                return false;
            if (x.Length != y.Length)
                return false;
            for (var i=0; i < x.Length; i++)
                if (!x[i].Equals(y[i]))
                    return false;
            return true;
        }

        public int GetHashCode(ITuple obj)
        {
            // https://stackoverflow.com/a/1646913
            // Possibly use HashCode.Combine()
            
            var v = 17;
            unchecked
            {
                for (var i = 0; i < obj.Length; i++)
                    v = v * 31 + obj[i].GetHashCode();
            }
            return v;
        }
    }
}
