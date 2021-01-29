using System;
using System.Collections.Generic;
using System.Text;

namespace DataLib.Pivot
{
    public interface IAggregatorFactory
    {
        IAggregator Create();
    }
}
