using Application.Features.Mediator.Features.MenuTables.Commands.Delete;
using Application.Features.Mediator.MenuTable.Commands.Update;
using Application.Features.Mediator.MenuTables.Commands.Create;


using Application.Features.Mediator.MenuTables.Queries.GetById;
using Application.Features.Mediator.MenuTables.Queries.GetList;
using Application.Features.Mediator.MenuTables.Queries.GetMenuTableCount;
using Application.Features.Mediator.Products.Queries.GetProductCount;
using Application.MenuTables.Mediator.MenuTables.Commands.Create;
using Application.MenuTables.Mediator.MenuTables.Commands.Delete;
using Application.MenuTables.Mediator.MenuTables.Commands.Update;
using AutoMapper;
using Domain.Entities;

namespace Application.MenuTables.Mediator.MenuTables.Profiles
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {
            CreateMap<MenuTable, CreatedMenuTableCommand>().ReverseMap();
            CreateMap<MenuTable, CreatedMenuTableResponse>().ReverseMap();

            CreateMap<MenuTable, UpdatedMenuTableCommand>().ReverseMap();
            CreateMap<MenuTable, UpdatedMenuTableResponse>().ReverseMap();

            CreateMap<MenuTable, DeletedMenuTableCommand>().ReverseMap();
            CreateMap<MenuTable, DeletedMenuTableResponse>().ReverseMap();

            CreateMap<MenuTable, GetListMenuTableResponse>().ReverseMap();
            CreateMap<MenuTable, GetByIdMenuTableResponse>().ReverseMap();

            CreateMap<int, GetMenuTableCountResponse>().ForMember(des => des.count, opt => opt.MapFrom(src => src));
        }
    }
}
