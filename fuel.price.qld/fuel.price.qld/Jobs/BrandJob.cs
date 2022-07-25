using Fuel.Price.Qld.Db;
using Fuel.Price.Qld.Service;
using Hangfire;
using MediatR;

namespace Fuel.Price.Qld.Jobs
{
    [DisableConcurrentExecution(3)] // <-- this is the amount of time it will wait to ACQUIRE the lock, NOT the amount of time before the lock expires!
    [AutomaticRetry(Attempts = 2, OnAttemptsExceeded = AttemptsExceededAction.Delete)] // because this is a stateless job that runs fairly frequently

    public class BrandJob
    {
        public BrandJob(ILogger<BrandJob> logger, IMediator mediator, IBrandService brandService)
        {
            Logger = logger ?? throw new ArgumentNullException(nameof(logger));
            Mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
            BrandService = brandService ?? throw new ArgumentNullException(nameof(brandService));
        }

        public ILogger Logger { get; }
        public IMediator Mediator { get; }
        public IBrandService BrandService { get; }
        public async Task Execute()
        {
            try
            {
                /* call the API & get a list of brands */
                var brands = BrandService.GetBrands();
                /*
                 * Process each brand.
                 */
                if (brands != null)
                {
                    foreach (var brand in brands.Result.Brands)
                    {
                        /* send to the mediator & wait for the response */
                        await Mediator.Send(brand);
                    }
                }
            }
            catch (Exception ex)
            {
                Logger.LogError(ex, "unexpected error");
                throw;
            }
        }
    }
}
