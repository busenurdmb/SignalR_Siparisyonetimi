using Application.Features.Mediator.Categories.Commands.Create;
using Application.Features.Mediator.Categories.Commands.Delete;
using Application.Features.Mediator.Categories.Commands.Update;
using Application.Features.Mediator.Categories.Queries.GetById;
using Application.Features.Mediator.Categories.Queries.GetList;
using Application.Features.Mediator.Contacts.Commands.Create;
using Application.Features.Mediator.Contacts.Commands.Delete;
using Application.Features.Mediator.Contacts.Commands.Update;
using Application.Features.Mediator.Contacts.Queries.GetById;
using Application.Features.Mediator.Contacts.Queries.GetList;
using AutoMapper;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Mediator.Contacts.Profiles
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {
            CreateMap<Contact, CreatedContactCommand>().ReverseMap();
            CreateMap<Contact, CreatedContactResponse>().ReverseMap();

            CreateMap<Contact, UpdatedContactCommand>().ReverseMap();
            CreateMap<Contact, UpdatedContactResponse>().ReverseMap();

            CreateMap<Contact, DeletedContactCommand>().ReverseMap();
            CreateMap<Contact, DeletedContactResponse>().ReverseMap();

            CreateMap<Contact, GetListContactResponse>().ReverseMap();
            CreateMap<Contact, GetByIdContactResponse>().ReverseMap();

        }
    }
}
