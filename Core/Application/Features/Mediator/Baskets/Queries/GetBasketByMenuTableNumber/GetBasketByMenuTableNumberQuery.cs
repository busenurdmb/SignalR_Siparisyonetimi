using Application.Features.Mediator.Baskets.Queries.GetById;
using Application.Repositories;
using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Mediator.Baskets.Queries.GetBasketByMenuTableNumber
{
   
    public class GetBasketByMenuTableNumberQuery : IRequest<List<GetBasketByMenuTableNumberResponse>>
    {
        public int Id { get; set; }

        public GetBasketByMenuTableNumberQuery(int ıd)
        {
            Id = ıd;
        }

        public class GetByIdBasketQueryHandler : IRequestHandler<GetBasketByMenuTableNumberQuery, List<GetBasketByMenuTableNumberResponse>>
        {
            private readonly IBasketRepository _BasketRepository;
            private readonly IMapper _mapper;
            public GetByIdBasketQueryHandler(IBasketRepository BasketRepository, IMapper mapper)
            {
                _BasketRepository = BasketRepository;
                _mapper = mapper;
            }

            public async Task<List<GetBasketByMenuTableNumberResponse>> Handle(GetBasketByMenuTableNumberQuery request, CancellationToken cancellationToken)
            {
                var Basket = _BasketRepository.GetBasketByMenuTableNumber(request.Id);
                var value= _mapper.Map<List<GetBasketByMenuTableNumberResponse>>(Basket);
                return value;
            }
        }
    }
}
