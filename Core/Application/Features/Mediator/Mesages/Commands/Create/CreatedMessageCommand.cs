using Application.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;


namespace Application.Features.Mediator.Mesages.Commands.Create
{
	
	public class CreatedMessageCommand : IRequest<CreatedMessageResponse>
	{

		public string NameSurname { get; set; }
		public string Mail { get; set; }
		public string Phone { get; set; }
		public string Subject { get; set; }
		public string MessageContent { get; set; }
		public DateTime MessageSendDate { get; set; }
		public bool Status { get; set; }
		public class CreatedMessageCommandHandler : IRequestHandler<CreatedMessageCommand, CreatedMessageResponse>
		{
			private readonly IMessageRepository _MessageRepository;
			private readonly IMapper _mapper;

			public CreatedMessageCommandHandler(IMessageRepository MessageRepository, IMapper mapper)
			{
				_MessageRepository = MessageRepository;
				_mapper = mapper;
			}

			public async Task<CreatedMessageResponse> Handle(CreatedMessageCommand request, CancellationToken cancellationToken)
			{
				var Message = _mapper.Map<Message>(request);
				await _MessageRepository.CreateAsync(Message);
				return _mapper.Map<CreatedMessageResponse>(Message);
			}
		}
	}
}
