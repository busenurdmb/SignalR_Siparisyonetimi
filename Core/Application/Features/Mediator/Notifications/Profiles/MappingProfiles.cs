using Application.Features.Mediator.Notifications.Commands.Create;
using Application.Features.Mediator.Notifications.Commands.Delete;
using Application.Features.Mediator.Notifications.Commands.NotificationStatusChangeToFalse;
using Application.Features.Mediator.Notifications.Commands.NotificationStatusChangeToTrue;
using Application.Features.Mediator.Notifications.Commands.Update;
using Application.Features.Mediator.Notifications.Queries.GetAllNotificationByFalse;
using Application.Features.Mediator.Notifications.Queries.GetById;
using Application.Features.Mediator.Notifications.Queries.GetList;
using Application.Features.Mediator.Notifications.Queries.NotificationCountByStatusFalse;
using AutoMapper;
using Domain.Entities;

namespace Application.Features.Mediator.Notifications.Profiles
{
	public class MappingProfiles : Profile
	{
		public MappingProfiles()
		{
			
            CreateMap<CreatedNotificationCommand,Notification>()
    .ForMember(dest => dest.Date, opt => opt.MapFrom(src => DateTime.Now))
    .ReverseMap();
         CreateMap<Notification, CreatedNotificationResponse>()
		//.ForMember(dest => dest.Date, opt => opt.MapFrom(src => DateTime.Now))
  //  .ForMember(dest => dest.Status, opt => opt.MapFrom(src => false))
    .ReverseMap();

			CreateMap<Notification, UpdatedNotificationCommand>().ReverseMap();
			CreateMap<Notification, UpdatedNotificationResponse>().ReverseMap();

            CreateMap<Notification, NotificationCountByStatusFalseResponse>().ReverseMap();
            CreateMap<Notification, NotificationCountByStatusFalseQuery>().ReverseMap();

            CreateMap<Notification, NotificationStatusChangeToTrueResponse>().ReverseMap();
            CreateMap<Notification, NotificationStatusChangeToTrueCommand>().ReverseMap();

            CreateMap<Notification, NotificationStatusChangeToFalseResponse>().ReverseMap();
            CreateMap<Notification, NotificationStatusChangeToFalseCommand>().ReverseMap();

            CreateMap<Notification, DeletedNotificationCommand>().ReverseMap();
			CreateMap<Notification, DeletedNotificationResponse>().ReverseMap();

			CreateMap<Notification, GetListNotificationResponse>().ReverseMap();

			CreateMap<Notification, GetAllNotificationByFalseResponse>().ReverseMap();

			
			CreateMap<Notification, GetByIdNotificationResponse>().ReverseMap();

			CreateMap<int, NotificationCountByStatusFalseResponse>().ForMember(des => des.count, opt => opt.MapFrom(src => src));
			
		}
	}
}
