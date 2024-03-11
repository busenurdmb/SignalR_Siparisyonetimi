using Application.Features.Mediator.MenuTables.Queries.GetMenuTableCount;
using Application.Repositories;
using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Mediator.MenuTables.Queries.GetMenuTableCount
{
    
    public class GetMenuTableCountQuery : IRequest<GetMenuTableCountResponse>
    {
        public class GetMenuTableCountQueryHandler : IRequestHandler<GetMenuTableCountQuery, GetMenuTableCountResponse>
        {
            private readonly IMenuTableRepository _MenuTableRepository;
            private readonly IMapper _mapper;

            public GetMenuTableCountQueryHandler(IMenuTableRepository MenuTableRepository, IMapper mapper)
            {
                _MenuTableRepository = MenuTableRepository;
                _mapper = mapper;
            }

            public async Task<GetMenuTableCountResponse> Handle(GetMenuTableCountQuery request, CancellationToken cancellationToken)
            {
                int MenuTable = _MenuTableRepository.MenuTableCount();

                return _mapper.Map<GetMenuTableCountResponse>(MenuTable);
            }
        }
    }
}
