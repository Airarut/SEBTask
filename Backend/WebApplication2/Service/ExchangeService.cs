using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;
using System.Web;
using WebApplication2.DTO;
using WebApplication2.Helpers;
using WebApplication2.Infrastructure;

namespace WebApplication2.Service
{
    public class ExchangeService : IExchangeService
    {
        private readonly IHttpManager _httpManager;

        public ExchangeService(IHttpManager httpManager)
        {
            _httpManager = httpManager;
        }

        public async Task<ExchangesDto> GetExchanges(DateTime date)
        {
            ExchangesDto exchangesDto = new ExchangesDto();
            exchangesDto.CurrencyInformation = new List<CurrencyDto>();
            exchangesDto.BaseCurrency = "USD";

            var currentDateApiResponse = await _httpManager.GetHistoricalRatesAsync(date, exchangesDto.BaseCurrency);
            var previousDateApiResponse = await _httpManager.GetHistoricalRatesAsync(date.AddDays(-1), exchangesDto.BaseCurrency);

            if (currentDateApiResponse?.Rates == null || previousDateApiResponse.Rates == null)
                return null;

            foreach (var rate in currentDateApiResponse.Rates)
            {
                if (previousDateApiResponse.Rates.TryGetValue(rate.Key, out double previousDateCurrencyRate))
                {
                    CurrencyDto currencyDto = new CurrencyDto();
                    currencyDto.CurrencyShortCode = rate.Key;
                    currencyDto.CurrentDateRate = rate.Value;
                    currencyDto.PreviousDateRate = previousDateCurrencyRate;
                    currencyDto.ChangeOfRate = ExchangeRateHelper.CompareCurrencyRates(currencyDto.CurrentDateRate, currencyDto.PreviousDateRate);
                    exchangesDto.CurrencyInformation.Add(currencyDto);
                }
            }
            return exchangesDto;
        }
    }
}
