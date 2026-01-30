namespace BitcoinServicePrice.Services
{
    using BitcoinServicePrice.Models;
    using System.Text.Json;

    public class CryptoService
    {
        private readonly IHttpClientFactory _factory;
        private readonly IConfiguration _config;

        public CryptoService(IHttpClientFactory factory, IConfiguration config)
        {
            _factory = factory;
            _config = config;
        }

        public async Task<object> GetPricesAsync(string symbol)
        {
            var btcUsd = await GetUsd(symbol);
            var rates = await GetRates();

            var usdToEur = btcUsd / rates["USD"];

            return new
            {
                Symbol = symbol,
                Prices = new
                {
                    USD = btcUsd,
                    EUR = usdToEur,
                    BRL = usdToEur * rates["BRL"],
                    GBP = usdToEur * rates["GBP"],
                    AUD = usdToEur * rates["AUD"]
                }
            };
        }

        private async Task<decimal> GetUsd(string symbol)
        {
            var client = _factory.CreateClient();
            var key = _config["ApiKeys:CoinMarketCap"];

            var req = new HttpRequestMessage(
                HttpMethod.Get,
                "https://pro-api.coinmarketcap.com/v1/cryptocurrency/quotes/latest?symbol="+symbol
            );

            req.Headers.Add("X-CMC_PRO_API_KEY", key);

            var res = await client.SendAsync(req);
            res.EnsureSuccessStatusCode();

            var json = await res.Content.ReadAsStringAsync();
            using var doc = JsonDocument.Parse(json);
            
            return doc.RootElement
                .GetProperty("data")
                .GetProperty(symbol.ToUpper())
                .GetProperty("quote")
                .GetProperty("USD")
                .GetProperty("price")
                .GetDecimal();
        }

        private async Task<Dictionary<string, decimal>> GetRates()
        {
            var client = _factory.CreateClient();
            var key = _config["ApiKeys:ExchangeRates"];

            var url =
                $"https://api.exchangeratesapi.io/v1/latest" +
                $"?access_key={key}" +
                $"&base=EUR" +
                $"&symbols=USD,BRL,GBP,AUD";

            var res = await client.GetAsync(url);
            res.EnsureSuccessStatusCode();

            var json = await res.Content.ReadAsStringAsync();
            var data = JsonSerializer.Deserialize<ExchangeRateResponse>(json);

            return data.Rates;
        }
    }
}
