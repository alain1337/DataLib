using System;
using System.Collections.Generic;
using System.Text;

namespace DataLib.Pivot
{
    public static class AggregatorFactoryFactory
    {
        public static IAggregatorFactory Create<T>(string kind)
        {
            var type = Type.GetType("DataLib.Pivot.Aggregators." + kind) ?? throw new Exception("Unknown aggregator kind: " + kind);
            return new AggregatorFactory(type);
        }
    }
}
