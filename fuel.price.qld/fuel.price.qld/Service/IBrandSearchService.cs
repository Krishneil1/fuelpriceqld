using Fuel.Price.Qld.Models;

namespace Fuel.Price.Qld.Service
{
    public interface IBrandSearchService
    {
        Task<List<Brand>> GetAllBrands();
        Task<Brand> GetBrand(string keyword);
    }
}
