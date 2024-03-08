using Application.Repositories;
using AutoMapper;
using MediatR;

namespace Application.Features.Mediator.Discounts.Queries.GetList
{
    public class GetListDiscountQuery : IRequest<List<GetListDiscountResponse>>
    {
        public class GetListDiscountQueryHandler : IRequestHandler<GetListDiscountQuery, List<GetListDiscountResponse>>
        {
            private readonly IDiscountRepository _DiscountRepository;
            private readonly IMapper _mapper;

            public GetListDiscountQueryHandler(IDiscountRepository DiscountRepository, IMapper mapper)
            {
                _DiscountRepository = DiscountRepository;
                _mapper = mapper;
            }

            public async Task<List<GetListDiscountResponse>> Handle(GetListDiscountQuery request, CancellationToken cancellationToken)
            {
                var Discount = await _DiscountRepository.GetAllAsync();
                return _mapper.Map<List<GetListDiscountResponse>>(Discount);
            }
        }
    }

}
