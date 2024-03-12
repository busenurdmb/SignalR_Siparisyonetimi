using Application.Features.Mediator.SocialMedias.Queries.GetById;
using Application.Repositories;
using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Mediator.Sliders.Queries.GetById
{
    public class GetByIdSliderQuery : IRequest<GetByIdSliderResponse>
    {
        public int Id { get; set; }
        public class GetByIdSliderQueryHandler : IRequestHandler<GetByIdSliderQuery, GetByIdSliderResponse>
        {
            private readonly ISliderRepository _SliderRepository;
            private readonly IMapper _mapper;

            public GetByIdSliderQueryHandler(ISliderRepository SliderRepository, IMapper mapper)
            {
                _SliderRepository = SliderRepository;
                _mapper = mapper;
            }

            public async Task<GetByIdSliderResponse> Handle(GetByIdSliderQuery request, CancellationToken cancellationToken)
            {
                var Slider = await _SliderRepository.GetByFilterAsync(c => c.SliderID == request.Id);
                return _mapper.Map<GetByIdSliderResponse>(Slider);
            }
        }

    }
}
