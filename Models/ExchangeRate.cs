using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoinbaseClientLite.Models
{
    public class ExchangeRate
    {
        public string Currency { get; set; }
        public Dictionary<string, string> Rates { get; set; }
    }

    public class ExchangeRateResponse
    {
        public ExchangeRate Data { get; set; }
    }
}
