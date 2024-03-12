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

namespace Application.Features.Mediator.Sliders.Commands.Delete
{
    public class DeletedSliderCommand : IRequest<DeletedSliderResponse>
    {
        public int Id { get; set; }

        public class DeletedSliderCommandHandler : IRequestHandler<DeletedSliderCommand, DeletedSliderResponse>
        {
            private readonly ISliderRepository _SliderRepository;
            private readonly IMapper _mapper;

            public DeletedSliderCommandHandler(ISliderRepository SliderRepository, IMapper mapper)
            {
                _SliderRepository = SliderRepository;
                _mapper = mapper;
            }

            public async Task<DeletedSliderResponse> Handle(DeletedSliderCommand request, CancellationToken cancellationToken)
            {
                Slider? Slider = await _SliderRepository.GetByFilterAsync(c => c.SliderID == request.Id);

                await _SliderRepository.RemoveAsync(Slider);

                return _mapper.Map<DeletedSliderResponse>(Slider);

            }
        }
    }
}
