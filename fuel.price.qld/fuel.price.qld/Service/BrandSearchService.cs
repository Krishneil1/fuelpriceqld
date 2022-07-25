using Fuel.Price.Qld.Db;
using Microsoft.EntityFrameworkCore;

namespace Fuel.Price.Qld.Service
{
    public class BrandSearchService : IBrandSearchService
    {
        public ILogger Logger { get; }
        public FuelPriceQldDbContext FuelPriceQldDb { get; }
        public BrandSearchService(ILogger<BrandSearchService> logger, FuelPriceQldDbContext fuelPriceQldDb)
        {
            Logger = logger ?? throw new ArgumentNullException(nameof(logger));
            FuelPriceQldDb = fuelPriceQldDb ?? throw new ArgumentNullException(nameof(fuelPriceQldDb));
        }
    
        public async Task<Models.Brand?> GetBrand(string keyword)
        {
            try
            {
                var brand = await FuelPriceQldDb.Brands.SingleOrDefaultAsync(b => b.Name.ToLower() == keyword.ToLower());
                if (brand != null)
                {
                    return new Models.Brand
                    {
                        BrandId = brand.BrandId,
                        Name = brand.Name
                    };
                }
                return null;
            }
            catch (Exception ex)
            {
                Logger.LogError(ex, "unexpected error");
                throw;
            }
        }

        public async Task<List<Models.Brand>> GetAllBrands()
        {
            var allBrand = await FuelPriceQldDb.Brands.ToListAsync();
            return allBrand.Select(b => new Models.Brand
            {
                BrandId = b.BrandId,
                Name = b.Name
            }).ToList();
        }
    }
}
