using Application.Repositories;
using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Mediator.Products.Queries.GetProductPriceAvg
{
   
    public class GetProductPriceAvgQuery : IRequest<GetProductPriceAvgResponse>
    {
        public class GetProductPriceAvgQueryHandler : IRequestHandler<GetProductPriceAvgQuery, GetProductPriceAvgResponse>
        {
            private readonly IProductRepository _ProductRepository;
            private readonly IMapper _mapper;

            public GetProductPriceAvgQueryHandler(IProductRepository ProductRepository, IMapper mapper)
            {
                _ProductRepository = ProductRepository;
                _mapper = mapper;
            }

            public async Task<GetProductPriceAvgResponse> Handle(GetProductPriceAvgQuery request, CancellationToken cancellationToken)
            {
                var Product = _ProductRepository.ProductPriceAvg();

                return _mapper.Map<GetProductPriceAvgResponse>(Product);
            }
        }
    }
}
