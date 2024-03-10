using Application.Features.Mediator.Products.Queries.GetTotalPriceByDrinkCategory;
using Application.Repositories;
using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Mediator.Products.Queries.GetTotalPriceByDrinkCategory
{
    
    public class GetTotalPriceByDrinkCategoryQuery : IRequest<GetTotalPriceByDrinkCategoryResponse>
    {
        public class GetTotalPriceByDrinkCategoryQueryHandler : IRequestHandler<GetTotalPriceByDrinkCategoryQuery, GetTotalPriceByDrinkCategoryResponse>
        {
            private readonly IProductRepository _ProductRepository;
            private readonly IMapper _mapper;

            public GetTotalPriceByDrinkCategoryQueryHandler(IProductRepository ProductRepository, IMapper mapper)
            {
                _ProductRepository = ProductRepository;
                _mapper = mapper;
            }

            public async Task<GetTotalPriceByDrinkCategoryResponse> Handle(GetTotalPriceByDrinkCategoryQuery request, CancellationToken cancellationToken)
            {
                var Product = _ProductRepository.TotalPriceByDrinkCategory();

                return _mapper.Map<GetTotalPriceByDrinkCategoryResponse>(Product);
            }
        }
    }
}
