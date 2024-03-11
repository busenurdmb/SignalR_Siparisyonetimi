using Application.Features.Mediator.OrderDetails.Commands.Update;
using Application.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;

namespace Application.OrderDetailss.Mediator.OrderDetails.Commands.Update
{

    public class UpdatedOrderDetailsCommand : IRequest<UpdatedOrderDetailsResponse>
    {
        public int OrderDetailID { get; set; }
        public int ProductID { get; set; }
       public int Count { get; set; }
        public decimal UnitPrice { get; set; }
        public decimal TotalPrice { get; set; }
        public int OrderID { get; set; }
        public class UpdatedOrderDetailsCommandHandler : IRequestHandler<UpdatedOrderDetailsCommand, UpdatedOrderDetailsResponse>
        {
            private readonly IOrderDetailRepository _OrderDetailsRepository;
            private readonly IMapper _mapper;

            public UpdatedOrderDetailsCommandHandler(IOrderDetailRepository OrderDetailsRepository, IMapper mapper)
            {
                _OrderDetailsRepository = OrderDetailsRepository;
                _mapper = mapper;
            }

            public async Task<UpdatedOrderDetailsResponse> Handle(UpdatedOrderDetailsCommand request, CancellationToken cancellationToken)
            {
                OrderDetail? OrderDetails = await _OrderDetailsRepository.GetByFilterAsync(c => c.OrderDetailID == request.OrderDetailID);

                OrderDetails = _mapper.Map(request, OrderDetails);

                await _OrderDetailsRepository.UpdateAsync(OrderDetails);

                return _mapper.Map<UpdatedOrderDetailsResponse>(OrderDetails);

            }
        }
    }
}
