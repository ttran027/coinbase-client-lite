using System.Collections.Generic;

namespace CoinbaseClientLite.Models
{
    public class Currency
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Min_size { get; set; }
    }

    public class CurrencyReponse
    {
        public IEnumerable<Currency> Data { get; set; }
    }
   
}