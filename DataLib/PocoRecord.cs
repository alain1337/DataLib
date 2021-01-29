using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace DataLib
{
    public class PocoRecord : IDataRecord
    {
        public bool GetBoolean(int i)
        {
            return Get<bool>(i);
        }

        public byte GetByte(int i)
        {
            return Get<byte>(i);
        }

        public long GetBytes(int i, long fieldOffset, byte[] buffer, int bufferoffset, int length)
        {
            throw new NotImplementedException();
        }

        public char GetChar(int i)
        {
            return Get<char>(i);
        }

        public long GetChars(int i, long fieldoffset, char[] buffer, int bufferoffset, int length)
        {
            throw new NotImplementedException();
        }

        public IDataReader GetData(int i)
        {
            throw new NotImplementedException();
        }

        public string GetDataTypeName(int i)
        {
            return Adapter.FieldTypes[i].Name;
        }

        public DateTime GetDateTime(int i)
        {
            return Get<DateTime>(i);
        }

        public decimal GetDecimal(int i)
        {
            return Get<decimal>(i);
        }

        public double GetDouble(int i)
        {
            return Get<double>(i);
        }

        public Type GetFieldType(int i)
        {
            return Adapter.FieldTypes[i];
        }

        public float GetFloat(int i)
        {
            return Get<float>(i);
        }

        public Guid GetGuid(int i)
        {
            return Get<Guid>(i);
        }

        public short GetInt16(int i)
        {
            return Get<short>(i);
        }

        public int GetInt32(int i)
        {
            return Get<int>(i);
        }

        public long GetInt64(int i)
        {
            return Get<long>(i);
        }

        public string GetName(int i)
        {
            return Adapter.FieldNames[i];
        }

        public int GetOrdinal(string name)
        {
            var i = TryGetOrdinal(name);
            return i >= 0 ? i : throw new IndexOutOfRangeException("Field not found: " + name);
        }

        int TryGetOrdinal(string name)
        {
            return Adapter.OrdinalMap.TryGetValue(name, out var i) ? i : -1;
        }

        public string GetString(int i)
        {
            return Get<string>(i);
        }

        public object GetValue(int i)
        {
            return Get<object>(i);
        }

        public int GetValues(object[] values)
        {
            var i = 0;
            for (; i < Math.Min(values.Length, Adapter.FieldNames.Length); i++)
                values[i] = Adapter.Getters[i](_object);
            return i;
        }

        T Get<T>(int i)
        {
            var o = Adapter.Getters[i](_object);
            if (o == null || o.GetType() != Adapter.FieldTypes[i])
                throw new InvalidCastException($"Cannot cast {o.GetType().Name} to {Adapter.FieldTypes[i].Name} ({Adapter.FieldNames[i]})");
            return (T)o;
        }

        object Get(int i)
        {
            return Adapter.Getters[i](_object) ?? DBNull.Value;
        }

        public bool IsDBNull(int i)
        {
            return Adapter.Getters[i](_object) == null;
        }

        public int FieldCount => Adapter.FieldNames.Length;

        public object this[int i] => GetValue(i);

        public object this[string name]
        {
            get
            {
                var i = TryGetOrdinal(name);
                if (i < 0)
                    throw new ArgumentException("Field doesn't exist: " + name);
                return Get(i);
            }
        }

        public PocoAdapter Adapter { get; }
        readonly object _object;

        public PocoRecord(PocoAdapter adapter, object o)
        {
            if (o == null)
                throw new ArgumentNullException(nameof(o));
            if (!adapter.AdaptedType.IsInstanceOfType(o))
                throw new ArgumentException("Object must be of assignable type", nameof(o));

            Adapter = adapter;
            _object = o;
        }

        public PocoRecord(object o) : this(new PocoAdapter(o.GetType()), o)
        {
        }
    }
}
