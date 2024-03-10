using Application.Features.Mediator.Products.Queries.GetTotalPriceBySaladCategory;
using Application.Repositories;
using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Mediator.Products.Queries.GetTotalPriceBySaladCategory
{
    
    public class GetTotalPriceBySaladCategoryQuery : IRequest<GetTotalPriceBySaladCategoryResponse>
    {
        public class GetTotalPriceBySaladCategoryQueryHandler : IRequestHandler<GetTotalPriceBySaladCategoryQuery, GetTotalPriceBySaladCategoryResponse>
        {
            private readonly IProductRepository _ProductRepository;
            private readonly IMapper _mapper;

            public GetTotalPriceBySaladCategoryQueryHandler(IProductRepository ProductRepository, IMapper mapper)
            {
                _ProductRepository = ProductRepository;
                _mapper = mapper;
            }

            public async Task<GetTotalPriceBySaladCategoryResponse> Handle(GetTotalPriceBySaladCategoryQuery request, CancellationToken cancellationToken)
            {
                var Product = _ProductRepository.TotalPriceBySaladCategory();

                return _mapper.Map<GetTotalPriceBySaladCategoryResponse>(Product);
            }
        }
    }
}
