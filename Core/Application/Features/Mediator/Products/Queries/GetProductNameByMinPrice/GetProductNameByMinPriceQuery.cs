using Application.Features.Mediator.Products.Queries.GetProductNameByMinPrice;
using Application.Repositories;
using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Mediator.Products.Queries.GetProductNameByMinPrice
{
    public class GetProductNameByMinPriceQuery : IRequest<GetProductNameByMinPriceResponse>
    {
        public class GetProductNameByMinPriceQueryHandler : IRequestHandler<GetProductNameByMinPriceQuery, GetProductNameByMinPriceResponse>
        {
            private readonly IProductRepository _ProductRepository;
            private readonly IMapper _mapper;

            public GetProductNameByMinPriceQueryHandler(IProductRepository ProductRepository, IMapper mapper)
            {
                _ProductRepository = ProductRepository;
                _mapper = mapper;
            }

            public async Task<GetProductNameByMinPriceResponse> Handle(GetProductNameByMinPriceQuery request, CancellationToken cancellationToken)
            {
                var Product = _ProductRepository.ProductNameByMinPrice();

                return _mapper.Map<GetProductNameByMinPriceResponse>(Product);
            }
        }
    }
}
