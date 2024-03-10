using Application.Repositories;
using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Mediator.Products.Queries.GetProductCount
{
    
    public class GetProductCountQuery : IRequest<GetProductCountResponse>
    {
        public class GetProductCountQueryHandler : IRequestHandler<GetProductCountQuery, GetProductCountResponse>
        {
            private readonly IProductRepository _ProductRepository;
            private readonly IMapper _mapper;

            public GetProductCountQueryHandler(IProductRepository ProductRepository, IMapper mapper)
            {
                _ProductRepository = ProductRepository;
                _mapper = mapper;
            }

            public async Task<GetProductCountResponse> Handle(GetProductCountQuery request, CancellationToken cancellationToken)
            {
                int Product = _ProductRepository.ProductCount();

                return _mapper.Map<GetProductCountResponse>(Product);
            }
        }
    }
}
