using Application.Features.Mediator.Categories.Commands.Create;
using Application.Features.Mediator.Categories.Commands.Delete;
using Application.Features.Mediator.Categories.Commands.Update;
using Application.Features.Mediator.Categories.Queries.GetActiveCatgeoryCount;
using Application.Features.Mediator.Categories.Queries.GetById;
using Application.Features.Mediator.Categories.Queries.GetProductCount;
using Application.Features.Mediator.Categories.Queries.GetList;
using Application.Features.Mediator.Categories.Queries.GetPassiveCatgeoryCount;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly IMediator _mediator;

        public CategoryController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> CategoryList()
        {
            var values = await _mediator.Send(new GetListCategoryQuery());

            return Ok(values);
        }
        [HttpGet("CategoryCount")]
        public async Task<IActionResult> CategoryCount()
        {
            var value = await _mediator.Send(new GetCategoryCountQuery());
            return Ok(value);
        }
        [HttpGet("CategoryActiveCount")]
        public async Task<IActionResult> CategoryActiveCount()
        {
            var value = await _mediator.Send(new GetActiveCategoryCountQuery());
            return Ok(value);
        }
        [HttpGet("CategoryPassiveCount")]
        public async Task<IActionResult> CategoryPassiveCount()
        {
            var value = await _mediator.Send(new GetPassiveCategoryCountQuery());
            return Ok(value);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetCategory(int id)
        {
            GetByIdCategoryQuery getByIdCategory = new() { Id = id };

            var value = await _mediator.Send(getByIdCategory);
            return Ok(value);
        }

        [HttpPost]
        public async Task<IActionResult> Add(CreatedCategoryCommand createdCategoryCommand)
        {
            CreatedCategoryResponse response = await _mediator.Send(createdCategoryCommand);
            return Ok(response);
        }

        [HttpPut]
        public async Task<IActionResult> Update(UpdatedCategoryCommand updateCategoryCommand)
        {
            UpdatedCategoryResponse response = await _mediator.Send(updateCategoryCommand);

            return Ok(response);
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            DeletedCategoryCommand deletedCategoryCommand = new() { Id = id };
            DeletedCategoryResponse response = await _mediator.Send(deletedCategoryCommand);

            return Ok(response);
        }
    }
}
