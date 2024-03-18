using Application.Features.Mediator.Bookings.Commands.BookingStatusApproved;
using Application.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Mediator.Bookings.Commands.BookingStatusApproved
{
  
    public class BookingStatusApprovedCommand : IRequest<BookingStatusApprovedResponse>
    {
        public int BookingID { get; set; }
        public class BookingStatusApprovedCommandHandler : IRequestHandler<BookingStatusApprovedCommand, BookingStatusApprovedResponse>
        {
            private readonly IBookingRepository _BookingRepository;
            private readonly IMapper _mapper;

            public BookingStatusApprovedCommandHandler(IBookingRepository BookingRepository, IMapper mapper)
            {
                _BookingRepository = BookingRepository;
                _mapper = mapper;
            }

            public async Task<BookingStatusApprovedResponse> Handle(BookingStatusApprovedCommand request, CancellationToken cancellationToken)
            {
                Booking? Booking = await _BookingRepository.GetByFilterAsync(x => x.BookingID == request.BookingID);
                Booking = _mapper.Map(request, Booking);
                await _BookingRepository.BookingStatusApproved(Booking.BookingID);
                return _mapper.Map<BookingStatusApprovedResponse>(Booking);
            }
        }
    }
}
