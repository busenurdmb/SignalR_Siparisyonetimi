using Application.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;

namespace Application.Features.Mediator.Orders.Commands.Update
{

    public class UpdatedOrderCommand : IRequest<UpdatedOrderResponse>
    {
        public int OrderID { get; set; }
        public string TableNumber { get; set; }
        public string Description { get; set; }
        public DateTime OrderDate { get; set; }
        public decimal TotalPrice { get; set; }

        public class UpdatedOrderCommandHandler : IRequestHandler<UpdatedOrderCommand, UpdatedOrderResponse>
        {
            private readonly IOrderDetailRepository _OrderRepository;
            private readonly IMapper _mapper;

            public UpdatedOrderCommandHandler(IOrderDetailRepository OrderRepository, IMapper mapper)
            {
                _OrderRepository = OrderRepository;
                _mapper = mapper;
            }

            public async Task<UpdatedOrderResponse> Handle(UpdatedOrderCommand request, CancellationToken cancellationToken)
            {
                OrderDetail? Order = await _OrderRepository.GetByFilterAsync(c => c.OrderID == request.OrderID);

                Order = _mapper.Map(request, Order);

                await _OrderRepository.UpdateAsync(Order);

                return _mapper.Map<UpdatedOrderResponse>(Order);

            }
        }
    }
}
