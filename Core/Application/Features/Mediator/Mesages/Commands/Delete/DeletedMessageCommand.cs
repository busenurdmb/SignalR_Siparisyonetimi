using Application.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;


namespace Application.Features.Mediator.Mesages.Commands.Delete
{
	
	public class DeletedMessageCommand : IRequest<DeletedMessageResponse>
	{
		public int Id { get; set; }

		public class DeletedMessageCommandHandler : IRequestHandler<DeletedMessageCommand, DeletedMessageResponse>
		{
			private readonly IMessageRepository _MessageRepository;
			private readonly IMapper _mapper;

			public DeletedMessageCommandHandler(IMessageRepository MessageRepository, IMapper mapper)
			{
				_MessageRepository = MessageRepository;
				_mapper = mapper;
			}

			public async Task<DeletedMessageResponse> Handle(DeletedMessageCommand request, CancellationToken cancellationToken)
			{
				Message? Message = await _MessageRepository.GetByFilterAsync(c => c.MessageID == request.Id);

				await _MessageRepository.RemoveAsync(Message);

				return _mapper.Map<DeletedMessageResponse>(Message);

			}
		}
	}
}
