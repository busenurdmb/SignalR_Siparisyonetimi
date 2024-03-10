using Application.Features.Mediator.Products.Queries.GetProductCountByCategoryNameHamburger;
using Application.Repositories;
using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Mediator.Products.Queries.GetProductCountByCategoryNameHamburger
{
   
    public class GetProductCountByCategoryNameHamburgerQuery : IRequest<GetProductCountByCategoryNameHamburgerResponse>
    {
        public class GetProductCountByCategoryNameHamburgerQueryHandler : IRequestHandler<GetProductCountByCategoryNameHamburgerQuery, GetProductCountByCategoryNameHamburgerResponse>
        {
            private readonly IProductRepository _ProductRepository;
            private readonly IMapper _mapper;

            public GetProductCountByCategoryNameHamburgerQueryHandler(IProductRepository ProductRepository, IMapper mapper)
            {
                _ProductRepository = ProductRepository;
                _mapper = mapper;
            }

            public async Task<GetProductCountByCategoryNameHamburgerResponse> Handle(GetProductCountByCategoryNameHamburgerQuery request, CancellationToken cancellationToken)
            {
                var Product = _ProductRepository.ProductCountByCategoryNameHamburger();

                return _mapper.Map<GetProductCountByCategoryNameHamburgerResponse>(Product);
            }
        }
    }

}
