using Application.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;

namespace Application.Features.Mediator.Discounts.Commands.Create
{
    public class CreatedDiscountCommand : IRequest<CreatedDiscountResponse>
    {

        public string Title { get; set; }
        public string Amount { get; set; }
        public string Description { get; set; }
        public string ImageUrl { get; set; }
        public bool Status { get; set; }

        public class CreatedDiscountCommandHandler : IRequestHandler<CreatedDiscountCommand, CreatedDiscountResponse>
        {
            private readonly IDiscountRepository _DiscountRepository;
            private readonly IMapper _mapper;

            public CreatedDiscountCommandHandler(IDiscountRepository DiscountRepository, IMapper mapper)
            {
                _DiscountRepository = DiscountRepository;
                _mapper = mapper;
            }

            public async Task<CreatedDiscountResponse> Handle(CreatedDiscountCommand request, CancellationToken cancellationToken)
            {
                var discount = _mapper.Map<Discount>(request);
                await _DiscountRepository.CreateAsync(discount);
                return _mapper.Map<CreatedDiscountResponse>(discount);
            }
        }
    }
}
