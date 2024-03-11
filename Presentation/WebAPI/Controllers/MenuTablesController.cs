using Application.Features.Mediator.Features.MenuTables.Commands.Delete;
using Application.Features.Mediator.MenuTable.Commands.Update;
using Application.Features.Mediator.MenuTables.Commands.Create;
using Application.Features.Mediator.MenuTables.Queries.GetById;
using Application.Features.Mediator.MenuTables.Queries.GetList;
using Application.Features.Mediator.MenuTables.Queries.GetMenuTableCount;
using Application.MenuTables.Mediator.MenuTables.Commands.Create;
using Application.MenuTables.Mediator.MenuTables.Commands.Delete;
using Application.MenuTables.Mediator.MenuTables.Commands.Update;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MenuTablesController : ControllerBase
    {
        private readonly IMediator _mediator;

        public MenuTablesController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> MenuTableList()
        {
            var values = await _mediator.Send(new GetListMenuTableQuery());

            return Ok(values);
        }
        [HttpGet("MenuTableCount")]
        public async Task<IActionResult> MenuTableCount()
        {
            var value = await _mediator.Send(new GetMenuTableCountQuery());
            return Ok(value);
        }
      
        [HttpGet("{id}")]
        public async Task<IActionResult> GetMenuTable(int id)
        {
            GetByIdMenuTableQuery getByIdMenuTable = new() { Id = id };

            var value = await _mediator.Send(getByIdMenuTable);
            return Ok(value);
        }

        [HttpPost]
        public async Task<IActionResult> Add(CreatedMenuTableCommand createdMenuTableCommand)
        {
            CreatedMenuTableResponse response = await _mediator.Send(createdMenuTableCommand);
            return Ok(response);
        }

        [HttpPut]
        public async Task<IActionResult> Update(UpdatedMenuTableCommand updateMenuTableCommand)
        {
            UpdatedMenuTableResponse response = await _mediator.Send(updateMenuTableCommand);

            return Ok(response);
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            DeletedMenuTableCommand deletedMenuTableCommand = new() { Id = id };
            DeletedMenuTableResponse response = await _mediator.Send(deletedMenuTableCommand);

            return Ok(response);
        }
    }
}
