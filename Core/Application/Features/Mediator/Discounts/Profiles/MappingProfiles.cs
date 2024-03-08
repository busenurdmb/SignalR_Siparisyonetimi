using Application.Features.Mediator.Discounts.Commands.Create;
using Application.Features.Mediator.Discounts.Commands.Delete;
using Application.Features.Mediator.Discounts.Commands.Update;
using Application.Features.Mediator.Discounts.Queries.GetById;
using Application.Features.Mediator.Discounts.Queries.GetList;
using AutoMapper;
using Domain.Entities;


namespace Application.Discounts.Mediator.Discounts.Profiles
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {
            CreateMap<Discount, CreatedDiscountCommand>().ReverseMap();
            CreateMap<Discount, CreatedDiscountResponse>().ReverseMap();

            CreateMap<Discount, UpdatedDiscountCommand>().ReverseMap();
            CreateMap<Discount, UpdatedDiscountResponse>().ReverseMap();

            CreateMap<Discount, DeletedDiscountCommand>().ReverseMap();
            CreateMap<Discount, DeletedDiscountResponse>().ReverseMap();

            CreateMap<Discount, GetListDiscountResponse>().ReverseMap();
            CreateMap<Discount, GetByIdDiscountResponse>().ReverseMap();

        }
    }
}
