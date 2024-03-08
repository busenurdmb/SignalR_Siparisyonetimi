using Application.Features.Mediator.SocialMedias.Commands.Delete;
using Application.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Mediator.SocialMedias.Commands.Delete
{
    public class DeletedSocialMediaCommand : IRequest<DeletedSocialMediaResponse>
    {
        public int Id { get; set; }

        public class DeletedSocialMediaCommandHandler : IRequestHandler<DeletedSocialMediaCommand, DeletedSocialMediaResponse>
        {
            private readonly ISocialMediaRepository _SocialMediaRepository;
            private readonly IMapper _mapper;

            public DeletedSocialMediaCommandHandler(ISocialMediaRepository SocialMediaRepository, IMapper mapper)
            {
                _SocialMediaRepository = SocialMediaRepository;
                _mapper = mapper;
            }

            public async Task<DeletedSocialMediaResponse> Handle(DeletedSocialMediaCommand request, CancellationToken cancellationToken)
            {
                SocialMedia? SocialMedia = await _SocialMediaRepository.GetByFilterAsync(c => c.SocialMediaID == request.Id);

                await _SocialMediaRepository.RemoveAsync(SocialMedia);

                return _mapper.Map<DeletedSocialMediaResponse>(SocialMedia);

            }
        }
    }
}
