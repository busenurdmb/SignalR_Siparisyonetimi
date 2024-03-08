using Application.Features.Mediator.Features.Commands.Create;
using Application.Features.Mediator.Features.Commands.Delete;
using Application.Features.Mediator.Features.Commands.Update;
using Application.Features.Mediator.Features.Queries.GetById;
using Application.Features.Mediator.Features.Queries.GetList;
using AutoMapper;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Mediator.Features.Profiles
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {
            CreateMap<Feature, CreatedFeatureCommand>().ReverseMap();
            CreateMap<Feature, CreatedFeatureResponse>().ReverseMap();

            CreateMap<Feature, UpdatedFeatureCommand>().ReverseMap();
            CreateMap<Feature, UpdatedFeatureResponse>().ReverseMap();

            CreateMap<Feature, DeletedFeatureCommand>().ReverseMap();
            CreateMap<Feature, DeletedFeatureResponse>().ReverseMap();

            CreateMap<Feature, GetListFeatureResponse>().ReverseMap();
            CreateMap<Feature, GetByIdFeatureResponse>().ReverseMap();

        }
    }
}
