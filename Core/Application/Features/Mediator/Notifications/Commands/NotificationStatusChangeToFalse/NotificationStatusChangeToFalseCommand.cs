using Application.Features.Mediator.Notifications.Commands.NotificationStatusChangeToTrue;
using Application.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Mediator.Notifications.Commands.NotificationStatusChangeToFalse
{
   public class NotificationStatusChangeToFalseCommand:IRequest<NotificationStatusChangeToFalseResponse>
    {
        public int NotificationID { get; set; }

        public class NotificationStatusChangeToFalseCommandHandler : IRequestHandler<NotificationStatusChangeToFalseCommand, NotificationStatusChangeToFalseResponse>
        {
            private readonly INotificationRepository _notificationRepository;
            private readonly IMapper _mapper;

            public NotificationStatusChangeToFalseCommandHandler(INotificationRepository notificationRepository, IMapper mapper)
            {
                _notificationRepository = notificationRepository;
                _mapper = mapper;
            }

            public async Task<NotificationStatusChangeToFalseResponse> Handle(NotificationStatusChangeToFalseCommand request, CancellationToken cancellationToken)
            {
                Notification? notification = await _notificationRepository.GetByFilterAsync(x => x.NotificationID == request.NotificationID);
                notification = _mapper.Map(request, notification);
                await _notificationRepository.NotificationStatusChangeToFalse(notification.NotificationID);
                return _mapper.Map<NotificationStatusChangeToFalseResponse>(notification);
            }
        }
    }
}
