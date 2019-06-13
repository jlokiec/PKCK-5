using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataModel
{
    public class Price
    {
        public Price()
        {

        }
        public Price(double value, string currency)
        {
            Value = value;
            Currency = currency;
        }

        public double Value { get; set; }
        public string Currency { get; set; }

        public override string ToString()
        {
            return Value + " " + Currency;
        }
    }

}
