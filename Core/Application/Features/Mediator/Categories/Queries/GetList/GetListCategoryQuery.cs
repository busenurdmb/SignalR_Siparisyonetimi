using Application.Repositories;
using AutoMapper;
using MediatR;


namespace Application.Features.Mediator.Categories.Queries.GetList
{
    public class GetListCategoryQuery:IRequest<List<GetListCategoryResponse>>
    {
        public class GetListCategoryQueryHandler : IRequestHandler<GetListCategoryQuery, List<GetListCategoryResponse>>
        {
            private readonly ICategoryRepository _categoryRepository;
            private readonly IMapper _mapper;

            public GetListCategoryQueryHandler(ICategoryRepository categoryRepository, IMapper mapper)
            {
                _categoryRepository = categoryRepository;
                _mapper = mapper;
            }

            public async Task<List<GetListCategoryResponse>> Handle(GetListCategoryQuery request, CancellationToken cancellationToken)
            {
                var category = await _categoryRepository.GetAllAsync();
                return _mapper.Map<List<GetListCategoryResponse>>(category);
            }
        }
    }
}
