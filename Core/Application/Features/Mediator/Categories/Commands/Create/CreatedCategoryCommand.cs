using Application.Features.Mediator.Categories .Commands.Create;
using Application.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Mediator.Categories  .Commands.Create
{
    public class CreatedCategoryCommand:IRequest<CreatedCategoryResponse>
    {
      public string CategoryName { get; set; }
        public bool Status { get; set; }

        public class CreatedCategoryCommandHandler : IRequestHandler<CreatedCategoryCommand, CreatedCategoryResponse>
        {
            private readonly ICategoryRepository _categoryRepository;
            private readonly IMapper _mapper;

            public CreatedCategoryCommandHandler(ICategoryRepository categoryRepository, IMapper mapper)
            {
                _categoryRepository = categoryRepository;
                _mapper = mapper;
            }

            public async Task<CreatedCategoryResponse> Handle(CreatedCategoryCommand request, CancellationToken cancellationToken)
            {
                var category = _mapper.Map<Category>(request);
                 await _categoryRepository.CreateAsync(category);
                return _mapper.Map<CreatedCategoryResponse>(category);
            }
        }
    }
}
