using System;
using System.Collections.Generic;
using System.Text;

namespace DataLib.Pivot.Aggregators
{
    public class Counter : IAggregator
    {
        public void Add(object v)
        {
            Count++;
        }

        public int Count { get; private set; }
        public object Value => Count;
    }
}