using Application.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;


namespace Application.Features.Mediator.Notifications.Commands.Delete
{
	
	public class DeletedNotificationCommand : IRequest<DeletedNotificationResponse>
	{
		public int Id { get; set; }

		public class DeletedNotificationCommandHandler : IRequestHandler<DeletedNotificationCommand, DeletedNotificationResponse>
		{
			private readonly INotificationRepository _NotificationRepository;
			private readonly IMapper _mapper;

			public DeletedNotificationCommandHandler(INotificationRepository NotificationeRepository, IMapper mapper)
			{
				_NotificationRepository = NotificationeRepository;
				_mapper = mapper;
			}

			public async Task<DeletedNotificationResponse> Handle(DeletedNotificationCommand request, CancellationToken cancellationToken)
			{
				Notification? Notification = await _NotificationRepository.GetByFilterAsync(c => c.NotificationID == request.Id);

				await _NotificationRepository.RemoveAsync(Notification);

				return _mapper.Map<DeletedNotificationResponse>(Notification);

			}
		}
	}
}
