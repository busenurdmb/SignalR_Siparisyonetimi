using Application.Features.Mediator.Categories.Queries.GetCategoryCount;
using Application.Features.Mediator.Categories.Queries.GetList;
using Application.Features.Mediator.Products.Queries.GetProductCount;
using Application.Repositories;
using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Mediator.Categories.Queries.GetProductCount
{

        public class GetCategoryCountQuery : IRequest<GetCategoryCountResponse>
    {
        public class GetCategoryCountQueryHandler : IRequestHandler<GetCategoryCountQuery, GetCategoryCountResponse>
        {
            private readonly ICategoryRepository _categoryRepository;
            private readonly IMapper _mapper;

            public GetCategoryCountQueryHandler(ICategoryRepository categoryRepository, IMapper mapper)
            {
                _categoryRepository = categoryRepository;
                _mapper = mapper;
            }

            public async Task<GetCategoryCountResponse> Handle(GetCategoryCountQuery request, CancellationToken cancellationToken)
            {
                int category =  _categoryRepository.CategoryCount();

                return _mapper.Map<GetCategoryCountResponse>(category);
            }
        }
    }

}
