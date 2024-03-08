using Application.Features.Mediator.Categories.Queries.GetById;
using Application.Repositories;
using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Mediator.Contacts.Queries.GetById
{
    public class GetByIdContactQuery : IRequest<GetByIdContactResponse>
    {
        public int Id { get; set; }
        public class GetByIdContactQueryHandler : IRequestHandler<GetByIdContactQuery, GetByIdContactResponse>
        {
            private readonly IContactRepository _ContactRepository;
            private readonly IMapper _mapper;

            public GetByIdContactQueryHandler(IContactRepository ContactRepository, IMapper mapper)
            {
                _ContactRepository = ContactRepository;
                _mapper = mapper;
            }

            public async Task<GetByIdContactResponse> Handle(GetByIdContactQuery request, CancellationToken cancellationToken)
            {
                var Contact = await _ContactRepository.GetByFilterAsync(c => c.ContactID == request.Id);
                return _mapper.Map<GetByIdContactResponse>(Contact);
            }
        }

    }
}
