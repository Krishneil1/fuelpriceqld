using Fuel.Price.Qld.Models;
using Newtonsoft.Json;
namespace Fuel.Price.Qld.Response
{
    public class BrandResponse
    {
        [JsonProperty("Brands")]
        public List<Brand> Brands { get; set; }
    }
}
