using Application.Features.Mediator.Orders.Queries.GetById;
using Application.Orders.Mediator.Orders.Queries.GetById;
using Application.Repositories;
using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Orders.Mediator.Orders.Queries.GetById
{
 
    public class GetByIdOrderQuery : IRequest<GetByIdOrderResponse>
    {
        public int Id { get; set; }
        public class GetByIdOrderQueryHandler : IRequestHandler<GetByIdOrderQuery, GetByIdOrderResponse>
        {
            private readonly IOrderRepository _OrderRepository;
            private readonly IMapper _mapper;

            public GetByIdOrderQueryHandler(IOrderRepository OrderRepository, IMapper mapper)
            {
                _OrderRepository = OrderRepository;
                _mapper = mapper;
            }

            public async Task<GetByIdOrderResponse> Handle(GetByIdOrderQuery request, CancellationToken cancellationToken)
            {
                var Order = await _OrderRepository.GetByFilterAsync(c => c.OrderID == request.Id);
                return _mapper.Map<GetByIdOrderResponse>(Order);
            }
        }

    }
}
