using Microsoft.AspNetCore.Mvc;
using System.Net;
using Fuel.Price.Qld.Models;
using AutoMapper;
using MediatR;
using Fuel.Price.Qld.Messages;

namespace fuel.price.qld.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class BrandController : ControllerBase
    {
        public BrandController(IMapper mapper, IMediator mediator)
        {
            Mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
            Mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
        }

        public IMapper Mapper { get; }
        public IMediator Mediator { get; }

        [HttpGet]
        [Route("lookup/{keyword}")] // TODO: should be refactored to "clubs" like the ref impl
        [ProducesResponseType(typeof(ValidationProblemDetails), (int)HttpStatusCode.BadRequest)]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        public async Task<IActionResult> BrandLookup(string keyword)
        {
            IActionResult result;

            keyword = keyword.ToLower();

            var request = new GetBrandSearchRequest
            {
                BrandKeyword = keyword
            };
            /* validate the request */
            if (!TryValidateModel(request))
            {
                result = ValidationProblem();
            }
            else
            {
                try
                {
                    /* send a query to the mediator & wait for the response */
                    var mapped = Mapper.Map<GetBrandQuery>(request);
                    GetBrandSearchResponse response = await Mediator.Send(mapped);
                    if(response == null)
                    {
                        result = NotFound();
                    }
                    result = Ok(response);
                }
                catch (Exception ex)
                {
                    result = StatusCode((int)HttpStatusCode.InternalServerError, ex.Message);
                }
            }
            return result;
        }
        [HttpGet]
        [Route("allbrands")] // TODO: should be refactored to "clubs" like the ref impl
        [ProducesResponseType(typeof(ValidationProblemDetails), (int)HttpStatusCode.BadRequest)]
        [ProducesResponseType((int)HttpStatusCode.NoContent)]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        public async Task<IActionResult> GetAllClubs()
        {
            IActionResult result;
            try
            {
                var request = new GetAllBrandSearchRequest();
                request.AllBrands= true;

                /* validate the request */
                if (!TryValidateModel(request))
                {
                    result = ValidationProblem();
                }
                var mapped = Mapper.Map<GetAllBrandsQuery>(request);
                List<GetBrandSearchResponse> response = await Mediator.Send(mapped);
                result = Ok(response);
            }
            catch (Exception ex)
            {
                result = StatusCode((int)HttpStatusCode.InternalServerError, ex.Message);
            }
            return result;
        }
    }        
}