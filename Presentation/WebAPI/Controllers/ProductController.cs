using Application.Features.Mediator.Categories.Commands.Create;
using Application.Features.Mediator.Categories.Commands.Delete;
using Application.Features.Mediator.Categories.Commands.Update;
using Application.Features.Mediator.Products.Queries.GetProductAvgPriceByHamburger;
using Application.Features.Mediator.Products.Queries.GetProductCountByCategoryNameDrink;
using Application.Features.Mediator.Products.Queries.GetProductCountByCategoryNameHamburger;
using Application.Features.Mediator.Products.Queries.GetProductNameByMaxPrice;
using Application.Features.Mediator.Products.Queries.GetProductNameByMinPrice;
using Application.Features.Mediator.Products.Queries.GetProductPriceAvg;
using Application.Features.Mediator.Products.Queries.GetProductPriceBySteakBurger;
using Application.Features.Mediator.Products.Queries.GetTotalPriceByDrinkCategory;
using Application.Features.Mediator.Products.Queries.GetTotalPriceBySaladCategory;
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
        [HttpGet("TotalPriceByDrinkCategory")]
        public async Task<IActionResult> TotalPriceByDrinkCategory()
        {
            var values = await _mediator.Send(new GetTotalPriceByDrinkCategoryQuery());

            return Ok(values);
          
        }

        [HttpGet("TotalPriceBySaladCategory")]
        public async Task<IActionResult> TotalPriceBySaladCategory()
        {
            var values = await _mediator.Send(new GetTotalPriceBySaladCategoryQuery());

            return Ok(values);
        }

        [HttpGet("ProductNameByMaxPrice")]
        public async Task<IActionResult> ProductNameByMaxPrice()
        {
            var values = await _mediator.Send(new GetProductNameByMaxPriceQuery());

            return Ok(values);
        }

        [HttpGet("ProductNameByMinPrice")]
        public async Task<IActionResult> ProductNameByMinPrice()
        {
            var values = await _mediator.Send(new GetProductNameByMinPriceQuery());

            return Ok(values);
        }

        [HttpGet("ProductAvgPriceByHamburger")]
        public async Task<IActionResult> ProductAvgPriceByHamburger()
        {
            var values = await _mediator.Send(new GetProductAvgPriceByHamburgerQuery());

            return Ok(values);
        }

        [HttpGet("ProductCountByHamburger")]
        public async Task<IActionResult> ProductCountByHamburger()
        {
            var values = await _mediator.Send(new GetProductCountByCategoryNameHamburgerQuery());

            return Ok(values);
        }

        [HttpGet("ProductCountByDrink")]
        public async Task<IActionResult> ProductCountByDrink()
        {
            var values = await _mediator.Send(new GetProductCountByCategoryNameDrinkQuery());

            return Ok(values);
        }

        [HttpGet("ProductPriceAvg")]
        public async Task<IActionResult> ProductPriceAvg()
        {
            var values = await _mediator.Send(new GetProductPriceAvgQuery());

            return Ok(values);
        }

        [HttpGet("ProductPriceBySteakBurger")]
        public async Task<IActionResult> ProductPriceBySteakBurger()
        {
            var values = await _mediator.Send(new GetProductPriceBySteakBurgerQuery());

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
