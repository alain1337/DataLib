using System;
using System.Collections.Generic;
using System.Text;

namespace DataLib.Pivot
{
    public interface IAggregator
    {
        void Add(object v);
        int Count { get; }
        object Value { get; }
    }
}
