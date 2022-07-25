using MediatR;

namespace Fuel.Price.Qld.Messages
{
    public class GetAllBrandsQuery : IRequest<List<GetBrandSearchResponse>>
    {
        public GetAllBrandsQuery()
        {
            AllBrands = false;
        }
        public bool AllBrands { get; set; }
    }
}
