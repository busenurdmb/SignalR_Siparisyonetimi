using Application.Features.Mediator.Bookings.Commands.Create;
using Application.Features.Mediator.Bookings.Commands.Delete;
using Application.Features.Mediator.Bookings.Commands.Update;
using Application.Features.Mediator.Bookings.Queries.GetById;
using Application.Features.Mediator.Bookings.Queries.GetList;
using AutoMapper;
using Domain.Entities;

namespace Application.Features.Mediator.Bookings.Profiles
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {
            CreateMap<Booking, CreatedBookingCommand>().ReverseMap();
            CreateMap<Booking, CreatedBookingResponse>().ReverseMap();

            CreateMap<Booking, UpdateBookingCommand>().ReverseMap();
            CreateMap<Booking, UpdateBookingResponse>().ReverseMap();

            CreateMap<Booking, DeleteBookingCommand>().ReverseMap();
            CreateMap<Booking, DeleteBookingResponse>().ReverseMap();

           CreateMap<Booking, GetListBookingResponse>().ReverseMap();
        CreateMap<Booking, GetByIdBookingResponse>().ReverseMap();
           
        }
    }
}
