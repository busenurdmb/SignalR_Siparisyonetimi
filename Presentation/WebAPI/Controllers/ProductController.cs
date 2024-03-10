using Application.Features.Mediator.Products.Commands.Create;
using Application.Features.Mediator.Products.Commands.Delete;
using Application.Features.Mediator.Products.Commands.Update;
using Application.Features.Mediator.ProductsWithCategoriess.Queries.GetProductsWithCategoriessWithCategories;
using Application.Products.Mediator.Products.Commands.Create;
using Application.Products.Mediator.Products.Commands.Update;
using Application.Products.Mediator.Products.Queries.GetById;
using Application.Products.Mediator.Products.Queries.GetList;
using MediatR;

using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IMediator _mediator;

        public ProductController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> ProductList()
        {
            var values = await _mediator.Send(new GetListProductQuery());

            return Ok(values);
        }
        [HttpGet("GetProductsWithCategories")]
        public async Task<IActionResult> GetProductsWithCategories()
        {
            var values = await _mediator.Send(new GetListProductsWithCategoriesQuery());

            return Ok(values);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetProduct(int id)
        {
            GetByIdProductQuery getByIdProduct = new() { Id = id };

            var value = await _mediator.Send(getByIdProduct);
            return Ok(value);
        }


        [HttpPost]
        public async Task<IActionResult> Add(CreatedProductCommand createdProductCommand)
        {
            CreatedProductResponse response = await _mediator.Send(createdProductCommand);
            return Ok(response);
        }

        [HttpPut]
        public async Task<IActionResult> Update(UpdatedProductCommand updateProductCommand)
        {
            UpdatedProductResponse response = await _mediator.Send(updateProductCommand);

            return Ok(response);
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            DeletedProductCommand deletedProductCommand = new() { Id = id };
            DeletedProductResponse response = await _mediator.Send(deletedProductCommand);

            return Ok(response);
        }
    }
}
