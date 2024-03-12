using Application.Features.Mediator.SocialMedias.Commands.Create;
using Application.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Mediator.SocialMedias
    .Commands.Create
{
    public class CreatedSocialMediaCommand : IRequest<CreatedSocialMediaResponse>
    {
        public string Title { get; set; }
        public string Url { get; set; }
        public string Icon { get; set; }
        public class CreatedSocialMediaCommandHandler : IRequestHandler<CreatedSocialMediaCommand, CreatedSocialMediaResponse>
        {
            private readonly ISocialMediaRepository _SocialMediaRepository;
            private readonly IMapper _mapper;

            public CreatedSocialMediaCommandHandler(ISocialMediaRepository SocialMediaRepository, IMapper mapper)
            {
                _SocialMediaRepository = SocialMediaRepository;
                _mapper = mapper;
            }

            public async Task<CreatedSocialMediaResponse> Handle(CreatedSocialMediaCommand request, CancellationToken cancellationToken)
            {
                var socialMedia = _mapper.Map<Domain.Entities.SocialMedia>(request);
                await _SocialMediaRepository.CreateAsync(socialMedia);
                return _mapper.Map<CreatedSocialMediaResponse>(socialMedia);
            }
        }
    }

}
