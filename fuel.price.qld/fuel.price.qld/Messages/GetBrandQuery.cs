using MediatR;

namespace Fuel.Price.Qld.Messages
{
    public class GetBrandQuery : IRequest<GetBrandSearchResponse>
    {
        public string BrandKeyword { get; set; }
    }
}