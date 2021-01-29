using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DataLib.Collections;

namespace DataLib.Pivot
{
    public class Pivot<TKey, TValue>
    {
        IAggregatorFactory[] aggregatorFactories;

        public IAggregator[] GrandTotal { get; private set; }

        public Pivot(HyperDictionary<TKey, TValue> data,  IEnumerable<IAggregatorFactory> factories)
        {
            aggregatorFactories = factories.ToArray();
            Init(data);
        }

        public Pivot(HyperDictionary<TKey, TValue> data, IEnumerable<string> counters)
        {
            aggregatorFactories = counters.Select(AggregatorFactoryFactory.Create<TValue>).ToArray();
            Init(data);
        }

        void Init(HyperDictionary<TKey, TValue> data)
        {
            GrandTotal = aggregatorFactories.Select(f => f.Create()).ToArray();
            foreach (var kvp in data)
                foreach (var a in GrandTotal)
                    a.Add(kvp.Value);
        }
    }
}
