using Fuel.Price.Qld.Models;
using Fuel.Price.Qld.Options;
using Fuel.Price.Qld.Response;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using System.Net;

namespace Fuel.Price.Qld.Service
{
    public class BrandService : IBrandService
    {
        public BrandService(ILogger<BrandService> logger, IOptionsMonitor<QueenslandGovAPIOptions> queenslandGovAPIOptionsMon)
        {
            Logger = logger ?? throw new ArgumentNullException(nameof(logger));
            QueenslandGovAPIOptions = queenslandGovAPIOptionsMon?.CurrentValue ?? throw new ArgumentNullException(nameof(queenslandGovAPIOptionsMon));
            _httpClient = new HttpClient();
        }

        public ILogger Logger { get; }
        public QueenslandGovAPIOptions QueenslandGovAPIOptions { get; }
        private readonly HttpClient _httpClient;
        public async Task<BrandResponse> GetBrands()
        {
            var _baseUrl = QueenslandGovAPIOptions.GetCountryBrands;
            try
            {
                var request = new HttpRequestMessage
                {
                    RequestUri = new Uri(_baseUrl),
                    Method = HttpMethod.Get,
                    Headers =
                    {
                        {
                            HttpRequestHeader.Authorization.ToString(),
                            QueenslandGovAPIOptions.FuelPricesQldGOVAUTH
                        },
                        {
                            HttpRequestHeader.ContentType.ToString(), "multipart/mixed"
                        } //use this content type if you want to send more than one content type

                    }
                };
                var response = _httpClient.SendAsync(request).Result;
                var content = await response.Content.ReadAsStringAsync();
                var result = JsonConvert.DeserializeObject<BrandResponse>(content);

                return result;
            }
            catch (Exception ex)
            {
                Logger.LogInformation($"Could not run Brand service:",ex.Message);
                throw;
            }
        }
    }
}
