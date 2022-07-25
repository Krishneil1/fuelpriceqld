using AutoMapper;
using Fuel.Price.Qld.Messages;
using Fuel.Price.Qld.Models;

namespace Fuel.Price.Qld
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<GetBrandSearchRequest, GetBrandQuery>();
            CreateMap<Brand, GetBrandSearchResponse>();
            CreateMap<GetAllBrandSearchRequest, GetAllBrandsQuery>();            
        }
    }
}
