using Application.Features.Mediator.Categories.Queries.GetList;
using Application.Repositories;
using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Mediator.Contacts.Queries.GetList
{
    public class GetListContactQuery : IRequest<List<GetListContactResponse>>
    {
        public class GetListContactQueryHandler : IRequestHandler<GetListContactQuery, List<GetListContactResponse>>
        {
            private readonly IContactRepository _ContactRepository;
            private readonly IMapper _mapper;

            public GetListContactQueryHandler(IContactRepository ContactRepository, IMapper mapper)
            {
                _ContactRepository = ContactRepository;
                _mapper = mapper;
            }

            public async Task<List<GetListContactResponse>> Handle(GetListContactQuery request, CancellationToken cancellationToken)
            {
                var Contact = await _ContactRepository.GetAllAsync();
                return _mapper.Map<List<GetListContactResponse>>(Contact);
            }
        }
    }
}
