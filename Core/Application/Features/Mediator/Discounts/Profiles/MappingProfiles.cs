using Application.Features.Mediator.Discounts.Commands.ChangeStatusToFalse;
using Application.Features.Mediator.Discounts.Commands.ChangeStatusToTrue;
using Application.Features.Mediator.Discounts.Commands.Create;
using Application.Features.Mediator.Discounts.Commands.Delete;
using Application.Features.Mediator.Discounts.Commands.Update;
using Application.Features.Mediator.Discounts.Queries.GetById;
using Application.Features.Mediator.Discounts.Queries.GetList;
using Application.Features.Mediator.Discounts.Queries.GetListByStatusTrue;
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

			CreateMap<Discount, ChangeStatusToFalseCommand>().ReverseMap();
			CreateMap<Discount, ChangeStatusToFalseResponse>().ReverseMap();

			CreateMap<Discount, ChangeStatusToTrueCommand>().ReverseMap();
			CreateMap<Discount, ChangeStatusToTrueResponse>().ReverseMap();
			

			CreateMap<Discount, UpdatedDiscountCommand>().ReverseMap();
            CreateMap<Discount, UpdatedDiscountResponse>().ReverseMap();

            CreateMap<Discount, DeletedDiscountCommand>().ReverseMap();
            CreateMap<Discount, DeletedDiscountResponse>().ReverseMap();

            CreateMap<Discount, GetListDiscountResponse>().ReverseMap();
            CreateMap<Discount, GetListByStatusTrueResponse>().ReverseMap();
            CreateMap<Discount, GetByIdDiscountResponse>().ReverseMap();

        }
    }
}
