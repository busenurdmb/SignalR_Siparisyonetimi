using Application.Features.Mediator.MenuTable.Commands.Update;
using Application.MenuTables.Mediator.MenuTables.Commands.Update;
using Application.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.MenuTables.Mediator.MenuTables.Commands.Update
{
    public class UpdatedMenuTableCommand : IRequest<UpdatedMenuTableResponse>
    {
        public int MenuTableID { get; set; }
        public string Name { get; set; }
        public bool Status { get; set; }
        public class UpdatedMenuTableCommandHandler : IRequestHandler<UpdatedMenuTableCommand, UpdatedMenuTableResponse>
        {
            private readonly IMenuTableRepository _MenuTableRepository;
            private readonly IMapper _mapper;

            public UpdatedMenuTableCommandHandler(IMenuTableRepository MenuTableRepository, IMapper mapper)
            {
                _MenuTableRepository = MenuTableRepository;
                _mapper = mapper;
            }

            public async Task<UpdatedMenuTableResponse> Handle(UpdatedMenuTableCommand request, CancellationToken cancellationToken)
            {
               MenuTable? MenuTable = await _MenuTableRepository.GetByFilterAsync(c => c.MenuTableID== request.MenuTableID);

                MenuTable = _mapper.Map(request, MenuTable);

                await _MenuTableRepository.UpdateAsync(MenuTable);

                return _mapper.Map<UpdatedMenuTableResponse>(MenuTable);

            }
        }
    }
}
