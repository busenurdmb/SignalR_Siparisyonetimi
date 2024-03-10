using Application.Features.Mediator.Categories.Queries.GetActiveCategoryCount;
using Application.Repositories;
using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Mediator.Categories.Queries.GetActiveCatgeoryCount
{
   
    public class GetActiveCategoryCountQuery : IRequest<GetActiveCategoryCountResponse>
    {
        public class GetActiveCategoryCountQueryHandler : IRequestHandler<GetActiveCategoryCountQuery, GetActiveCategoryCountResponse>
        {
            private readonly ICategoryRepository _CategoryRepository;
            private readonly IMapper _mapper;

            public GetActiveCategoryCountQueryHandler(ICategoryRepository CategoryRepository, IMapper mapper)
            {
                _CategoryRepository = CategoryRepository;
                _mapper = mapper;
            }

            public async Task<GetActiveCategoryCountResponse> Handle(GetActiveCategoryCountQuery request, CancellationToken cancellationToken)
            {
                int ActiveCategory = _CategoryRepository.ActiveCategoryCount();

                return _mapper.Map<GetActiveCategoryCountResponse>(ActiveCategory);
            }
        }
    }
}
