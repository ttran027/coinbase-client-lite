using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoinbaseClientLite
{
    public class Price : BasePrice
    {       
        public string PriceFor { get; set; }
        public PriceType Type { get; set; }
        public DateTime TimeStamp { get; set; }
    }

    internal class PriceResponse
    {
        public BasePrice Data { get; set; }

        public Price ToPrice(string priceFor, PriceType type, DateTime timeStamp)
        {
            return new Price
            {
                Amount = Data.Amount,
                Currency = Data.Currency,
                PriceFor = priceFor,
                Type = type,
                TimeStamp = timeStamp
            };
        }
    }

    public class BasePrice
    {
        public string Amount { get; set; }
        public string Currency { get; set; }
    }
}
