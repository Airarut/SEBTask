using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;
using WebApplication2.DTO;
using WebApplication2.Helpers;

namespace WebApplication2.Infrastructure
{
    public class HttpManager : IHttpManager
    {
        private readonly HttpClient _httpClient;
        private readonly string _baseUrl = "https://openexchangerates.org/api/historical/";
        private readonly string _appId = "d6000446f7c24164a67fb9f075b179d1";

        public HttpManager(IHttpClientFactory clientFactory)
        {
            _httpClient = clientFactory.CreateClient();
        }

        public async Task<ExchangeApiDto> GetHistoricalRatesAsync(DateTime date, string baseCurrency)
        {
            var queryParams = new Dictionary<string, string>() 
            {
                { "app_id", _appId},
                { "base", baseCurrency }
            };

            var request = new HttpRequestMessage(HttpMethod.Get, ExchangeRateHelper.FormatUrl(_baseUrl, date, queryParams));
            var response = await _httpClient.SendAsync(request);

            if (response.IsSuccessStatusCode)
            {
                using var responseStream = await response.Content.ReadAsStreamAsync();
                return await JsonSerializer.DeserializeAsync<ExchangeApiDto>(responseStream, new JsonSerializerOptions { PropertyNameCaseInsensitive = true });
            }
            else
            {
                return null;
            }
        }
    }
}
