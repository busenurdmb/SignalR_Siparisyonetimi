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

namespace Application.Features.Mediator.Sliders.Commands.Update
{
    public class UpdatedSliderCommand : IRequest<UpdatedSliderResponse>
    {
        public int SliderID { get; set; }
        public string Title1 { get; set; }
        public string Title2 { get; set; }
        public string Title3 { get; set; }
        public string Description1 { get; set; }
        public string Description2 { get; set; }
        public string Description3 { get; set; }
        public class UpdatedSliderCommandHandler : IRequestHandler<UpdatedSliderCommand, UpdatedSliderResponse>
        {
            private readonly ISliderRepository _SliderRepository;
            private readonly IMapper _mapper;

            public UpdatedSliderCommandHandler(ISliderRepository SliderRepository, IMapper mapper)
            {
                _SliderRepository = SliderRepository;
                _mapper = mapper;
            }

            public async Task<UpdatedSliderResponse> Handle(UpdatedSliderCommand request, CancellationToken cancellationToken)
            {
                Slider? Slider = await _SliderRepository.GetByFilterAsync(c => c.SliderID == request.SliderID);

                Slider = _mapper.Map(request, Slider);

                await _SliderRepository.UpdateAsync(Slider);

                return _mapper.Map<UpdatedSliderResponse>(Slider);

            }
        }
    }
}
