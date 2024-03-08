using Application.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Mediator.Categories.Commands.Delete
{
    public class DeletedCategoryCommand:IRequest<DeletedCategoryResponse>
    {
        public int Id { get; set; }

        public class DeletedCategoryCommandHandler : IRequestHandler<DeletedCategoryCommand, DeletedCategoryResponse>
        {
            private readonly ICategoryRepository _categoryRepository;
            private readonly IMapper _mapper;

            public DeletedCategoryCommandHandler(ICategoryRepository categoryRepository, IMapper mapper)
            {
                _categoryRepository = categoryRepository;
                _mapper = mapper;
            }

            public async Task<DeletedCategoryResponse> Handle(DeletedCategoryCommand request, CancellationToken cancellationToken)
            {
                Category? category = await _categoryRepository.GetByFilterAsync(c=>c.CategoryID==request.Id);

                await _categoryRepository.RemoveAsync(category);

                return _mapper.Map<DeletedCategoryResponse>(category);

            }
        }
    }
}
