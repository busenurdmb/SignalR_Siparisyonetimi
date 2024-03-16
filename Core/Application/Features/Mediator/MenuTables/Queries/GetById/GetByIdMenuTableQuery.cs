using Application.Features.Mediator.MenuTables.Queries.GetById;

using Application.Repositories;
using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Menus.Mediator.MenuTables.Queries.GetById
{
    public class GetByIdMenuTableQuery : IRequest<GetByIdMenuTableResponse>
    {
        public int Id { get; set; }
        public class GetByIdMenuTableQueryHandler : IRequestHandler<GetByIdMenuTableQuery, GetByIdMenuTableResponse>
        {
            private readonly IMenuTableRepository _MenuRepository;
            private readonly IMapper _mapper;

            public GetByIdMenuTableQueryHandler(IMenuTableRepository MenuRepository, IMapper mapper)
            {
                _MenuRepository = MenuRepository;
                _mapper = mapper;
            }

            public async Task<GetByIdMenuTableResponse> Handle(GetByIdMenuTableQuery request, CancellationToken cancellationToken)
            {
                var Menu = await _MenuRepository.GetByFilterAsync(c => c.MenuTableID == request.Id);
                return _mapper.Map<GetByIdMenuTableResponse>(Menu);
            }
        }

    }
}
