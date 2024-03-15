using Application.Features.Mediator.Baskets.Queries.GetList;
using Application.Repositories;
using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Mediator.Baskets.Queries.GetList
{
    
    public class GetListBasketQuery : IRequest<List<GetListBasketResponse>>
    {
        public class GetListBasketQueryHandler : IRequestHandler<GetListBasketQuery, List<GetListBasketResponse>>
        {
            private readonly IBasketRepository _BasketRepository;
            private readonly IMapper _mapper;

            public GetListBasketQueryHandler(IBasketRepository BasketRepository, IMapper mapper)
            {
                _BasketRepository = BasketRepository;
                _mapper = mapper;
            }

            public async Task<List<GetListBasketResponse>> Handle(GetListBasketQuery request, CancellationToken cancellationToken)
            {
                var Basket = await _BasketRepository.GetAllAsync();
                return _mapper.Map<List<GetListBasketResponse>>(Basket);
            }
        }
    }
}
