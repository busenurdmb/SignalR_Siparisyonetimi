using Application.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Mediator.Categories.Commands.Update
{ 
    public class UpdatedCategoryCommand:IRequest<UpdatedCategoryResponse>
    {
        public int CategoryID { get; set; }
        public string CategoryName { get; set; }
        public bool Status { get; set; }

        public class UpdatedCategoryCommandHandler : IRequestHandler<UpdatedCategoryCommand, UpdatedCategoryResponse>
        {
            private readonly ICategoryRepository _categoryRepository;
            private readonly IMapper _mapper;

            public UpdatedCategoryCommandHandler(ICategoryRepository categoryRepository, IMapper mapper)
            {
                _categoryRepository = categoryRepository;
                _mapper = mapper;
            }

            public async Task<UpdatedCategoryResponse> Handle(UpdatedCategoryCommand request, CancellationToken cancellationToken)
            {
                Category? category=await _categoryRepository.GetByFilterAsync(c=>c.CategoryID==request.CategoryID);

                category =_mapper.Map(request,category);

                await _categoryRepository.UpdateAsync(category);

                return _mapper.Map<UpdatedCategoryResponse>(category);

            }
        }
    }
}
