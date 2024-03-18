using Application.Features.Mediator.Bookings.Commands.BookingStatusCancelled;
using Application.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Mediator.Bookings.Commands.BookingStatusCancelled
{
   
    public class BookingStatusCancelledCommand : IRequest<BookingStatusCancelledResponse>
    {
        public int BookingID { get; set; }
        public class BookingStatusCancelledCommandHandler : IRequestHandler<BookingStatusCancelledCommand, BookingStatusCancelledResponse>
        {
            private readonly IBookingRepository _BookingRepository;
            private readonly IMapper _mapper;

            public BookingStatusCancelledCommandHandler(IBookingRepository BookingRepository, IMapper mapper)
            {
                _BookingRepository = BookingRepository;
                _mapper = mapper;
            }

            public async Task<BookingStatusCancelledResponse> Handle(BookingStatusCancelledCommand request, CancellationToken cancellationToken)
            {
                Booking? Booking = await _BookingRepository.GetByFilterAsync(x => x.BookingID == request.BookingID);
                Booking = _mapper.Map(request, Booking);
                await _BookingRepository.BookingStatusCancelled(Booking.BookingID);
                return _mapper.Map<BookingStatusCancelledResponse>(Booking);
            }
        }
    }
}
