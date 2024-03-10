using Application.Features.Mediator.Categories.Queries.GetById;
using Application.Repositories;
using AutoMapper;
using MediatR;

namespace Application.Products.Mediator.Products.Queries.GetById
{
    public class GetByIdProductQuery : IRequest<GetByIdProductResponse>
    {
        public int Id { get; set; }
        public class GetByIdProductQueryHandler : IRequestHandler<GetByIdProductQuery, GetByIdProductResponse>
        {
            private readonly IProductRepository _ProductRepository;
            private readonly IMapper _mapper;

            public GetByIdProductQueryHandler(IProductRepository ProductRepository, IMapper mapper)
            {
                _ProductRepository = ProductRepository;
                _mapper = mapper;
            }

            public async Task<GetByIdProductResponse> Handle(GetByIdProductQuery request, CancellationToken cancellationToken)
            {
                var Product = await _ProductRepository.GetByFilterAsync(c => c.ProductID == request.Id);
                return _mapper.Map<GetByIdProductResponse>(Product);
            }
        }

    }
}
