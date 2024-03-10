using Application.Features.Mediator.Categories.Queries.GetList;
using Application.Repositories;
using AutoMapper;
using MediatR;

namespace Application.Products.Mediator.Products.Queries.GetList
{
    public class GetListProductQuery : IRequest<List<GetListProductResponse>>
    {
        public class GetListProductQueryHandler : IRequestHandler<GetListProductQuery, List<GetListProductResponse>>
        {
            private readonly IProductRepository _ProductRepository;
            private readonly IMapper _mapper;

            public GetListProductQueryHandler(IProductRepository ProductRepository, IMapper mapper)
            {
                _ProductRepository = ProductRepository;
                _mapper = mapper;
            }

            public async Task<List<GetListProductResponse>> Handle(GetListProductQuery request, CancellationToken cancellationToken)
            {
                var Product = await _ProductRepository.GetAllAsync();
                return _mapper.Map<List<GetListProductResponse>>(Product);
            }
        }
    }
}
