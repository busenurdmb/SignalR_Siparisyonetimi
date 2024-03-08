using Application.Repositories;
using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Mediator.Bookings.Commands.Delete
{
    public class DeleteBookingCommand:IRequest<DeleteBookingResponse>
    {
        public int Id { get; set; }

        public DeleteBookingCommand(int ıd)
        {
            Id = ıd;
        }
        public class DeleteAboutCommandHandler : IRequestHandler<DeleteBookingCommand, DeleteBookingResponse>
        {
            private readonly IBookingRepository _bookingRepository;
            private readonly IMapper _mapper;

            public DeleteAboutCommandHandler(IBookingRepository bookingRepository, IMapper mapper)
            {
                _bookingRepository = bookingRepository;
                _mapper = mapper;
            }

            public async Task<DeleteBookingResponse> Handle(DeleteBookingCommand request, CancellationToken cancellationToken)
            {
                var values = await _bookingRepository.GetByIdAsync(request.Id);
                await _bookingRepository.RemoveAsync(values);
                return _mapper.Map<DeleteBookingResponse>(values);
            }
        }
    }
}
