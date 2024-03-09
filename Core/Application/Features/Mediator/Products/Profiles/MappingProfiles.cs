using Application.Features.Mediator.Products.Commands.Create;
using Application.Features.Mediator.Products.Commands.Delete;
using Application.Features.Mediator.Products.Commands.Update;
using Application.Features.Mediator.Products.Queries.GetById;
using Application.Features.Mediator.Products.Queries.GetList;
using Application.Features.Mediator.Products.Queries.GetProductsWithCategories;
using Application.Products.Mediator.Products.Commands.Create;
using Application.Products.Mediator.Products.Commands.Update;
using AutoMapper;
using Domain.Entities;


namespace Application.Products.Mediator.Products.Profiles
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {
            CreateMap<Product, CreatedProductCommand>().ReverseMap();
            CreateMap<Product, CreatedProductResponse>().ReverseMap();

            CreateMap<Product, UpdatedProductCommand>().ReverseMap();
            CreateMap<Product, UpdatedProductResponse>().ReverseMap();

            CreateMap<Product, DeletedProductCommand>().ReverseMap();
            CreateMap<Product, DeletedProductResponse>().ReverseMap();

            CreateMap<Product, GetListProductResponse>().ReverseMap();
            CreateMap<Product, GetByIdProductResponse>().ReverseMap();

            CreateMap<Product, GetListProductsWithCategoriesResponse>()
          .ForMember(dest => dest.CategoryName, opt => opt.MapFrom(src => src.Category.CategoryName))
          .ReverseMap();



        }
    }
}
