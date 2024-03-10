using Application.Features.Mediator.Products.Queries.GetProductCountByCategoryNameDrink;
using Application.Repositories;
using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Mediator.Products.Queries.GetProductCountByCategoryNameDrink
{
   
    public class GetProductCountByCategoryNameDrinkQuery : IRequest<GetProductCountByCategoryNameDrinkResponse>
    {
        public class GetProductCountByCategoryNameDrinkQueryHandler : IRequestHandler<GetProductCountByCategoryNameDrinkQuery, GetProductCountByCategoryNameDrinkResponse>
        {
            private readonly IProductRepository _ProductRepository;
            private readonly IMapper _mapper;

            public GetProductCountByCategoryNameDrinkQueryHandler(IProductRepository ProductRepository, IMapper mapper)
            {
                _ProductRepository = ProductRepository;
                _mapper = mapper;
            }

            public async Task<GetProductCountByCategoryNameDrinkResponse> Handle(GetProductCountByCategoryNameDrinkQuery request, CancellationToken cancellationToken)
            {
                var Product = _ProductRepository.ProductCountByCategoryNameDrink();

                return _mapper.Map<GetProductCountByCategoryNameDrinkResponse>(Product);
            }
        }
    }
}
