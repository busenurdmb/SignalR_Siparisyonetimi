using Application.Features.Mediator.Discounts.Queries.GetList;
using Application.Repositories;
using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Mediator.Discounts.Queries.GetListByStatusTrue
{

	public class GetListByStatusTrueQuery : IRequest<List<GetListByStatusTrueResponse>>
	{
		public class GetListByStatusTrueQueryHandler : IRequestHandler<GetListByStatusTrueQuery, List<GetListByStatusTrueResponse>>
		{
			private readonly IDiscountRepository _DiscountRepository;
			private readonly IMapper _mapper;

			public GetListByStatusTrueQueryHandler(IDiscountRepository DiscountRepository, IMapper mapper)
			{
				_DiscountRepository = DiscountRepository;
				_mapper = mapper;
			}

			public async Task<List<GetListByStatusTrueResponse>> Handle(GetListByStatusTrueQuery request, CancellationToken cancellationToken)
			{
				var Discount = _DiscountRepository.GetListByStatusTrue();
				return _mapper.Map<List<GetListByStatusTrueResponse>>(Discount);
			}
		}
	}
}
