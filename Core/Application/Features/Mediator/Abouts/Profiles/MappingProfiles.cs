using Application.Features.Mediator.Abouts.Commands.Create;
using Application.Features.Mediator.Abouts.Commands.Delete;
using Application.Features.Mediator.Abouts.Commands.Update;
using Application.Features.Mediator.Abouts.Queries.GetById;
using Application.Features.Mediator.Abouts.Queries.GetList;
using AutoMapper;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Mediator.Abouts.Profiles
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {
            CreateMap<About, CreatedAboutCommand>().ReverseMap();
            CreateMap<About, CreatedAboutResponse>().ReverseMap();

            CreateMap<About, UpdateAboutCommand>().ReverseMap();
            CreateMap<About, UpdateAboutResponse>().ReverseMap();

            CreateMap<About, DeleteAboutCommand>().ReverseMap();
            CreateMap<About, DeleteAboutResponse>().ReverseMap();

            CreateMap<About, GetListAboutResponse>().ReverseMap();
            CreateMap<About, GetByIdAboutResponse>().ReverseMap();
           
        }
    }
}
