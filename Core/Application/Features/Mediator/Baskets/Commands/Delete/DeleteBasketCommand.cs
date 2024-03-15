using Application.Features.Mediator.Baskets.Commands.Delete;
using Application.Repositories;
using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Mediator.Baskets.Commands.Delete
{
   
    public class DeleteBasketCommand : IRequest<DeleteBasketResponse>
    {
        public int Id { get; set; }

        public DeleteBasketCommand(int ıd)
        {
            Id = ıd;
        }
        public class DeleteAboutCommandHandler : IRequestHandler<DeleteBasketCommand, DeleteBasketResponse>
        {
            private readonly IBasketRepository _BasketRepository;
            private readonly IMapper _mapper;

            public DeleteAboutCommandHandler(IBasketRepository BasketRepository, IMapper mapper)
            {
                _BasketRepository = BasketRepository;
                _mapper = mapper;
            }

            public async Task<DeleteBasketResponse> Handle(DeleteBasketCommand request, CancellationToken cancellationToken)
            {
                var values = await _BasketRepository.GetByIdAsync(request.Id);
                await _BasketRepository.RemoveAsync(values);
                return _mapper.Map<DeleteBasketResponse>(values);
            }
        }
    }
}
