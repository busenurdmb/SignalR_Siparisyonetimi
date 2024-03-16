using Application.Features.Mediator.Notifications.Queries.GetList;
using Application.Repositories;
using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Mediator.Notifications.Queries.GetAllNotificationByFalse
{
	internal class GetAllNotificationByFalseQuuery
	{
	}
	public class GetAllNotificationByFalseQuery : IRequest<List<GetAllNotificationByFalseResponse>>
	{
		public class GetAllNotificationByFalseQueryHandler : IRequestHandler<GetAllNotificationByFalseQuery, List<GetAllNotificationByFalseResponse>>
		{
			private readonly INotificationRepository _NotificationRepository;
			private readonly IMapper _mapper;

			public GetAllNotificationByFalseQueryHandler(INotificationRepository NotificationRepository, IMapper mapper)
			{
				_NotificationRepository = NotificationRepository;
				_mapper = mapper;
			}

			public  async Task<List<GetAllNotificationByFalseResponse>> Handle(GetAllNotificationByFalseQuery request, CancellationToken cancellationToken)
			{
				var Notification =  _NotificationRepository.GetAllNotificationByFalse();
				return  _mapper.Map<List<GetAllNotificationByFalseResponse>>(Notification);
			}
		}
	}

}
