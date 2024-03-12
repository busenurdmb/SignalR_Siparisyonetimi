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

namespace Application.Features.Mediator.Sliders.Commands.Create
{
    public class CreatedSliderCommand : IRequest<CreatedSliderResponse>
    {
        
        public string Title1 { get; set; }
        public string Title2 { get; set; }
        public string Title3 { get; set; }
        public string Description1 { get; set; }
        public string Description2 { get; set; }
        public string Description3 { get; set; }
        public class CreatedSliderCommandHandler : IRequestHandler<CreatedSliderCommand, CreatedSliderResponse>
        {
            private readonly ISliderRepository _SliderRepository;
            private readonly IMapper _mapper;

            public CreatedSliderCommandHandler(ISliderRepository SliderRepository, IMapper mapper)
            {
                _SliderRepository = SliderRepository;
                _mapper = mapper;
            }

            public async Task<CreatedSliderResponse> Handle(CreatedSliderCommand request, CancellationToken cancellationToken)
            {
                var Slider = _mapper.Map<Slider>(request);
                await _SliderRepository.CreateAsync(Slider);
                return _mapper.Map<CreatedSliderResponse>(Slider);
            }
        }
    }

}
