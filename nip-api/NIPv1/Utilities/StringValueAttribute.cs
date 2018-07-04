using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NIPv1.Utilities
{
    public class StringValueAttribute : System.Attribute
    {
        public StringValueAttribute(string value)
        {
            Value = value;
        }

        public string Value { get; }
    }
}