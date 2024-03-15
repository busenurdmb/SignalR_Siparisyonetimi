using Application.Features.Mediator.Baskets.Commands.Update;
using Application.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Mediator.Baskets.Commands.Update
{
    
    public class UpdateBasketCommand : IRequest<UpdateBasketResponse>
    {
        public int BasketID { get; set; }
        public decimal Price { get; set; }
        public decimal Count { get; set; }
        public decimal TotalPrice { get; set; }
        public int ProductID { get; set; }
        public int MenuTableID { get; set; }
        public class UpdateAboutCommandHandler : IRequestHandler<UpdateBasketCommand, UpdateBasketResponse>
        {
            private readonly IBasketRepository _BasketRepository;
            private readonly IMapper _mapper;

            public UpdateAboutCommandHandler(IBasketRepository BasketRepository, IMapper mapper)
            {
                _BasketRepository = BasketRepository;
                _mapper = mapper;
            }

            public async Task<UpdateBasketResponse> Handle(UpdateBasketCommand request, CancellationToken cancellationToken)
            {
                Basket? Basket = await _BasketRepository.GetByFilterAsync(b => b.BasketID == request.BasketID);
                //var Basket = await _BasketRepository.GetByIdAsync(request.BasketID);


                Basket = _mapper.Map(request, Basket);

                await _BasketRepository.UpdateAsync(Basket);

                return _mapper.Map<UpdateBasketResponse>(Basket);

            }
        }
    }
}
