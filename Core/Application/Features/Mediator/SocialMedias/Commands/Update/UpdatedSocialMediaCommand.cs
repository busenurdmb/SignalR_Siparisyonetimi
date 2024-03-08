using Application.Features.Mediator.SocialMedias.Commands.Update;
using Application.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Mediator.SocialMedias.Commands.Update
{
    public class UpdatedSocialMediaCommand : IRequest<UpdatedSocialMediaResponse>
    {
        public int SocialMediaID { get; set; }
        public string Title { get; set; }
        public string Url { get; set; }
        public string Icon { get; set; }
        public class UpdatedSocialMediaCommandHandler : IRequestHandler<UpdatedSocialMediaCommand, UpdatedSocialMediaResponse>
        {
            private readonly ISocialMediaRepository _SocialMediaRepository;
            private readonly IMapper _mapper;

            public UpdatedSocialMediaCommandHandler(ISocialMediaRepository SocialMediaRepository, IMapper mapper)
            {
                _SocialMediaRepository = SocialMediaRepository;
                _mapper = mapper;
            }

            public async Task<UpdatedSocialMediaResponse> Handle(UpdatedSocialMediaCommand request, CancellationToken cancellationToken)
            {
                SocialMedia? SocialMedia = await _SocialMediaRepository.GetByFilterAsync(c => c.SocialMediaID == request.SocialMediaID);

                SocialMedia = _mapper.Map(request, SocialMedia);

                await _SocialMediaRepository.UpdateAsync(SocialMedia);

                return _mapper.Map<UpdatedSocialMediaResponse>(SocialMedia);

            }
        }
    }
}
