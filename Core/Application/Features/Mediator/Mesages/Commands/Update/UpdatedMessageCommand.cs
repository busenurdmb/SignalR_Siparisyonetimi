using Application.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;


namespace Application.Features.Mediator.Mesages.Commands.Update
{
	
	public class UpdatedMessageCommand : IRequest<UpdatedMessageResponse>
	{
		public int MessageID { get; set; }
		public string NameSurname { get; set; }
		public string Mail { get; set; }
		public string Phone { get; set; }
		public string Subject { get; set; }
		public string MessageContent { get; set; }
		public DateTime MessageSendDate { get; set; }
		public bool Status { get; set; }

		public class UpdatedMessageCommandHandler : IRequestHandler<UpdatedMessageCommand, UpdatedMessageResponse>
		{
			private readonly IMessageRepository _MessageRepository;
			private readonly IMapper _mapper;

			public UpdatedMessageCommandHandler(IMessageRepository MessageRepository, IMapper mapper)
			{
				_MessageRepository = MessageRepository;
				_mapper = mapper;
			}

			public async Task<UpdatedMessageResponse> Handle(UpdatedMessageCommand request, CancellationToken cancellationToken)
			{
				Message? Message = await _MessageRepository.GetByFilterAsync(c => c.MessageID == request.MessageID);

				Message = _mapper.Map(request, Message);

				await _MessageRepository.UpdateAsync(Message);

				return _mapper.Map<UpdatedMessageResponse>(Message);

			}
		}
	}
}
