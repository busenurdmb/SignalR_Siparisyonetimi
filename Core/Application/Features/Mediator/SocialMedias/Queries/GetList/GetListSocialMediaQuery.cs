
using Application.Repositories;
using AutoMapper;
using MediatR;


namespace Application.Features.Mediator.SocialMedias.Queries.GetList
{
    public class GetListSocialMediaQuery : IRequest<List<GetListSocialMediaResponse>>
    {
        public class GetListSocialMediaQueryHandler : IRequestHandler<GetListSocialMediaQuery, List<GetListSocialMediaResponse>>
        {
            private readonly ISocialMediaRepository _SocialMediaRepository;
            private readonly IMapper _mapper;

            public GetListSocialMediaQueryHandler(ISocialMediaRepository SocialMediaRepository, IMapper mapper)
            {
                _SocialMediaRepository = SocialMediaRepository;
                _mapper = mapper;
            }

            public async Task<List<GetListSocialMediaResponse>> Handle(GetListSocialMediaQuery request, CancellationToken cancellationToken)
            {
                var SocialMedia = await _SocialMediaRepository.GetAllAsync();
                return _mapper.Map<List<GetListSocialMediaResponse>>(SocialMedia);
            }
        }
    }
}
