using AutoMapper;
using Fuel.Price.Qld.Messages;
using Fuel.Price.Qld.Service;
using MediatR;
using Microsoft.Extensions.Logging;

namespace Fuel.Price.Qld.Handlers
{
    public class GetBrandSearchHandler : IRequestHandler<GetBrandQuery, GetBrandSearchResponse>
    {
        public ILogger Logger { get; }
        public IBrandSearchService BrandSearchService { get; }
        public IMapper Mapper { get; }
        public GetBrandSearchHandler(ILogger<GetBrandSearchHandler> logger, IBrandSearchService brandSearchService, IMapper mapper)
        {
            Logger = logger ?? throw new ArgumentNullException(nameof(logger));
            BrandSearchService = brandSearchService ?? throw new ArgumentNullException(nameof(brandSearchService));
            Mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }
        public async Task<GetBrandSearchResponse> Handle(GetBrandQuery query, CancellationToken cancellationToken)
        {
            Logger.LogInformation($"***[Elastic Search]*** I have handled the GetBrandQuery for {query.BrandKeyword}");
            try 
            {
                Models.Brand brand = await BrandSearchService.GetBrand(query.BrandKeyword);
                var mapped = Mapper.Map<GetBrandSearchResponse>(brand);
                return mapped;
            }
            catch (Exception ex) { 
                Logger.LogError(ex, $"***[Elastic Search]*** I have handled the GetBrandQuery for {query.BrandKeyword}"); 
                throw; 
            }    
        }
    }
}
