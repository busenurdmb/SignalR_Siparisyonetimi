using Application.Repositories;
using AutoMapper;
using MediatR;

namespace Application.Features.Mediator.MoneyCases.Queries
{

    public class GetTotalMoneyCaseAmountQuery : IRequest<GetTotalMoneyCaseAmountResponse>
    {
        public class GetTotalMoneyCaseAmountQueryHandler : IRequestHandler<GetTotalMoneyCaseAmountQuery, GetTotalMoneyCaseAmountResponse>
        {
            private readonly IMoneyCaseRepository _MoneyCaseRepository;
            private readonly IMapper _mapper;

            public GetTotalMoneyCaseAmountQueryHandler(IMoneyCaseRepository moneyCaseRepository, IMapper mapper)
            {
                _MoneyCaseRepository = moneyCaseRepository;
                _mapper = mapper;
            }

            public async Task<GetTotalMoneyCaseAmountResponse> Handle(GetTotalMoneyCaseAmountQuery request, CancellationToken cancellationToken)
            {
                var Product = _MoneyCaseRepository.TotalMoneyCaseAmount();

                return _mapper.Map<GetTotalMoneyCaseAmountResponse>(Product);
            }
        }
    }
}
