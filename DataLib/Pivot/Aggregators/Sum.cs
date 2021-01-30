using System;
using System.Collections.Generic;
using System.Text;
using DataLib.Numerics;

namespace DataLib.Pivot.Aggregators
{
    public class Sum : IAggregator
    {
        public void Add(object v)
        {
            if (!NumericTypes.Instance.IsSupported(v))
                return;
            Count++;
            Value = NumericTypes.Instance.Add(Value, v);
        }

        public int Count { get; private set; }
        public object Value { get; private set; } = NumericTypes.Instance.GetDefaultValue(NumericTypes.SupportedTypes[0]);
    }
}
