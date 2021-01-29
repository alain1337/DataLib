using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Reflection;

namespace DataLib.Poco
{
    public class PocoAdapter
    {
        public Type AdaptedType { get; }
        public string[] FieldNames { get; }
        public Type[] FieldTypes { get; }
        
        internal IReadOnlyDictionary<string, int> OrdinalMap { get; }
        internal Func<object, object>[] Getters { get; }

        public PocoAdapter(Type adaptedType)
        {
            AdaptedType = adaptedType;
            // TODO: Support fields too
            var members = adaptedType.GetMembers()
                .Where(mi => (mi.MemberType == MemberTypes.Property && adaptedType.GetProperty(mi.Name).CanRead) || mi.MemberType == MemberTypes.Field)
                .ToList();
            
            FieldNames = members.Select(mi => mi.Name).ToArray();
            FieldTypes = new Type[FieldNames.Length];
            var om = new Dictionary<string, int>(StringComparer.OrdinalIgnoreCase);
            Getters = new Func<object, object>[FieldNames.Length];
            for (var i = 0; i < FieldNames.Length; i++)
            {
                om.Add(FieldNames[i], i);
                switch (members[i].MemberType)
                {
                    case MemberTypes.Property:
                        var prop = adaptedType.GetProperty(FieldNames[i]);
                        FieldTypes[i] = prop.PropertyType;
                        Getters[i] = o => prop.GetValue(o);
                        break;
                    case MemberTypes.Field:
                        var field = adaptedType.GetField(FieldNames[i]);
                        FieldTypes[i] = field.FieldType;
                        Getters[i] = o => field.GetValue(o);
                        break;
                    default:
                        throw new Exception("Duh, selection was crap");
                }
            }
            OrdinalMap = (IReadOnlyDictionary<string, int>) om;

        }

        public IDataRecord ToRecord(object o) => new PocoRecord(this, o);
    }
}
