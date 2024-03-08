using Application.Features.Mediator.Products.Commands.Delete;
using Application.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Mediator.Products.Commands.Delete
{
    public class DeletedProductCommand : IRequest<DeletedProductResponse>
    {
        public int Id { get; set; }

        public class DeletedProductCommandHandler : IRequestHandler<DeletedProductCommand, DeletedProductResponse>
        {
            private readonly IProductRepository _ProductRepository;
            private readonly IMapper _mapper;

            public DeletedProductCommandHandler(IProductRepository ProductRepository, IMapper mapper)
            {
                _ProductRepository = ProductRepository;
                _mapper = mapper;
            }

            public async Task<DeletedProductResponse> Handle(DeletedProductCommand request, CancellationToken cancellationToken)
            {
                Product? Product = await _ProductRepository.GetByFilterAsync(c => c.ProductID == request.Id);

                await _ProductRepository.RemoveAsync(Product);

                return _mapper.Map<DeletedProductResponse>(Product);

            }
        }
    }
}
