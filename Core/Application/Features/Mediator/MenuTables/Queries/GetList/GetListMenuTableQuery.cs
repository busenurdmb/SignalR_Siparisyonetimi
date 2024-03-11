
using Application.Repositories;
using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Mediator.MenuTables.Queries.GetList
{
    public class GetListMenuTableQuery : IRequest<List<GetListMenuTableResponse>>
    {
        public class GetListFeatureQueryHandler : IRequestHandler<GetListMenuTableQuery, List<GetListMenuTableResponse>>
        {
            private readonly IFeatureRepository _FeatureRepository;
            private readonly IMapper _mapper;

            public GetListFeatureQueryHandler(IFeatureRepository FeatureRepository, IMapper mapper)
            {
                _FeatureRepository = FeatureRepository;
                _mapper = mapper;
            }

            public async Task<List<GetListMenuTableResponse>> Handle(GetListMenuTableQuery request, CancellationToken cancellationToken)
            {
                var Feature = await _FeatureRepository.GetAllAsync();
                return _mapper.Map<List<GetListMenuTableResponse>>(Feature);
            }
        }
    }
}
