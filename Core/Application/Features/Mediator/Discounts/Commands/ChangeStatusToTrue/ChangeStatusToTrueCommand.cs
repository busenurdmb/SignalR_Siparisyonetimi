using Application.Features.Mediator.Discounts.Commands.ChangeStatusToTrue;
using Application.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Mediator.Discounts.Commands.ChangeStatusToTrue
{
	
	public class ChangeStatusToTrueCommand : IRequest<ChangeStatusToTrueResponse>
	{
		public int DiscountID { get; set; }
		public class ChangeStatusToTrueCommandHandler : IRequestHandler<ChangeStatusToTrueCommand, ChangeStatusToTrueResponse>
		{
			private readonly IDiscountRepository _DiscountRepository;
			private readonly IMapper _mapper;

			public ChangeStatusToTrueCommandHandler(IDiscountRepository DiscountRepository, IMapper mapper)
			{
				_DiscountRepository = DiscountRepository;
				_mapper = mapper;
			}

			public async Task<ChangeStatusToTrueResponse> Handle(ChangeStatusToTrueCommand request, CancellationToken cancellationToken)
			{
				Discount? Discount = await _DiscountRepository.GetByFilterAsync(x => x.DiscountID == request.DiscountID);
				Discount = _mapper.Map(request, Discount);
				await _DiscountRepository.ChangeStatusToTrue(Discount.DiscountID);
				return _mapper.Map<ChangeStatusToTrueResponse>(Discount);
			}
		}
	}
}
