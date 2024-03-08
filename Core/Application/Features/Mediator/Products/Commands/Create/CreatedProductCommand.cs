using Application.Features.Mediator.Products.Commands.Create;
using Application.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;

namespace Application.Products.Mediator.Products.Commands.Create
{
    public class CreatedProductCommand : IRequest<CreatedProductResponse>
    {
       public string ProductName { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public string ImageUrl { get; set; }
        public bool ProductStatus { get; set; }
        public int CategoryID { get; set; }
        public class CreatedProductCommandHandler : IRequestHandler<CreatedProductCommand, CreatedProductResponse>
        {
            private readonly IProductRepository _ProductRepository;
            private readonly IMapper _mapper;

            public CreatedProductCommandHandler(IProductRepository ProductRepository, IMapper mapper)
            {
                _ProductRepository = ProductRepository;
                _mapper = mapper;
            }

            public async Task<CreatedProductResponse> Handle(CreatedProductCommand request, CancellationToken cancellationToken)
            {
                var product = _mapper.Map<Product>(request);
                await _ProductRepository.CreateAsync(product);
                return _mapper.Map<CreatedProductResponse>(product);
            }
        }
    }

}
