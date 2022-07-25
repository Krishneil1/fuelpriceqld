using Fuel.Price.Qld.Response;

namespace Fuel.Price.Qld.Service
{
    public interface IBrandService
    {
        Task<BrandResponse> GetBrands();
    }
}
