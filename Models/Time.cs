using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoinbaseClientLite.Models
{
    public class Time
    {
        public string Iso { get; set; }
        public int Epoch { get; set; }
    }

    public class TimeResponse
    {
        public Time Data { get; set; }
    }
}
