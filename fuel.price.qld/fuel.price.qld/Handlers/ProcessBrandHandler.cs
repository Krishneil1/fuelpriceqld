using Fuel.Price.Qld.Db;
using Fuel.Price.Qld.Models;
using Fuel.Price.Qld.Options;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System.Security.Cryptography;
using System.Text;
using Brand = Fuel.Price.Qld.Db.Brand;

namespace Fuel.Price.Qld.Handlers
{
    public class ProcessBrandHandler : AsyncRequestHandler<Models.Brand>
    {
        public ILogger Logger { get; }
        public HashAlgorithm HashAlgorithm { get; }
        public HashOptions HashOptions { get; }
        public FuelPriceQldDbContext FuelPriceQldDb { get; }
        public ProcessBrandHandler(
            ILogger<ProcessBrandHandler> logger,
            HashAlgorithm hashAlgorithm,
            IOptionsMonitor<HashOptions> hashOptionsMon,
            FuelPriceQldDbContext fuelPriceQldDb)
        {
            Logger = logger ?? throw new ArgumentNullException(nameof(logger));
            HashAlgorithm = hashAlgorithm ?? throw new ArgumentNullException(nameof(hashAlgorithm));
            HashOptions = hashOptionsMon?.CurrentValue ?? throw new ArgumentNullException(nameof(hashOptionsMon));
            FuelPriceQldDb = fuelPriceQldDb ?? throw new ArgumentNullException(nameof(fuelPriceQldDb));
        }
        protected override async Task Handle(Models.Brand brand, CancellationToken cancellationToken)
        {
            Logger.LogInformation($"I have processed brand {brand.BrandId}");

            /* compute a hash for this obj */
            string json = JsonConvert.SerializeObject(brand, new JsonSerializerSettings()
            {
                Converters = { new StringEnumConverter() }
            });

            byte[] hash = HashAlgorithm.ComputeHash(Encoding.Unicode.GetBytes(json + HashOptions.BrandSalt));

            string hashBase64 = Convert.ToBase64String(hash);

            /* get the previous hash for this obj from the DB */
            Brand dbBrand = await FuelPriceQldDb.Brands.SingleOrDefaultAsync(b => b.BrandId == brand.BrandId, cancellationToken: cancellationToken);

            /*
             * determine if this obj is new or updated, publish the obj & store the hash
             */
            if (dbBrand == null) // its new
            {

                /* store the hash in the DB */
                FuelPriceQldDb.Brands.Add(
                    new Brand
                    {
                        BrandId = brand.BrandId,
                        Name = brand.Name,
                        Hash = hashBase64
                    });

                await FuelPriceQldDb.SaveChangesAsync(cancellationToken);
            }
            else if(hashBase64 != dbBrand?.Hash) // its new
            {

                /* store the hash in the DB */
                dbBrand.Hash = hashBase64;

                await FuelPriceQldDb.SaveChangesAsync(cancellationToken);
            }            
        }
    }
}
