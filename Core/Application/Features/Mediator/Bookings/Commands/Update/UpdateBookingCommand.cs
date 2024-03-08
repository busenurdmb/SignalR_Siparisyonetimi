using Application.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;

namespace Application.Features.Mediator.Bookings.Commands.Update
{
    public class UpdateBookingCommand:IRequest<UpdateBookingResponse>
    {
        public int BookingID { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Phone { get; set; }
        public string Mail { get; set; }
        public int PersonCount { get; set; }
        public DateTime Date { get; set; }
        public class UpdateAboutCommandHandler : IRequestHandler<UpdateBookingCommand, UpdateBookingResponse>
        {
            private readonly IBookingRepository _bookingRepository;
            private readonly IMapper _mapper;

            public UpdateAboutCommandHandler(IBookingRepository bookingRepository, IMapper mapper)
            {
                _bookingRepository = bookingRepository;
                _mapper = mapper;
            }

            public async Task<UpdateBookingResponse> Handle(UpdateBookingCommand request, CancellationToken cancellationToken)
            {
                Booking? booking = await _bookingRepository.GetByFilterAsync(b => b.BookingID == request.BookingID);
                //var booking = await _bookingRepository.GetByIdAsync(request.BookingID);
            

                booking= _mapper.Map(request,booking);

                await _bookingRepository.UpdateAsync(booking);

                return _mapper.Map<UpdateBookingResponse>(booking);
            
            }
        }
    }
}
