using System;
using System.Collections.Generic;
using System.Text;

namespace IoTMonitor.ValueTypes
{
    public class Temperature
    {
        public double? Value { get; }

        public Temperature(double? value)
        {
            Value = value;
        }
    }
}
