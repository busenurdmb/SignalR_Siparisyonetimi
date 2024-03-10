using Application.Features.Mediator.Products.Queries.GetProductPriceBySteakBurger;
using Application.Repositories;
using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Mediator.Products.Queries.GetProductPriceBySteakBurger
{
   
    public class GetProductPriceBySteakBurgerQuery : IRequest<GetProductPriceBySteakBurgerResponse>
    {
        public class GetProductPriceBySteakBurgerQueryHandler : IRequestHandler<GetProductPriceBySteakBurgerQuery, GetProductPriceBySteakBurgerResponse>
        {
            private readonly IProductRepository _ProductRepository;
            private readonly IMapper _mapper;

            public GetProductPriceBySteakBurgerQueryHandler(IProductRepository ProductRepository, IMapper mapper)
            {
                _ProductRepository = ProductRepository;
                _mapper = mapper;
            }

            public async Task<GetProductPriceBySteakBurgerResponse> Handle(GetProductPriceBySteakBurgerQuery request, CancellationToken cancellationToken)
            {
                var Product = _ProductRepository.ProductPriceBySteakBurger();

                return _mapper.Map<GetProductPriceBySteakBurgerResponse>(Product);
            }
        }
    }
}
