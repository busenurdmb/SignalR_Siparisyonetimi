using Application.Features.Mediator.Products.Commands.Update;
using Application.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;

namespace Application.Products.Mediator.Products.Commands.Update
{
    public class UpdatedProductCommand : IRequest<UpdatedProductResponse>
    {
        public int ProductID { get; set; }
        public string ProductName { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public string ImageUrl { get; set; }
        public bool ProductStatus { get; set; }
        public int CategoryID { get; set; }
        public class UpdatedProductCommandHandler : IRequestHandler<UpdatedProductCommand, UpdatedProductResponse>
        {
            private readonly IProductRepository _ProductRepository;
            private readonly IMapper _mapper;

            public UpdatedProductCommandHandler(IProductRepository ProductRepository, IMapper mapper)
            {
                _ProductRepository = ProductRepository;
                _mapper = mapper;
            }

            public async Task<UpdatedProductResponse> Handle(UpdatedProductCommand request, CancellationToken cancellationToken)
            {
                Product? Product = await _ProductRepository.GetByFilterAsync(c => c.ProductID == request.ProductID);

                Product = _mapper.Map(request, Product);

                await _ProductRepository.UpdateAsync(Product);

                return _mapper.Map<UpdatedProductResponse>(Product);

            }
        }
    }
}
