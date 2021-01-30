using System;
using System.Collections.Generic;
using System.Text;
using DataLib.Numerics;

namespace DataLib.Pivot.Aggregators
{
    public class Average : IAggregator
    {
        public void Add(object v)
        {
            if (!NumericTypes.Instance.IsSupported(v))
                return;
            Count++;
            _sum = Convert.ToDouble(NumericTypes.Instance.Add(_sum, v));
        }

        public int Count { get; private set; }
        public object Value => Count > 0 ? _sum / Count : 0.0;

        double _sum = 0.0;
    }
}
