using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication2.DTO;
using WebApplication2.Service;

namespace WebApplication2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ExchangeController : Controller
    {
        private readonly IExchangeService _exchangeService;

        public ExchangeController(IExchangeService exchangeService)
        {
            _exchangeService = exchangeService;
        }

        [HttpGet("{date}")]
        public async Task<ExchangesDto> GetExchangesAsync(DateTime date)
        {
            var response = await _exchangeService.GetExchanges(date);

            return response;
        }
    }
}
