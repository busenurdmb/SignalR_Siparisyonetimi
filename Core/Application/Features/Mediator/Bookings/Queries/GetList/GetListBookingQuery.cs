using Application.Features.Mediator.Abouts.Queries.GetList;
using Application.Repositories;
using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Mediator.Bookings.Queries.GetList
{
    public class GetListBookingQuery : IRequest<List<GetListBookingResponse>>
    {
        public class GetListBookingQueryHandler : IRequestHandler<GetListBookingQuery, List<GetListBookingResponse>>
        {
            private readonly IBookingRepository _BookingRepository;
            private readonly IMapper _mapper;

            public GetListBookingQueryHandler(IBookingRepository BookingRepository, IMapper mapper)
            {
                _BookingRepository = BookingRepository;
                _mapper = mapper;
            }

            public async Task<List<GetListBookingResponse>> Handle(GetListBookingQuery request, CancellationToken cancellationToken)
            {
                var Booking = await _BookingRepository.GetAllAsync();
                return _mapper.Map<List<GetListBookingResponse>>(Booking);
            }
        }
    }
}
