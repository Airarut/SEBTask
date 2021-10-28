using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication2.DTO
{
    public class ExchangeApiDto
    {
        public string Base { get; set; }

        public IDictionary<string, double> Rates { get; set; }
    }
}
