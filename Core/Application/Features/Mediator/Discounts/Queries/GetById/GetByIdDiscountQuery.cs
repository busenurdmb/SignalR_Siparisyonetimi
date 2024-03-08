using Application.Repositories;
using AutoMapper;
using MediatR;

namespace Application.Features.Mediator.Discounts.Queries.GetById
{
    public class GetByIdDiscountQuery : IRequest<GetByIdDiscountResponse>
    {
        public int Id { get; set; }
        public class GetByIdDiscountQueryHandler : IRequestHandler<GetByIdDiscountQuery, GetByIdDiscountResponse>
        {
            private readonly IDiscountRepository _DiscountRepository;
            private readonly IMapper _mapper;

            public GetByIdDiscountQueryHandler(IDiscountRepository DiscountRepository, IMapper mapper)
            {
                _DiscountRepository = DiscountRepository;
                _mapper = mapper;
            }

            public async Task<GetByIdDiscountResponse> Handle(GetByIdDiscountQuery request, CancellationToken cancellationToken)
            {
                var Discount = await _DiscountRepository.GetByFilterAsync(c => c.DiscountID == request.Id);
                return _mapper.Map<GetByIdDiscountResponse>(Discount);
            }
        }

    }
}
