using Application.Features.Mediator.Categories.Commands.Delete;
using Application.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Mediator.Contacts.Commands.Delete
{
    public class DeletedContactCommand : IRequest<DeletedContactResponse>
    {
        public int Id { get; set; }

        public class DeletedContactCommandHandler : IRequestHandler<DeletedContactCommand, DeletedContactResponse>
        {
            private readonly IContactRepository _ContactRepository;
            private readonly IMapper _mapper;

            public DeletedContactCommandHandler(IContactRepository ContactRepository, IMapper mapper)
            {
                _ContactRepository = ContactRepository;
                _mapper = mapper;
            }

            public async Task<DeletedContactResponse> Handle(DeletedContactCommand request, CancellationToken cancellationToken)
            {
                Contact? Contact = await _ContactRepository.GetByFilterAsync(c => c.ContactID == request.Id);

                await _ContactRepository.RemoveAsync(Contact);

                return _mapper.Map<DeletedContactResponse>(Contact);

            }
        }
    }
}
