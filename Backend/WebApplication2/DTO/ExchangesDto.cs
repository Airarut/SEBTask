using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication2.DTO
{
    public class ExchangesDto
    {
        public string BaseCurrency { get; set; }

        public IList<CurrencyDto> CurrencyInformation { get; set; }
    }
    public class CurrencyDto
    {
        public string CurrencyShortCode { get; set; }

        public double? ChangeOfRate { get; set; }

        public double CurrentDateRate { get; set; }

        public double PreviousDateRate { get; set; }
    }
}
