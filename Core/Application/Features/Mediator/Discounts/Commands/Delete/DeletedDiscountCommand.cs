using Application.Features.Mediator.Discounts.Commands.Delete;
using Application.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Mediator.Discounts.Commands.Delete
{
    public class DeletedDiscountCommand : IRequest<DeletedDiscountResponse>
    {
        public int Id { get; set; }

        public class DeletedDiscountCommandHandler : IRequestHandler<DeletedDiscountCommand, DeletedDiscountResponse>
        {
            private readonly IDiscountRepository _DiscountRepository;
            private readonly IMapper _mapper;

            public DeletedDiscountCommandHandler(IDiscountRepository DiscountRepository, IMapper mapper)
            {
                _DiscountRepository = DiscountRepository;
                _mapper = mapper;
            }

            public async Task<DeletedDiscountResponse> Handle(DeletedDiscountCommand request, CancellationToken cancellationToken)
            {
                Discount? Discount = await _DiscountRepository.GetByFilterAsync(c => c.DiscountID == request.Id);

                await _DiscountRepository.RemoveAsync(Discount);

                return _mapper.Map<DeletedDiscountResponse>(Discount);

            }
        }
    }
}
