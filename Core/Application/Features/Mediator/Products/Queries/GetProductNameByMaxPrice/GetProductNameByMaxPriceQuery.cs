using Application.Features.Mediator.Products.Queries.GetProductNameByMaxPrice;
using Application.Repositories;
using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Mediator.Products.Queries.GetProductNameByMaxPrice
{
 
    public class GetProductNameByMaxPriceQuery : IRequest<GetProductNameByMaxPriceResponse>
    {
        public class GetProductNameByMaxPriceQueryHandler : IRequestHandler<GetProductNameByMaxPriceQuery, GetProductNameByMaxPriceResponse>
        {
            private readonly IProductRepository _ProductRepository;
            private readonly IMapper _mapper;

            public GetProductNameByMaxPriceQueryHandler(IProductRepository ProductRepository, IMapper mapper)
            {
                _ProductRepository = ProductRepository;
                _mapper = mapper;
            }

            public async Task<GetProductNameByMaxPriceResponse> Handle(GetProductNameByMaxPriceQuery request, CancellationToken cancellationToken)
            {
                var Product = _ProductRepository.ProductNameByMaxPrice();

                return _mapper.Map<GetProductNameByMaxPriceResponse>(Product);
            }
        }
    }

}
