using Application.Features.Mediator.Contacts.Commands.Create;
using Application.Features.Mediator.Contacts.Commands.Delete;
using Application.Features.Mediator.Contacts.Commands.Update;
using Application.Features.Mediator.Contacts.Queries.GetById;
using Application.Features.Mediator.Contacts.Queries.GetList;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContactController : ControllerBase
    {
        private readonly IMediator _mediator;

        public ContactController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> ContactList()
        {
            var values = await _mediator.Send(new GetListContactQuery());

            return Ok(values);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetContact(int id)
        {
            GetByIdContactQuery getByIdContact = new() { Id = id };

            var value = await _mediator.Send(getByIdContact);
            return Ok(value);
        }

        [HttpPost]
        public async Task<IActionResult> Add(CreatedContactCommand createdContactCommand)
        {
            CreatedContactResponse response = await _mediator.Send(createdContactCommand);
            return Ok(response);
        }

        [HttpPut]
        public async Task<IActionResult> Update(UpdatedContactCommand updateContactCommand)
        {
            UpdatedContactResponse response = await _mediator.Send(updateContactCommand);

            return Ok(response);
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            DeletedContactCommand deletedContactCommand = new() { Id = id };
            DeletedContactResponse response = await _mediator.Send(deletedContactCommand);

            return Ok(response);
        }
    }
}
