using Application.Features.Mediator.Discounts.Commands.Update;
using Application.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Mediator.Discounts.Commands.Update
{
    public class UpdatedDiscountCommand : IRequest<UpdatedDiscountResponse>
    {
        public int DiscountID { get; set; }
        public string Title { get; set; }
        public string Amount { get; set; }
        public string Description { get; set; }
        public string ImageUrl { get; set; }
        public bool Status { get; set; }

        public class UpdatedDiscountCommandHandler : IRequestHandler<UpdatedDiscountCommand, UpdatedDiscountResponse>
        {
            private readonly IDiscountRepository _DiscountRepository;
            private readonly IMapper _mapper;

            public UpdatedDiscountCommandHandler(IDiscountRepository DiscountRepository, IMapper mapper)
            {
                _DiscountRepository = DiscountRepository;
                _mapper = mapper;
            }

            public async Task<UpdatedDiscountResponse> Handle(UpdatedDiscountCommand request, CancellationToken cancellationToken)
            {
                Discount? discount = await _DiscountRepository.GetByFilterAsync(c => c.DiscountID == request.DiscountID);

                discount = _mapper.Map(request, discount);

                await _DiscountRepository.UpdateAsync(discount);

                return _mapper.Map<UpdatedDiscountResponse>(discount);

            }
        }
    }
}
