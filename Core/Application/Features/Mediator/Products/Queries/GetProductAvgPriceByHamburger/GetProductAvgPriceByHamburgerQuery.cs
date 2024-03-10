using Application.Features.Mediator.Products.Queries.GetProductAvgPriceByHamburger;
using Application.Repositories;
using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Mediator.Products.Queries.GetProductAvgPriceByHamburger
{
   
    public class GetProductAvgPriceByHamburgerQuery : IRequest<GetProductAvgPriceByHamburgerResponse>
    {
        public class GetProductAvgPriceByHamburgerQueryHandler : IRequestHandler<GetProductAvgPriceByHamburgerQuery, GetProductAvgPriceByHamburgerResponse>
        {
            private readonly IProductRepository _ProductRepository;
            private readonly IMapper _mapper;

            public GetProductAvgPriceByHamburgerQueryHandler(IProductRepository ProductRepository, IMapper mapper)
            {
                _ProductRepository = ProductRepository;
                _mapper = mapper;
            }

            public async Task<GetProductAvgPriceByHamburgerResponse> Handle(GetProductAvgPriceByHamburgerQuery request, CancellationToken cancellationToken)
            {
                var Product = _ProductRepository.ProductAvgPriceByHamburger();

                return _mapper.Map<GetProductAvgPriceByHamburgerResponse>(Product);
            }
        }
    }
}
