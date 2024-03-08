using Application.Repositories;
using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Mediator.Categories.Queries.GetById
{
    public class GetByIdCategoryQuery:IRequest<GetByIdCategoryResponse>
    {
        public int Id { get; set; }
        public class GetByIdCategoryQueryHandler : IRequestHandler<GetByIdCategoryQuery, GetByIdCategoryResponse>
        {
            private readonly ICategoryRepository _categoryRepository;
            private readonly IMapper _mapper;

            public GetByIdCategoryQueryHandler(ICategoryRepository categoryRepository, IMapper mapper)
            {
                _categoryRepository = categoryRepository;
                _mapper = mapper;
            }

            public async Task<GetByIdCategoryResponse> Handle(GetByIdCategoryQuery request, CancellationToken cancellationToken)
            {
                var category = await _categoryRepository.GetByFilterAsync(c => c.CategoryID == request.Id);
                return _mapper.Map<GetByIdCategoryResponse>(category);
            }
        }

    }
}
