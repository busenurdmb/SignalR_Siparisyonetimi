using Application.Features.Mediator.Features.Commands.Update;
using Application.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Mediator.Features.Commands.Update
{
    public class UpdatedFeatureCommand : IRequest<UpdatedFeatureResponse>
    {
        public int FeatureID { get; set; }
        public string Title1 { get; set; }
        public string Description1 { get; set; }
        public string Title2 { get; set; }
        public string Description2 { get; set; }
        public string Title3 { get; set; }
        public string Description3 { get; set; }
        public class UpdatedFeatureCommandHandler : IRequestHandler<UpdatedFeatureCommand, UpdatedFeatureResponse>
        {
            private readonly IFeatureRepository _FeatureRepository;
            private readonly IMapper _mapper;

            public UpdatedFeatureCommandHandler(IFeatureRepository FeatureRepository, IMapper mapper)
            {
                _FeatureRepository = FeatureRepository;
                _mapper = mapper;
            }

            public async Task<UpdatedFeatureResponse> Handle(UpdatedFeatureCommand request, CancellationToken cancellationToken)
            {
                Feature? Feature = await _FeatureRepository.GetByFilterAsync(c => c.FeatureID == request.FeatureID);

                Feature = _mapper.Map(request, Feature);

                await _FeatureRepository.UpdateAsync(Feature);

                return _mapper.Map<UpdatedFeatureResponse>(Feature);

            }
        }
    }
}
