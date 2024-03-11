using Application.Features.Mediator.Categories.Commands.Delete;
using Application.Features.Mediator.Features.Commands.Delete;
using Application.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Mediator.OrderDetails.Commands.Delete
{
   
    public class DeletedOrderDetailsCommand : IRequest<DeletedOrderDetailsResponse>
    {
        public int Id { get; set; }

        public class DeletedOrderDetailsCommandHandler : IRequestHandler<DeletedOrderDetailsCommand, DeletedOrderDetailsResponse>
        {
            
            private readonly IOrderDetailRepository _OrderDetailsRepository;
            private readonly IMapper _mapper;

          

            public DeletedOrderDetailsCommandHandler(IOrderDetailRepository OrderDetailsRepository, IMapper mapper)
            {
                _OrderDetailsRepository = OrderDetailsRepository;
                _mapper = mapper;
            }

            public async Task<DeletedOrderDetailsResponse> Handle(DeletedOrderDetailsCommand request, CancellationToken cancellationToken)
            {
                OrderDetail? OrderDetails = await _OrderDetailsRepository.GetByFilterAsync(c => c.OrderDetailID == request.Id);

                      await _OrderDetailsRepository.RemoveAsync(OrderDetails);

                     return _mapper.Map<DeletedOrderDetailsResponse>(OrderDetails);
            }


          
        }
    }
}
