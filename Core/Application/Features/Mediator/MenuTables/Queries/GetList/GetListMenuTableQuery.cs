
using Application.Features.Mediator.MenuTables.Queries.GetList;
using Application.Repositories;
using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.MenuTables.Mediator.MenuTables.Queries.GetList
{
    public class GetListMenuTableQuery : IRequest<List<GetListMenuTableResponse>>
    {
        public class GetListMenuTableQueryHandler : IRequestHandler<GetListMenuTableQuery, List<GetListMenuTableResponse>>
        {
            private readonly IMenuTableRepository _MenuTableRepository;
            private readonly IMapper _mapper;

            public GetListMenuTableQueryHandler(IMenuTableRepository MenuTableRepository, IMapper mapper)
            {
                _MenuTableRepository = MenuTableRepository;
                _mapper = mapper;
            }

            public async Task<List<GetListMenuTableResponse>> Handle(GetListMenuTableQuery request, CancellationToken cancellationToken)
            {
                var MenuTable = await _MenuTableRepository.GetAllAsync();
                return _mapper.Map<List<GetListMenuTableResponse>>(MenuTable);
            }
        }
    }
}
