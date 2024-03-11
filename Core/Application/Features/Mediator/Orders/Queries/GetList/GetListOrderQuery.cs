using Application.Features.Mediator.Categories.Queries.GetList;
using Application.Repositories;
using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Mediator.Orders.Queries.GetList
{
   
    public class GetListOrderQuery : IRequest<List<GetListOrderResponse>>
    {
        public class GetListOrderQueryHandler : IRequestHandler<GetListOrderQuery, List<GetListOrderResponse>>
        {
            private readonly IOrderRepository _OrderRepository;
            private readonly IMapper _mapper;

            public GetListOrderQueryHandler(IOrderRepository OrderRepository, IMapper mapper)
            {
                _OrderRepository = OrderRepository;
                _mapper = mapper;
            }

            public async Task<List<GetListOrderResponse>> Handle(GetListOrderQuery request, CancellationToken cancellationToken)
            {
                var Order = await _OrderRepository.GetAllAsync();
                return _mapper.Map<List<GetListOrderResponse>>(Order);
            }
        }
    }
}
