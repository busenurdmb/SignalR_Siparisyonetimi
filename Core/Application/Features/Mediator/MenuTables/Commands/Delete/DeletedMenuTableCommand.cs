using Application.Features.Mediator.Features.MenuTables.Commands.Delete;
using Application.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;

namespace Application.MenuTables.Mediator.MenuTables.Commands.Delete
{
    public class DeletedMenuTableCommand : IRequest<DeletedMenuTableResponse>
    {
        public int Id { get; set; }

        public class DeletedMenuTableCommandHandler : IRequestHandler<DeletedMenuTableCommand, DeletedMenuTableResponse>
        {
            private readonly IMenuTableRepository _MenuTableRepository;
            private readonly IMapper _mapper;

            public DeletedMenuTableCommandHandler(IMenuTableRepository MenuTableRepository, IMapper mapper)
            {
                _MenuTableRepository = MenuTableRepository;
                _mapper = mapper;
            }

            public async Task<DeletedMenuTableResponse> Handle(DeletedMenuTableCommand request, CancellationToken cancellationToken)
            {
                MenuTable? MenuTable = await _MenuTableRepository.GetByFilterAsync(c => c.MenuTableID == request.Id);

                await _MenuTableRepository.RemoveAsync(MenuTable);

                return _mapper.Map<DeletedMenuTableResponse>(MenuTable);

            }
        }
    }
}
