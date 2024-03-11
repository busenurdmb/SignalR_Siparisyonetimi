using Application.Features.Mediator.MoneyCases.Queries;
using Application.Features.Mediator.Products.Queries.GetTotalPriceBySaladCategory;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MoneyCasesController : ControllerBase
    {
        private readonly IMediator _mediator;

        public MoneyCasesController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("TotalMoneyCase")]
        public async Task<IActionResult> TotalMoneyCase()
        {
            var values = await _mediator.Send(new GetTotalMoneyCaseAmountQuery());

            return Ok(values);
        }
    }
}
