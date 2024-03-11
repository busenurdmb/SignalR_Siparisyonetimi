using Application.Features.Mediator.Orders.Queries.GetOrderCount;
using Application.Repositories;
using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Mediator.Orders.Queries.GetActiveOrderCount
{
  
    public class GetActiveOrderCountQuery : IRequest<GetActiveOrderCountResponse>
    {
        public class GetActiveOrderCountQueryHandler : IRequestHandler<GetActiveOrderCountQuery, GetActiveOrderCountResponse>
        {
            private readonly IOrderRepository _OrderRepository;
            private readonly IMapper _mapper;

            public GetActiveOrderCountQueryHandler(IOrderRepository OrderRepository, IMapper mapper)
            {
                _OrderRepository = OrderRepository;
                _mapper = mapper;
            }

            public async Task<GetActiveOrderCountResponse> Handle(GetActiveOrderCountQuery request, CancellationToken cancellationToken)
            {
                int Order = _OrderRepository.ActiveOrderCount();

                return _mapper.Map<GetActiveOrderCountResponse>(Order);
            }

           
        }
    }
}
