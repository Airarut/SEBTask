using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication2.DTO;

namespace WebApplication2.Service
{
    public interface IExchangeService
    {
        public Task<ExchangesDto> GetExchanges(DateTime date);
    }
}
