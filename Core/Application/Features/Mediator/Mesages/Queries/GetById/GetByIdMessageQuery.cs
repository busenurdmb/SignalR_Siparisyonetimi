using Application.Repositories;
using AutoMapper;
using MediatR;


namespace Application.Features.Mediator.Mesages.Queries.GetById
{
	
	public class GetByIdMessageQuery : IRequest<GetByIdMessageResponse>
	{
		public int Id { get; set; }
		public class GetByIdMessageQueryHandler : IRequestHandler<GetByIdMessageQuery, GetByIdMessageResponse>
		{
			private readonly IMessageRepository _MessageRepository;
			private readonly IMapper _mapper;

			public GetByIdMessageQueryHandler(IMessageRepository MessageRepository, IMapper mapper)
			{
				_MessageRepository = MessageRepository;
				_mapper = mapper;
			}

			public async Task<GetByIdMessageResponse> Handle(GetByIdMessageQuery request, CancellationToken cancellationToken)
			{
				var Message = await _MessageRepository.GetByFilterAsync(c => c.MessageID == request.Id);
				return _mapper.Map<GetByIdMessageResponse>(Message);
			}
		}

	}
}
