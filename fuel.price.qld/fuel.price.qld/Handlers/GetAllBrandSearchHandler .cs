using AutoMapper;
using Fuel.Price.Qld.Messages;
using Fuel.Price.Qld.Models;
using Fuel.Price.Qld.Service;
using MediatR;
using Microsoft.Extensions.Logging;

namespace Fuel.Price.Qld.Handlers
{
    public class GetAllBrandSearchHandler : IRequestHandler<GetAllBrandsQuery, List<GetBrandSearchResponse>>
    {
        public ILogger Logger { get; }
        public IBrandSearchService BrandSearchService { get; }
        public IMapper Mapper { get; }
        public GetAllBrandSearchHandler(ILogger<GetAllBrandSearchHandler> logger, IBrandSearchService brandSearchService, IMapper mapper)
        {
            Logger = logger ?? throw new ArgumentNullException(nameof(logger));
            BrandSearchService = brandSearchService ?? throw new ArgumentNullException(nameof(brandSearchService));
            Mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        public async Task<List<GetBrandSearchResponse>> Handle(GetAllBrandsQuery request, CancellationToken cancellationToken)
        {
            Logger.LogInformation($"***[Elastic Search]*** I have handled the Get All Brands");
            try
            {
                List<Models.Brand> allBrands= await BrandSearchService.GetAllBrands();
                var mapped = Mapper.Map<List<GetBrandSearchResponse>>(allBrands);
                return mapped;
            }
            catch (Exception ex)
            {
                Logger.LogError(ex, $"***[Elastic Search]*** I could not  Get All Brands");
                throw;
            }
        }
    }
}
