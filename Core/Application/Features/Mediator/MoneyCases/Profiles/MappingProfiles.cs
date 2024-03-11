using Application.Features.Mediator.MoneyCases.Queries;
using Application.Features.Mediator.Orders.Commands.Create;
using Application.Features.Mediator.Orders.Commands.Delete;
using Application.Features.Mediator.Orders.Commands.Update;
using Application.Features.Mediator.Orders.Queries.GetActiveOrderCount;
using Application.Features.Mediator.Orders.Queries.GetById;
using Application.Features.Mediator.Orders.Queries.GetLastOrderPrice;
using Application.Features.Mediator.Orders.Queries.GetList;
using Application.Features.Mediator.Orders.Queries.GetOrderCount;
using AutoMapper;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Mediator.MoneyCases.Profiles
{
   
    public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {
           
          

            CreateMap<decimal, GetTotalMoneyCaseAmountResponse>().ForMember(des => des.Moneycasa, opt => opt.MapFrom(src => src));
        }
    }
}
