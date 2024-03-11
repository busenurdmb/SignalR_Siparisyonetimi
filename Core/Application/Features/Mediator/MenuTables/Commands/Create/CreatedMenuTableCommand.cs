using Application.Features.Mediator.MenuTables.Commands.Create;
using Application.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;

namespace Application.MenuTables.Mediator.MenuTables.Commands.Create
{
    public class CreatedMenuTableCommand : IRequest<CreatedMenuTableResponse>
    {

        
        public string Name { get; set; }
        public bool Status { get; set; }

        public class CreatedMenuTableCommandHandler : IRequestHandler<CreatedMenuTableCommand, CreatedMenuTableResponse>
        {
            private readonly IMenuTableRepository _MenuTableRepository;
            private readonly IMapper _mapper;

            public CreatedMenuTableCommandHandler(IMenuTableRepository MenuTableRepository, IMapper mapper)
            {
                _MenuTableRepository = MenuTableRepository;
                _mapper = mapper;
            }

            public async Task<CreatedMenuTableResponse> Handle(CreatedMenuTableCommand request, CancellationToken cancellationToken)
            {
                var MenuTable = _mapper.Map<MenuTable>(request);
                await _MenuTableRepository.CreateAsync(MenuTable);
                return _mapper.Map<CreatedMenuTableResponse>(MenuTable);
            }
        }
    }
}
