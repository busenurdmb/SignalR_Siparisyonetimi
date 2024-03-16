using Application.Features.Mediator.Notifications.Queries.GetList;
using Application.Repositories;
using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Mediator.Notifications.Queries.GetList
{
	public class GetListNotificationQuery : IRequest<List<GetListNotificationResponse>>
	{
		public class GetListNotificationQueryHandler : IRequestHandler<GetListNotificationQuery, List<GetListNotificationResponse>>
		{
			private readonly INotificationRepository _NotificationRepository;
			private readonly IMapper _mapper;

			public GetListNotificationQueryHandler(INotificationRepository NotificationRepository, IMapper mapper)
			{
				_NotificationRepository = NotificationRepository;
				_mapper = mapper;
			}

			public async Task<List<GetListNotificationResponse>> Handle(GetListNotificationQuery request, CancellationToken cancellationToken)
			{
				var Notification = await _NotificationRepository.GetAllAsync();
				return _mapper.Map<List<GetListNotificationResponse>>(Notification);
			}
		}
	}
}
