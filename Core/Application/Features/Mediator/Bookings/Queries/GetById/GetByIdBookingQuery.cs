using Application.Repositories;
using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Mediator.Bookings.Queries.GetById
{
    public class GetByIdBookingQuery : IRequest<GetByIdBookingResponse>
    {
        public int Id { get; set; }

        //public GetByIdBookingQuery(int ıd)
        //{
        //    Id = ıd;
        //}

        public class GetByIdBrandQueryHandler : IRequestHandler<GetByIdBookingQuery, GetByIdBookingResponse>
        {
            private readonly IBookingRepository _bookingRepository;
            private readonly IMapper _mapper;
            public GetByIdBrandQueryHandler(IBookingRepository bookingRepository, IMapper mapper)
            {
                _bookingRepository = bookingRepository;
                _mapper = mapper;
            }

            public async Task<GetByIdBookingResponse> Handle(GetByIdBookingQuery request, CancellationToken cancellationToken)
            {
                var booking = await _bookingRepository.GetByFilterAsync(b => b.BookingID == request.Id);
                return _mapper.Map<GetByIdBookingResponse>(booking);
            }
        }
    }
}

