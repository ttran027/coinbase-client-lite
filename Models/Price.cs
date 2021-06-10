using System;

namespace CoinbaseClientLite.Models
{
    public class Price : BasePrice
    {       
        public string PriceFor { get; set; }
        public PriceType Type { get; set; }
        public DateTime TimeStamp { get; set; }
    }

    public class PriceResponse
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
