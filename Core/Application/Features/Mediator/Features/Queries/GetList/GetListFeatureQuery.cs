
using Application.Repositories;
using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Mediator.Features.Queries.GetList
{
    public class GetListFeatureQuery : IRequest<List<GetListFeatureResponse>>
    {
        public class GetListFeatureQueryHandler : IRequestHandler<GetListFeatureQuery, List<GetListFeatureResponse>>
        {
            private readonly IFeatureRepository _FeatureRepository;
            private readonly IMapper _mapper;

            public GetListFeatureQueryHandler(IFeatureRepository FeatureRepository, IMapper mapper)
            {
                _FeatureRepository = FeatureRepository;
                _mapper = mapper;
            }

            public async Task<List<GetListFeatureResponse>> Handle(GetListFeatureQuery request, CancellationToken cancellationToken)
            {
                var Feature = await _FeatureRepository.GetAllAsync();
                return _mapper.Map<List<GetListFeatureResponse>>(Feature);
            }
        }
    }
}
