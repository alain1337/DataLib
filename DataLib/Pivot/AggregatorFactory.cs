using System;
using System.Collections.Generic;
using System.Text;

namespace DataLib.Pivot
{
    public class AggregatorFactory : IAggregatorFactory
    {
        public AggregatorFactory(Type type)
        {
            Type = type;
        }

        public Type Type { get; }

        public IAggregator Create()
        {
            return (IAggregator)Activator.CreateInstance(Type);
        }
    }
}
