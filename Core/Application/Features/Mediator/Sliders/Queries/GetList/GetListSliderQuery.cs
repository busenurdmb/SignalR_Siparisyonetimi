
using Application.Features.Mediator.Sliders.Queries.GetList;
using Application.Repositories;
using AutoMapper;
using MediatR;


namespace Application.Features.Mediator.Sliders.Queries.GetList
{
    public class GetListSliderQuery : IRequest<List<GetListSliderResponse>>
    {
        public class GetListSliderQueryHandler : IRequestHandler<GetListSliderQuery, List<GetListSliderResponse>>
        {
            private readonly ISliderRepository _SliderRepository;
            private readonly IMapper _mapper;

            public GetListSliderQueryHandler(ISliderRepository SliderRepository, IMapper mapper)
            {
                _SliderRepository = SliderRepository;
                _mapper = mapper;
            }

            public async Task<List<GetListSliderResponse>> Handle(GetListSliderQuery request, CancellationToken cancellationToken)
            {
                var Slider = await _SliderRepository.GetAllAsync();
                return _mapper.Map<List<GetListSliderResponse>>(Slider);
            }
        }
    }
}
