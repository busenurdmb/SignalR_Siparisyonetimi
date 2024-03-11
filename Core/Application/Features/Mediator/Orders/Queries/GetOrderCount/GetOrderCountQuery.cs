using Application.Features.Mediator.Orders.Queries.GetOrderCount;
using Application.Repositories;
using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Mediator.Orders.Queries.GetOrderCount
{
    
    public class GetOrderCountQuery : IRequest<GetOrderCountResponse>
    {
        public class GetOrderCountQueryHandler : IRequestHandler<GetOrderCountQuery, GetOrderCountResponse>
        {
            private readonly IOrderRepository _OrderRepository;
            private readonly IMapper _mapper;

            public GetOrderCountQueryHandler(IOrderRepository OrderRepository, IMapper mapper)
            {
                _OrderRepository = OrderRepository;
                _mapper = mapper;
            }

            public async Task<GetOrderCountResponse> Handle(GetOrderCountQuery request, CancellationToken cancellationToken)
            {
                int Order = _OrderRepository.TotalOrderCount();

                return _mapper.Map<GetOrderCountResponse>(Order);
            }
        }
    }
}
