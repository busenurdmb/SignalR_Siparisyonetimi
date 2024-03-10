
using Application.Features.Mediator.Categories.Commands.Create;
using Application.Features.Mediator.Categories.Commands.Delete;
using Application.Features.Mediator.Categories.Commands.Update;
using Application.Features.Mediator.Categories.Queries.GetActiveCategoryCount;
using Application.Features.Mediator.Categories.Queries.GetById;
using Application.Features.Mediator.Categories.Queries.GetProductCount;
using Application.Features.Mediator.Categories.Queries.GetList;
using Application.Features.Mediator.Categories.Queries.GetPassiveCategoryCount;
using AutoMapper;
using Domain.Entities;
using Application.Features.Mediator.Categories.Queries.GetCategoryCount;


namespace Application.Features.Mediator.Categories.Profiles
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {
            CreateMap<Category  , CreatedCategoryCommand>().ReverseMap();
            CreateMap<Category  , CreatedCategoryResponse>().ReverseMap();

            CreateMap<Category  , UpdatedCategoryCommand>().ReverseMap();
            CreateMap<Category  , UpdatedCategoryResponse>().ReverseMap();

            CreateMap<Category  , DeletedCategoryCommand>().ReverseMap();
            CreateMap<Category  , DeletedCategoryResponse>().ReverseMap();

            CreateMap<Category , GetListCategoryResponse>().ReverseMap();

            CreateMap<Category , GetByIdCategoryResponse>().ReverseMap();
            CreateMap<int, GetCategoryCountResponse>().ForMember(des=>des.categorycount , opt=>opt.MapFrom(src=>src));
            CreateMap<int, GetActiveCategoryCountResponse>().ForMember(des=>des.count , opt=>opt.MapFrom(src=>src));
            CreateMap<int, GetPassiveCategoryCountResponse>().ForMember(des=>des.count , opt=>opt.MapFrom(src=>src));
         
  


        }
    }
}
