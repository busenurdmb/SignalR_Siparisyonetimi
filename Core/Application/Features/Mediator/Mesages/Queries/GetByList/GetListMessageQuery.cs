using Application.Repositories;
using AutoMapper;
using MediatR;


namespace Application.Features.Mediator.Mesages.Queries.GetByList
{
	
	public class GetListMessageQuery : IRequest<List<GetListMessageResponse>>
	{
		public class GetListMessageQueryHandler : IRequestHandler<GetListMessageQuery, List<GetListMessageResponse>>
		{
			private readonly IMessageRepository _MessageRepository;
			private readonly IMapper _mapper;

			public GetListMessageQueryHandler(IMessageRepository MessageRepository, IMapper mapper)
			{
				_MessageRepository = MessageRepository;
				_mapper = mapper;
			}

			public async Task<List<GetListMessageResponse>> Handle(GetListMessageQuery request, CancellationToken cancellationToken)
			{
				var Message = await _MessageRepository.GetAllAsync();
				return _mapper.Map<List<GetListMessageResponse>>(Message);
			}
		}
	}
}
