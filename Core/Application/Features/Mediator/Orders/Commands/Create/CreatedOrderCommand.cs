using Application.Features.Mediator.Categories.Commands.Create;
using Application.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Mediator.Orders.Commands.Create
{

    public class CreatedOrderCommand : IRequest<CreatedOrderResponse>
    {
        public string TableNumber { get; set; }
        public string Description { get; set; }
       public DateTime OrderDate { get; set; }
        public decimal TotalPrice { get; set; }

        public class CreatedOrderCommandHandler : IRequestHandler<CreatedOrderCommand, CreatedOrderResponse>
        {
            private readonly IOrderRepository _OrderRepository;
            private readonly IMapper _mapper;

            public CreatedOrderCommandHandler(IOrderRepository OrderRepository, IMapper mapper)
            {
                _OrderRepository = OrderRepository;
                _mapper = mapper;
            }

            public async Task<CreatedOrderResponse> Handle(CreatedOrderCommand request, CancellationToken cancellationToken)
            {
                var Order = _mapper.Map<Order>(request);
                await _OrderRepository.CreateAsync(Order);
                return _mapper.Map<CreatedOrderResponse>(Order);
            }
        }
    }
}
