using Application.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Mediator.Notifications.Commands.NotificationStatusChangeToTrue
{
    public class NotificationStatusChangeToTrueCommand : IRequest<NotificationStatusChangeToTrueResponse>
    {
        public int NotificationID { get; set; }
       


        public class NotificationStatusChangeToTrueCommandHandler : IRequestHandler<NotificationStatusChangeToTrueCommand, NotificationStatusChangeToTrueResponse>
        {
            private readonly INotificationRepository _notificationRepository;
            private readonly IMapper _mapper;

            public NotificationStatusChangeToTrueCommandHandler(INotificationRepository notificationRepository, IMapper mapper)
            {
                _notificationRepository = notificationRepository;
                _mapper = mapper;
            }

            public async Task<NotificationStatusChangeToTrueResponse> Handle(NotificationStatusChangeToTrueCommand request, CancellationToken cancellationToken)
            {
                Notification? notification =await  _notificationRepository.GetByFilterAsync(x=>x.NotificationID==request.NotificationID);
                notification = _mapper.Map(request, notification);
                await _notificationRepository.NotificationStatusChangeToTrue(notification.NotificationID);
                return _mapper.Map<NotificationStatusChangeToTrueResponse>(notification);
            }
        }
    }
}
