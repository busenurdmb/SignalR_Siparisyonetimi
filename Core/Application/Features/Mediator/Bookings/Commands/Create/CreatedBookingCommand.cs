using Application.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;


namespace Application.Features.Mediator.Bookings.Commands.Create
{
    public class CreatedBookingCommand : IRequest<CreatedBookingResponse>
    {
       
        public string Name { get; set; }
        public string Description { get; set; }
        public string Phone { get; set; }
        public string Mail { get; set; }
        public int PersonCount { get; set; }
        public DateTime Date { get; set; }

        public class CreatedAboutCommandHandler : IRequestHandler<CreatedBookingCommand, CreatedBookingResponse>
        {
            private readonly IBookingRepository _bookingRepository;
            private readonly IMapper _mapper;
            public CreatedAboutCommandHandler(IMapper mapper, IBookingRepository bookingRepository)
            {

                _mapper = mapper;
                _bookingRepository = bookingRepository;
            }

            public async Task<CreatedBookingResponse> Handle(CreatedBookingCommand request, CancellationToken cancellationToken)
            {
             
           

                var booking= _mapper.Map<Booking>(request);
                await _bookingRepository.CreateAsync(booking);

                // Oluşturulan hakkında yanıtını döndür
                return _mapper.Map<CreatedBookingResponse>(booking);
               
            }
        }
    }
}
