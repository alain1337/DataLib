using System;
using System.Collections.Generic;
using System.Text;

namespace UnitTests
{
    public class TestPoco
    {
        public string Foo { get; set; }
        public int Bar { get; set; }
        public bool Baz;

        public string WriteOnly
        {
            set { ; }
        }

        public double? Nullable { get; set; }
        public double? NullableNull { get; set; }
    }
}
