using Application.Features.Mediator.Mesages.Commands.Create;
using Application.Features.Mediator.Mesages.Commands.Delete;
using Application.Features.Mediator.Mesages.Commands.Update;
using Application.Features.Mediator.Mesages.Queries.GetById;
using Application.Features.Mediator.Mesages.Queries.GetByList;
using AutoMapper;
using Domain.Entities;


namespace Application.Features.Mediator.Mesages.Profiles
{
	public class MappingProfiles : Profile
	{
		public MappingProfiles()
		{
			CreateMap<Message, CreatedMessageCommand>().ReverseMap();
			CreateMap<Message, CreatedMessageResponse>().ReverseMap();

			CreateMap<Message, UpdatedMessageCommand>().ReverseMap();
			CreateMap<Message, UpdatedMessageResponse>().ReverseMap();

			CreateMap<Message, DeletedMessageCommand>().ReverseMap();
			CreateMap<Message, DeletedMessageResponse>().ReverseMap();

			CreateMap<Message, GetListMessageResponse>().ReverseMap();
			CreateMap<Message, GetByIdMessageResponse>().ReverseMap();

		}
	}
}
