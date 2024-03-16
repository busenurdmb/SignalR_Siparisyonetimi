using Application.Features.Mediator.Baskets.Queries.GetById;
using Application.Repositories;
using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Mediator.Baskets.Queries.GetById
{
   
    public class GetByIdBasketQuery : IRequest<GetByIdBasketResponse>
    {
        public int Id { get; set; }

        //public GetByIdBasketQuery(int ıd)
        //{
        //    Id = ıd;
        //}

        public class GetByIdBasketQueryHandler : IRequestHandler<GetByIdBasketQuery, GetByIdBasketResponse>
        {
            private readonly IBasketRepository _BasketRepository;
            private readonly IMapper _mapper;
            public GetByIdBasketQueryHandler(IBasketRepository BasketRepository, IMapper mapper)
            {
                _BasketRepository = BasketRepository;
                _mapper = mapper;
            }

            public async Task<GetByIdBasketResponse> Handle(GetByIdBasketQuery request, CancellationToken cancellationToken)
            {
                var Basket = await _BasketRepository.GetByFilterAsync(b => b.BasketID == request.Id);
                return _mapper.Map<GetByIdBasketResponse>(Basket);
            }
        }
    }
}
