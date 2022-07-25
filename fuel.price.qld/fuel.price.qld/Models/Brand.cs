using MediatR;

namespace Fuel.Price.Qld.Models
{
    public class Brand: IRequest
    {
        public string Name { get; set; }
        public int BrandId { get; set; }
    }
}
