using Application.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;


namespace Application.Features.Mediator.Notifications.Commands.Update
{
	
	public class UpdatedNotificationCommand : IRequest<UpdatedNotificationResponse>
	{
		public int NotificationID { get; set; }
		public string Type { get; set; }
		public string Icon { get; set; }
		public string Description { get; set; }
		public DateTime Date { get; set; }
		public bool Status { get; set; }
		public class UpdatedNotificationCommandHandler : IRequestHandler<UpdatedNotificationCommand, UpdatedNotificationResponse>
		{
			private readonly INotificationRepository _NotificationRepository;
			private readonly IMapper _mapper;

			public UpdatedNotificationCommandHandler(INotificationRepository NotificationRepository, IMapper mapper)
			{
				_NotificationRepository = NotificationRepository;
				_mapper = mapper;
			}

			public async Task<UpdatedNotificationResponse> Handle(UpdatedNotificationCommand request, CancellationToken cancellationToken)
			{
				Notification? Notification = await _NotificationRepository.GetByFilterAsync(c => c.NotificationID == request.NotificationID);

				Notification = _mapper.Map(request, Notification);

				await _NotificationRepository.UpdateAsync(Notification);

				return _mapper.Map<UpdatedNotificationResponse>(Notification);

			}
		}
	}
}
