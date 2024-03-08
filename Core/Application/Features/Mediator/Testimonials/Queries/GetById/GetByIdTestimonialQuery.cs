using Application.Features.Mediator.Testimonials.Queries.GetById;
using Application.Repositories;
using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Mediator.Testimonials.Queries.GetById
{
    public class GetByIdTestimonialQuery : IRequest<GetByIdTestimonialResponse>
    {
        public int Id { get; set; }
        public class GetByIdTestimonialQueryHandler : IRequestHandler<GetByIdTestimonialQuery, GetByIdTestimonialResponse>
        {
            private readonly ITestimonialRepository _TestimonialRepository;
            private readonly IMapper _mapper;

            public GetByIdTestimonialQueryHandler(ITestimonialRepository TestimonialRepository, IMapper mapper)
            {
                _TestimonialRepository = TestimonialRepository;
                _mapper = mapper;
            }

            public async Task<GetByIdTestimonialResponse> Handle(GetByIdTestimonialQuery request, CancellationToken cancellationToken)
            {
                var Testimonial = await _TestimonialRepository.GetByFilterAsync(c => c.TestimonialID == request.Id);
                return _mapper.Map<GetByIdTestimonialResponse>(Testimonial);
            }
        }

    }
}
