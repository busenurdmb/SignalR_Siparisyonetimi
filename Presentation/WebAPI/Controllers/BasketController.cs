using Application.Features.Mediator.Baskets.Commands.Create;
using Application.Features.Mediator.Baskets.Commands.Delete;
using Application.Features.Mediator.Baskets.Commands.Update;
using Application.Features.Mediator.Baskets.Queries.BasketListByMenuTableWithProductName;
using Application.Features.Mediator.Baskets.Queries.GetBasketByMenuTableNumber;
using Application.Features.Mediator.Baskets.Queries.GetById;
using Application.Features.Mediator.Baskets.Queries.GetList;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BasketController : ControllerBase
    {
        private readonly IMediator _mediator;

        public BasketController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> BasketList()
        {
            var values = await _mediator.Send(new GetListBasketQuery());

            return Ok(values);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetBasket(int id)
        {
            GetByIdBasketQuery getByIdBasket = new() { Id = id };

            var value = await _mediator.Send(getByIdBasket);
            return Ok(value);
        }
        //[HttpGet("Basket/{id}")]
        [HttpGet("GetBasketByMenuTableID")]
        public async Task<IActionResult> GetBasketByMenuTableID(int id)
        {

            var values =await _mediator.Send(new GetBasketByMenuTableNumberQuery(id));
            return Ok(values);
        }
        [HttpGet("BasketListByMenuTableWithProductName")]
        public async Task<IActionResult> BasketListByMenuTableWithProductName(int id)
        {

            var values =await  _mediator.Send(new BasketListByMenuTableWithProductNameQuery(id));
            return Ok(values);
        }
        [HttpPost]
        public async Task<ActionResult> Add(CreatedBasketCommand createdBasketCommand)
        {
            CreatedBasketResponse response =await _mediator.Send(createdBasketCommand);
            return Ok(response);
        }


        [HttpPut]
        public async Task<IActionResult> Update(UpdateBasketCommand updateBasketCommand)
        {
            UpdateBasketResponse response = await _mediator.Send(updateBasketCommand);

            return Ok(response);
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            DeleteBasketResponse response = await _mediator.Send(new DeleteBasketCommand(id));

            return Ok(response);
        }
    }
}
