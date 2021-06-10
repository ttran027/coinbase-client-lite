using CoinbaseClientLite.Models;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace CoinbaseClientLite
{
    public class CoinbaseClient
    {
        private readonly HttpClient _http;
        public string ApiUrl { get; set; }
        public CoinbaseClient(HttpClient client)
        {
            _http = client;
        }

        public async Task<Price> GetPrice(string from, string to, PriceType type)
        {
            if (string.IsNullOrEmpty(ApiUrl))
            {
                throw new Exception("ApiUrl must not be null. Please set ApiUrl with no trailing forward slash.");
            }
            var requestPath = $"{ApiUrl}/prices/{from}-{to}/{type.ToString().ToLower()}";
            var response = await _http.GetAsync(requestPath);
            var price = await response.GetObject<PriceResponse>();
            return price.ToPrice(from, type, DateTime.UtcNow);
        }

        public async Task<string> GetTime(TimeType type)
        {
            var requestPath = $"{ApiUrl}/time";
            var response = await _http.GetAsync(requestPath);
            var time = await response.GetObject<TimeResponse>();
            return type == TimeType.ISO ? time.Data.Iso : time.Data.Epoch.ToString();
        }

        public async Task<CurrencyReponse> GetCurrencies()
        {
            var response = await _http.GetAsync($"{ApiUrl}/currencies");
            return await response.GetObject<CurrencyReponse>();
        }

        public async Task<ExchangeRate> GetExchangeRates(string ticker)
        {
            var response = await _http.GetAsync($"{ApiUrl}/exchange-rates?currency={ticker}");
            var data = await response.GetObject<ExchangeRateResponse>();
            return data.Data;
        }
    }
}
