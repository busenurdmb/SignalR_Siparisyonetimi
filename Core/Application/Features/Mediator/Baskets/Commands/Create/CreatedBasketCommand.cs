using Application.Features.Mediator.Baskets.Commands.Create;
using Application.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Mediator.Baskets.Commands.Create
{
    
    public class CreatedBasketCommand : IRequest<CreatedBasketResponse>
    {

        public int BasketID { get; set; }
        public decimal Price { get; set; }
        public decimal Count { get; set; }
        public decimal TotalPrice { get; set; }
        public int ProductID { get; set; }
        public int MenuTableID { get; set; }

        public class CreatedAboutCommandHandler : IRequestHandler<CreatedBasketCommand, CreatedBasketResponse>
        {
            private readonly IBasketRepository _BasketRepository;
            private readonly IMapper _mapper;
            public CreatedAboutCommandHandler(IMapper mapper, IBasketRepository BasketRepository)
            {

                _mapper = mapper;
                _BasketRepository = BasketRepository;
            }

            public async Task<CreatedBasketResponse> Handle(CreatedBasketCommand request, CancellationToken cancellationToken)
            {



                var Basket = _mapper.Map<Basket>(request);
                await _BasketRepository.CreateAsync(Basket);

                // Oluşturulan hakkında yanıtını döndür
                return _mapper.Map<CreatedBasketResponse>(Basket);

            }
        }
    }
}
