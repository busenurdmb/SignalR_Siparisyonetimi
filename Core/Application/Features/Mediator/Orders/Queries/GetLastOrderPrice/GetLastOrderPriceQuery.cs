using Application.Features.Mediator.Orders.Queries.GetLastOrderPrice;
using Application.Repositories;
using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Mediator.Orders.Queries.GetLastOrderPrice
{
  
    public class GetLastOrderPriceQuery : IRequest<GetLastOrderPriceResponse>
    {
        public class GetLastOrderPriceQueryHandler : IRequestHandler<GetLastOrderPriceQuery, GetLastOrderPriceResponse>
        {
            private readonly IOrderRepository _OrderRepository;
            private readonly IMapper _mapper;

            public GetLastOrderPriceQueryHandler(IOrderRepository OrderRepository, IMapper mapper)
            {
                _OrderRepository = OrderRepository;
                _mapper = mapper;
            }

            public async Task<GetLastOrderPriceResponse> Handle(GetLastOrderPriceQuery request, CancellationToken cancellationToken)
            {
                var price = _OrderRepository.LastOrderPrice();

                return _mapper.Map<GetLastOrderPriceResponse>(price);
            }


        }
    }
}
