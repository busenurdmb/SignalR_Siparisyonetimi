using Application.Features.Mediator.OrderDetails.Queries.GetList;
using Application.Repositories;
using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Mediator.OrderDetailsDetails.Queries.GetList
{
   
    public class GetListOrderDetailsQuery : IRequest<List<GetListOrderDetailsResponse>>
    {
        public class GetListOrderDetailsQueryHandler : IRequestHandler<GetListOrderDetailsQuery, List<GetListOrderDetailsResponse>>
        {
            private readonly IOrderDetailRepository _OrderDetailsRepository;
            private readonly IMapper _mapper;

            public GetListOrderDetailsQueryHandler(IOrderDetailRepository orderDetailsRepository, IMapper mapper)
            {
                _OrderDetailsRepository = orderDetailsRepository;
                _mapper = mapper;
            }

            public async Task<List<GetListOrderDetailsResponse>> Handle(GetListOrderDetailsQuery request, CancellationToken cancellationToken)
            {
                var OrderDetails = await _OrderDetailsRepository.GetAllAsync();
                return _mapper.Map<List<GetListOrderDetailsResponse>>(OrderDetails);
            }
        }
    }
}
