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

namespace Application.Features.Mediator.Orders.Commands.Delete
{
    
    public class DeletedOrderCommand : IRequest<DeletedOrderResponse>
    {
        public int Id { get; set; }

        public class DeletedOrderCommandHandler : IRequestHandler<DeletedOrderCommand, DeletedOrderResponse>
        {
            private readonly IOrderRepository _OrderRepository;
            private readonly IMapper _mapper;

            public DeletedOrderCommandHandler(IOrderRepository OrderRepository, IMapper mapper)
            {
                _OrderRepository = OrderRepository;
                _mapper = mapper;
            }

            public async Task<DeletedOrderResponse> Handle(DeletedOrderCommand request, CancellationToken cancellationToken)
            {
                Order? Order = await _OrderRepository.GetByFilterAsync(c => c.OrderID == request.Id);

                await _OrderRepository.RemoveAsync(Order);

                return _mapper.Map<DeletedOrderResponse>(Order);

            }
        }
    }
}
