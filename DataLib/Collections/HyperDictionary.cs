using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;

namespace DataLib.Collections
{
    public class HyperDictionary<TKey, TValue> : IEnumerable<System.Collections.Generic.KeyValuePair<ITuple, TValue>>
    {
        public int Dimensions { get; }
        public KeyComparer<TKey> KeyComparer { get; }

        Dictionary<ITuple, TValue> _dictionary;

        public HyperDictionary(int dimensions, IEqualityComparer<TKey> keyComparer = null)
        {
            if (dimensions < 1)
                throw new ArgumentException("Dimensions must be >0", nameof(dimensions));
            Dimensions = dimensions;
            KeyComparer = new KeyComparer<TKey>(keyComparer ?? EqualityComparer<TKey>.Default);
            _dictionary = new Dictionary<ITuple, TValue>((IEqualityComparer<ITuple>) KeyComparer);
        }

        public void Add(TValue value, params TKey[] keys)
        {
            if (keys.Length != Dimensions)
                throw new ArgumentException("Key number must match dimensions", nameof(keys));

            _dictionary.Add(CreateTuple(keys), value);
        }

        public TValue this[params TKey[] keys]
        {
            get
            {
                if (keys.Length != Dimensions)
                    throw new ArgumentException("Key number must match dimensions", nameof(keys));
                return _dictionary[CreateTuple(keys)];
            }
            set 
            {
                if (keys.Length != Dimensions)
                    throw new ArgumentException("Key number must match dimensions", nameof(keys));
                _dictionary[CreateTuple(keys)] = value;
            }
        }

        public bool ContainsKey(params TKey[] keys)
        {
            if (keys.Length != Dimensions)
                throw new ArgumentException("Key number must match dimensions", nameof(keys));

            return _dictionary.ContainsKey(CreateTuple(keys));
        }

        public int Count => _dictionary.Count;
        public void Clear() => _dictionary.Clear();

        ITuple CreateTuple(params TKey[] keys)
        {
            switch (keys.Length)
            {
                case 1:
                    return ValueTuple.Create(keys[0]);
                case 2:
                    return ValueTuple.Create(keys[0], keys[1]);
                case 3:
                    return ValueTuple.Create(keys[0], keys[1], keys[2]);
                case 4:
                    return ValueTuple.Create(keys[0], keys[1], keys[2], keys[3]);
                case 5:
                    return ValueTuple.Create(keys[0], keys[1], keys[2], keys[3], keys[4]);
                case 6:
                    return ValueTuple.Create(keys[0], keys[1], keys[2], keys[3], keys[4], keys[5]);
                case 7:
                    return ValueTuple.Create(keys[0], keys[1], keys[2], keys[3], keys[4], keys[5], keys[6]);
                case 8:
                    return ValueTuple.Create(keys[0], keys[1], keys[2], keys[3], keys[4], keys[5], keys[6], keys[7]);

                default:
                    throw new Exception("Too many dimensions: " + keys.Length);
            }
        }

        public IEnumerator<KeyValuePair<ITuple, TValue>> GetEnumerator()
        {
            foreach (var item in _dictionary)
                yield return new KeyValuePair<ITuple, TValue>(item.Key, item.Value);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}