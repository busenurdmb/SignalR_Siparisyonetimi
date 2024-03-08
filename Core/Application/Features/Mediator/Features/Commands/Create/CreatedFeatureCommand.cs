using Application.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;

namespace Application.Features.Mediator.Features.Commands.Create
{
    public class CreatedFeatureCommand : IRequest<CreatedFeatureResponse>
    {

        public string Title1 { get; set; }
        public string Description1 { get; set; }
        public string Title2 { get; set; }
        public string Description2 { get; set; }
        public string Title3 { get; set; }
        public string Description3 { get; set; }

        public class CreatedFeatureCommandHandler : IRequestHandler<CreatedFeatureCommand, CreatedFeatureResponse>
        {
            private readonly IFeatureRepository _FeatureRepository;
            private readonly IMapper _mapper;

            public CreatedFeatureCommandHandler(IFeatureRepository FeatureRepository, IMapper mapper)
            {
                _FeatureRepository = FeatureRepository;
                _mapper = mapper;
            }

            public async Task<CreatedFeatureResponse> Handle(CreatedFeatureCommand request, CancellationToken cancellationToken)
            {
                var Feature = _mapper.Map<Feature>(request);
                await _FeatureRepository.CreateAsync(Feature);
                return _mapper.Map<CreatedFeatureResponse>(Feature);
            }
        }
    }
}
