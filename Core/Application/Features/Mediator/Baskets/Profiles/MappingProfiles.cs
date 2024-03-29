﻿using Application.Features.Mediator.Baskets.Commands.Create;
using Application.Features.Mediator.Baskets.Commands.Delete;
using Application.Features.Mediator.Baskets.Commands.Update;
using Application.Features.Mediator.Baskets.Queries.BasketListByMenuTableWithProductName;
using Application.Features.Mediator.Baskets.Queries.GetBasketByMenuTableNumber;
using Application.Features.Mediator.Baskets.Queries.GetById;
using Application.Features.Mediator.Baskets.Queries.GetList;
using Application.Features.Mediator.Categories.Queries.GetProductsWithCategories;
using AutoMapper;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Mediator.Baskets.Profiles
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {
            CreateMap<Basket, CreatedBasketCommand>().ReverseMap();
            CreateMap<Basket, CreatedBasketResponse>().ReverseMap();

            CreateMap<Basket, UpdateBasketCommand>().ReverseMap();
            CreateMap<Basket, UpdateBasketResponse>().ReverseMap();

            CreateMap<Basket, DeleteBasketCommand>().ReverseMap();
            CreateMap<Basket, DeleteBasketResponse>().ReverseMap();

            CreateMap<Basket, GetListBasketResponse>().ReverseMap();
            CreateMap<Basket, GetByIdBasketResponse>().ReverseMap();
            CreateMap<Basket, GetBasketByMenuTableNumberResponse>().ReverseMap();

            CreateMap<Basket, BasketListByMenuTableWithProductNameResponse>()
          .ForMember(dest => dest.ProductName, opt => opt.MapFrom(src => src.Product.ProductName))
          .ReverseMap();
            

        }
    }
}
