using Application.Features.Mediator.OrderDetails.Queries.GetById;
using Application.Repositories;
using AutoMapper;
using MediatR;

namespace Application.OrderDetailss.Mediator.OrderDetails.Queries.GetById
{

    public class GetByIdOrderDetailsQuery : IRequest<GetByIdOrderDetailsResponse>
    {
        public int Id { get; set; }
        public class GetByIdOrderDetailsQueryHandler : IRequestHandler<GetByIdOrderDetailsQuery, GetByIdOrderDetailsResponse>
        {
            private readonly IOrderDetailRepository _OrderDetailsRepository;
            private readonly IMapper _mapper;

            public GetByIdOrderDetailsQueryHandler(IOrderDetailRepository OrderDetailsRepository, IMapper mapper)
            {
                _OrderDetailsRepository = OrderDetailsRepository;
                _mapper = mapper;
            }

            public async Task<GetByIdOrderDetailsResponse> Handle(GetByIdOrderDetailsQuery request, CancellationToken cancellationToken)
            {
                var OrderDetails = await _OrderDetailsRepository.GetByFilterAsync(c => c.OrderDetailID == request.Id);
                return _mapper.Map<GetByIdOrderDetailsResponse>(OrderDetails);
            }
        }

    }
}
