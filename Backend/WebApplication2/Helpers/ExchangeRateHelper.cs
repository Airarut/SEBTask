using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace WebApplication2.Helpers
{
    public static class ExchangeRateHelper
    {
        public static Uri FormatUrl(string baseUrl, DateTime date, IDictionary<string, string> queryParams)
        {
            var uriBuilder = new UriBuilder(baseUrl + date.ToString("yyyy-MM-dd") + ".json");

            var parameters = HttpUtility.ParseQueryString(uriBuilder.Query);

            foreach(var queryParam in queryParams)
            {
                parameters[queryParam.Key] = queryParam.Value;
            }

            uriBuilder.Query = parameters.ToString();

            return uriBuilder.Uri;
        }

        public static double? CompareCurrencyRates(double rate1, double rate2)
        {
            if(rate1 == 0 || rate2 == 0)
            {
                return null;
            }
            double result = (rate1 - rate2) / rate2 * 100;

            return Math.Round(result, 2);
        }
    }
}
