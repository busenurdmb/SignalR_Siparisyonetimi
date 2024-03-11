using Application.Features.Mediator.OrderDetails.Commands.Create;
using Application.Features.Mediator.OrderDetails.Commands.Delete;
using Application.Features.Mediator.OrderDetails.Queries.GetById;
using Application.Features.Mediator.OrderDetails.Queries.GetList;
using Application.Features.Mediator.OrderDetailsDetails.Commands.Create;
using Application.Features.Mediator.Orders.Commands.Delete;
using Application.Features.Mediator.Orders.Commands.Update;
using AutoMapper;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Mediator.OrderDetailsDetails.Profiles
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {
            CreateMap<OrderDetail, CreatedOrderDetailsCommand>().ReverseMap();
            CreateMap<OrderDetail, CreatedOrderDetailsResponse>().ReverseMap();

            CreateMap<OrderDetail, UpdatedOrderCommand>().ReverseMap();
            CreateMap<OrderDetail, UpdatedOrderResponse>().ReverseMap();

            CreateMap<OrderDetail, DeletedOrderDetailsCommand>().ReverseMap();
            CreateMap<OrderDetail, DeletedOrderDetailsResponse>().ReverseMap();

            CreateMap<OrderDetail, GetListOrderDetailsResponse>().ReverseMap();
            CreateMap<OrderDetail, GetByIdOrderDetailsResponse>().ReverseMap();

        }
    }
}
