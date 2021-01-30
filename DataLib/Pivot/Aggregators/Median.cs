using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DataLib.Numerics;

namespace DataLib.Pivot.Aggregators
{
    public class Median : IAggregator
    {
        public void Add(object v)
        {
            if (!NumericTypes.Instance.IsSupported(v))
                return;
            Count++;
            _sum.Add(Convert.ToDecimal(v));
        }

        public int Count { get; private set; }
        public object Value
        {
            get
            {
                if (Count == 0)
                    return 0m;
                _sum = _sum.OrderBy(d => d).ToList();
                if (Count == 1)
                    return _sum.First();
                if (Count % 2 == 0)
                    return (_sum[Count / 2 - 1] + _sum[Count / 2]) / 2;
                else
                    return _sum[Count / 2];
            }
        }

        List<decimal> _sum = new List<decimal>();
    }
}
