using Application.Features.Mediator.Discounts.Commands.ChangeStatusToFalse;
using Application.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Mediator.Discounts.Commands.ChangeStatusToFalse
{

	public class ChangeStatusToFalseCommand : IRequest<ChangeStatusToFalseResponse>
	{
		public int DiscountID { get; set; }
		public class ChangeStatusToFalseCommandHandler : IRequestHandler<ChangeStatusToFalseCommand, ChangeStatusToFalseResponse>
		{
			private readonly IDiscountRepository _DiscountRepository;
			private readonly IMapper _mapper;

			public ChangeStatusToFalseCommandHandler(IDiscountRepository DiscountRepository, IMapper mapper)
			{
				_DiscountRepository = DiscountRepository;
				_mapper = mapper;
			}

			public async Task<ChangeStatusToFalseResponse> Handle(ChangeStatusToFalseCommand request, CancellationToken cancellationToken)
			{
				Discount? Discount = await _DiscountRepository.GetByFilterAsync(x => x.DiscountID == request.DiscountID);
				Discount = _mapper.Map(request, Discount);
				await _DiscountRepository.ChangeStatusToFalse(Discount.DiscountID);
				return _mapper.Map<ChangeStatusToFalseResponse>(Discount);
			}
		}
	}
}
