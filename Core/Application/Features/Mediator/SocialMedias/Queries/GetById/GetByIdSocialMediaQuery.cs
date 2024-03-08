using Application.Features.Mediator.SocialMedias.Queries.GetById;
using Application.Repositories;
using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Mediator.SocialMedias.Queries.GetById
{
    public class GetByIdSocialMediaQuery : IRequest<GetByIdSocialMediaResponse>
    {
        public int Id { get; set; }
        public class GetByIdSocialMediaQueryHandler : IRequestHandler<GetByIdSocialMediaQuery, GetByIdSocialMediaResponse>
        {
            private readonly ISocialMediaRepository _SocialMediaRepository;
            private readonly IMapper _mapper;

            public GetByIdSocialMediaQueryHandler(ISocialMediaRepository SocialMediaRepository, IMapper mapper)
            {
                _SocialMediaRepository = SocialMediaRepository;
                _mapper = mapper;
            }

            public async Task<GetByIdSocialMediaResponse> Handle(GetByIdSocialMediaQuery request, CancellationToken cancellationToken)
            {
                var SocialMedia = await _SocialMediaRepository.GetByFilterAsync(c => c.SocialMediaID == request.Id);
                return _mapper.Map<GetByIdSocialMediaResponse>(SocialMedia);
            }
        }

    }
}
