using Application.Features.Mediator.Orders.Commands.Create;
using Application.Features.Mediator.Orders.Commands.Delete;
using Application.Features.Mediator.Orders.Commands.Update;
using Application.Features.Mediator.Orders.Queries.GetActiveOrderCount;
using Application.Features.Mediator.Orders.Queries.GetById;
using Application.Features.Mediator.Orders.Queries.GetLastOrderPrice;
using Application.Features.Mediator.Orders.Queries.GetList;
using Application.Features.Mediator.Orders.Queries.GetOrderCount;
using Application.Features.Mediator.Products.Queries.GetProductCount;
using AutoMapper;
using Domain.Entities;

namespace Application.Features.Mediator.Orders.Profiles
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {
            CreateMap<Order, CreatedOrderCommand>().ReverseMap();
            CreateMap<Order, CreatedOrderResponse>().ReverseMap();

            CreateMap<Order, UpdatedOrderCommand>().ReverseMap();
            CreateMap<Order, UpdatedOrderResponse>().ReverseMap();

            CreateMap<Order, DeletedOrderCommand>().ReverseMap();
            CreateMap<Order, DeletedOrderResponse>().ReverseMap();

            CreateMap<Order, GetListOrderResponse>().ReverseMap();
            CreateMap<Order, GetByIdOrderResponse>().ReverseMap();

            CreateMap<int, GetOrderCountResponse>().ForMember(des => des.count, opt => opt.MapFrom(src => src));
            CreateMap<int, GetActiveOrderCountResponse>().ForMember(des => des.count, opt => opt.MapFrom(src => src));

            CreateMap<decimal, GetLastOrderPriceResponse>().ForMember(des => des.price, opt => opt.MapFrom(src => src));
        }
    }
}
