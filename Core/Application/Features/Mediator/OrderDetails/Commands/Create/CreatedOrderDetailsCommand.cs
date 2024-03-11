using Application.Features.Mediator.OrderDetails.Commands.Create;
using Application.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;

namespace Application.Features.Mediator.OrderDetailsDetails.Commands.Create
{

    public class CreatedOrderDetailsCommand : IRequest<CreatedOrderDetailsResponse>
    {
       
        public int ProductID { get; set; }
        public int Count { get; set; }
        public decimal UnitPrice { get; set; }
        public decimal TotalPrice { get; set; }
        public int OrderID { get; set; }
        public class CreatedOrderDetailsCommandHandler : IRequestHandler<CreatedOrderDetailsCommand, CreatedOrderDetailsResponse>
        {
            private readonly IOrderDetailRepository _OrderDetailsRepository;
            private readonly IMapper _mapper;

            public CreatedOrderDetailsCommandHandler(IOrderDetailRepository OrderDetailsRepository, IMapper mapper)
            {
                _OrderDetailsRepository = OrderDetailsRepository;
                _mapper = mapper;
            }

            public async Task<CreatedOrderDetailsResponse> Handle(CreatedOrderDetailsCommand request, CancellationToken cancellationToken)
            {
                var OrderDetails = _mapper.Map<OrderDetail>(request);
                await _OrderDetailsRepository.CreateAsync(OrderDetails);
                return _mapper.Map<CreatedOrderDetailsResponse>(OrderDetails);
            }
        }
    }
}
