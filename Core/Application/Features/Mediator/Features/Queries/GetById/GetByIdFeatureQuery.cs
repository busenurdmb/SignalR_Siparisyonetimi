using Application.Features.Mediator.Features.Queries.GetById;
using Application.Repositories;
using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Mediator.Features.Queries.GetById
{
    public class GetByIdFeatureQuery : IRequest<GetByIdFeatureResponse>
    {
        public int Id { get; set; }
        public class GetByIdFeatureQueryHandler : IRequestHandler<GetByIdFeatureQuery, GetByIdFeatureResponse>
        {
            private readonly IFeatureRepository _FeatureRepository;
            private readonly IMapper _mapper;

            public GetByIdFeatureQueryHandler(IFeatureRepository FeatureRepository, IMapper mapper)
            {
                _FeatureRepository = FeatureRepository;
                _mapper = mapper;
            }

            public async Task<GetByIdFeatureResponse> Handle(GetByIdFeatureQuery request, CancellationToken cancellationToken)
            {
                var Feature = await _FeatureRepository.GetByFilterAsync(c => c.FeatureID == request.Id);
                return _mapper.Map<GetByIdFeatureResponse>(Feature);
            }
        }

    }
}
