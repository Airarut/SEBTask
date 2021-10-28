using System;
using System.Threading.Tasks;
using WebApplication2.DTO;

namespace WebApplication2.Infrastructure
{
    public interface IHttpManager
    {
        public Task<ExchangeApiDto> GetHistoricalRatesAsync(DateTime date, string baseCurrency);
    }
}
