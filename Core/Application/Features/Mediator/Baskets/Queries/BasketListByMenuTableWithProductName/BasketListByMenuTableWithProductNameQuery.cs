using Application.Features.Mediator.Baskets.Queries.BasketListByMenuTableWithProductName;
using Application.Repositories;
using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Mediator.Baskets.Queries.BasketListByMenuTableWithProductName
{
   
    public class BasketListByMenuTableWithProductNameQuery : IRequest<List<BasketListByMenuTableWithProductNameResponse>>
    {
        public int Id { get; set; }

        public BasketListByMenuTableWithProductNameQuery(int ıd)
        {
            Id = ıd;
        }

        public class GetByIdBasketQueryHandler : IRequestHandler<BasketListByMenuTableWithProductNameQuery, List<BasketListByMenuTableWithProductNameResponse>>
        {
            private readonly IBasketRepository _BasketRepository;
            private readonly IMapper _mapper;
            public GetByIdBasketQueryHandler(IBasketRepository BasketRepository, IMapper mapper)
            {
                _BasketRepository = BasketRepository;
                _mapper = mapper;
            }

            public async Task<List<BasketListByMenuTableWithProductNameResponse>> Handle(BasketListByMenuTableWithProductNameQuery request, CancellationToken cancellationToken)
            {
                var Basket =await _BasketRepository.BasketListByMenuTableWithProductName(request.Id);
                var value= _mapper.Map<List<BasketListByMenuTableWithProductNameResponse>>(Basket);
                return value;
            }
        }
    }
}
