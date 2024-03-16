using Application.Features.Mediator.Notifications.Queries.GetById;
using Application.Repositories;
using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Mediator.Notifications.Queries.GetById
{
	
	public class GetByIdNotificationQuery : IRequest<GetByIdNotificationResponse>
	{
		public int Id { get; set; }
		public class GetByIdNotificationQueryHandler : IRequestHandler<GetByIdNotificationQuery, GetByIdNotificationResponse>
		{
			private readonly INotificationRepository _MenuRepository;
			private readonly IMapper _mapper;

			public GetByIdNotificationQueryHandler(INotificationRepository MenuRepository, IMapper mapper)
			{
				_MenuRepository = MenuRepository;
				_mapper = mapper;
			}

			public async Task<GetByIdNotificationResponse> Handle(GetByIdNotificationQuery request, CancellationToken cancellationToken)
			{
				var Menu = await _MenuRepository.GetByFilterAsync(c => c.NotificationID == request.Id);
				return _mapper.Map<GetByIdNotificationResponse>(Menu);
			}
		}

	}
}
