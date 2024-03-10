using Application.Features.Mediator.Categories.Queries.GetPassiveCategoryCount;
using Application.Repositories;
using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Mediator.Categories.Queries.GetPassiveCatgeoryCount
{
    public class GetPassiveCategoryCountQuery : IRequest<GetPassiveCategoryCountResponse>
    {
        public class GetPassiveCategoryCountQueryHandler : IRequestHandler<GetPassiveCategoryCountQuery, GetPassiveCategoryCountResponse>
        {
            private readonly ICategoryRepository _CategoryRepository;
            private readonly IMapper _mapper;

            public GetPassiveCategoryCountQueryHandler(ICategoryRepository CategoryRepository, IMapper mapper)
            {
                _CategoryRepository = CategoryRepository;
                _mapper = mapper;
            }

            public async Task<GetPassiveCategoryCountResponse> Handle(GetPassiveCategoryCountQuery request, CancellationToken cancellationToken)
            {
                int PassiveCategory = _CategoryRepository.PassiveCategoryCount();

                return _mapper.Map<GetPassiveCategoryCountResponse>(PassiveCategory);
            }
        }
    }
}
