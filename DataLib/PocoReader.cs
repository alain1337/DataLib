using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace DataLib
{
    public class PocoReader : IDataRecord, IDataReader
    {
        public bool GetBoolean(int i)
        {
            return _record.GetBoolean(i);
        }

        public byte GetByte(int i)
        {
            return _record.GetByte(i);
        }

        public long GetBytes(int i, long fieldOffset, byte[] buffer, int bufferoffset, int length)
        {
            return _record.GetBytes(i, fieldOffset, buffer, bufferoffset, length);
        }

        public char GetChar(int i)
        {
            return _record.GetChar(i);
        }

        public long GetChars(int i, long fieldoffset, char[] buffer, int bufferoffset, int length)
        {
            return _record.GetChars(i, fieldoffset, buffer, bufferoffset, length);
        }

        public IDataReader GetData(int i)
        {
            throw new NotImplementedException();
        }

        public string GetDataTypeName(int i)
        {
            return _adapter.FieldTypes[i].Name;
        }

        public DateTime GetDateTime(int i)
        {
            return _record.GetDateTime(i);
        }

        public decimal GetDecimal(int i)
        {
            return _record.GetDecimal(i);
        }

        public double GetDouble(int i)
        {
            return _record.GetDouble(i);
        }

        public Type GetFieldType(int i)
        {
            return _adapter.FieldTypes[i];
        }

        public float GetFloat(int i)
        {
            return _record.GetFloat(i);
        }

        public Guid GetGuid(int i)
        {
            return _record.GetGuid(i);
        }

        public short GetInt16(int i)
        {
            return _record.GetInt16(i);
        }

        public int GetInt32(int i)
        {
            return _record.GetInt32(i);
        }

        public long GetInt64(int i)
        {
            return _record.GetInt64(i);
        }

        public string GetName(int i)
        {
            return _adapter.FieldNames[i];
        }

        public int GetOrdinal(string name)
        {
            return _adapter.OrdinalMap[name];
        }

        public string GetString(int i)
        {
            return _record.GetString(i);
        }

        public object GetValue(int i)
        {
            return _record.GetValue(i);
        }

        public int GetValues(object[] values)
        {
            return _record.GetValues(values);
        }

        public bool IsDBNull(int i)
        {
            return _record.IsDBNull(i);
        }

        public int FieldCount => _adapter.FieldNames.Length;

        public object this[int i] => _record[i];

        public object this[string name] => _record[name];

        public void Dispose()
        {
            Close();
        }

        public void Close()
        {
            _enumerator?.Dispose();
            _enumerator = null;
        }

        public DataTable GetSchemaTable()
        {
            throw new NotImplementedException();
        }

        public bool NextResult()
        {
            Close();
            return false;
        }

        public bool Read()
        {
            if (!_enumerator.MoveNext())
                return false;
            _record = new PocoRecord(_adapter, _enumerator.Current);
            return true;
        }

        public int Depth => 0;
        public bool IsClosed => _record != null;
        public int RecordsAffected => 0;

        readonly PocoAdapter _adapter;
        PocoRecord _record;
        IEnumerator<object> _enumerator;

        public PocoReader(PocoAdapter adapter, IEnumerable<object> objects)
        {
            _adapter = adapter;
            _enumerator = objects.GetEnumerator();
        }

        public PocoReader(IEnumerable<object> objects) : this(new PocoAdapter(objects.First().GetType()), objects)
        {
        }
    }
}
