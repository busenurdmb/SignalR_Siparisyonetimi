using Application.Features.Mediator.Categories.Commands.Create;
using Application.Features.Mediator.Categories.Commands.Delete;
using Application.Features.Mediator.Categories.Commands.Update;
using Application.Features.Mediator.Categories.Queries.GetById;
using Application.Features.Mediator.Categories.Queries.GetList;
using Application.Features.Mediator.Categories.Queries.GetProductsWithCategories;
using Application.Features.Mediator.Products.Queries.GetProductAvgPriceByHamburger;
using Application.Features.Mediator.Products.Queries.GetProductCount;
using Application.Features.Mediator.Products.Queries.GetProductCountByCategoryNameDrink;
using Application.Features.Mediator.Products.Queries.GetProductCountByCategoryNameHamburger;
using Application.Features.Mediator.Products.Queries.GetProductNameByMaxPrice;
using Application.Features.Mediator.Products.Queries.GetProductNameByMinPrice;
using Application.Features.Mediator.Products.Queries.GetProductPriceAvg;
using Application.Features.Mediator.Products.Queries.GetProductPriceBySteakBurger;
using Application.Features.Mediator.Products.Queries.GetTotalPriceByDrinkCategory;
using Application.Features.Mediator.Products.Queries.GetTotalPriceBySaladCategory;
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

            CreateMap<int, GetProductCountResponse>().ForMember(des => des.count, opt => opt.MapFrom(src => src));
            CreateMap<decimal, GetProductAvgPriceByHamburgerResponse>().ForMember(des => des.avgprice, opt => opt.MapFrom(src => src));
            CreateMap<int, GetProductCountByCategoryNameDrinkResponse>().ForMember(des => des.countdrink, opt => opt.MapFrom(src => src));
            CreateMap<int, GetProductCountByCategoryNameHamburgerResponse>().ForMember(des => des.counthamburger, opt => opt.MapFrom(src => src));
            CreateMap<string, GetProductNameByMaxPriceResponse>().ForMember(des => des.name, opt => opt.MapFrom(src => src));
            CreateMap<string, GetProductNameByMinPriceResponse>().ForMember(des => des.name, opt => opt.MapFrom(src => src));
            CreateMap<decimal, GetProductPriceAvgResponse>().ForMember(des => des.avg, opt => opt.MapFrom(src => src));
            CreateMap<decimal, GetProductPriceBySteakBurgerResponse>().ForMember(des => des.price, opt => opt.MapFrom(src => src));
            CreateMap<decimal, GetTotalPriceByDrinkCategoryResponse>().ForMember(des => des.pricesum, opt => opt.MapFrom(src => src));
            CreateMap<decimal, GetTotalPriceBySaladCategoryResponse>().ForMember(des => des.pricesalad, opt => opt.MapFrom(src => src));



        }
    }
}
