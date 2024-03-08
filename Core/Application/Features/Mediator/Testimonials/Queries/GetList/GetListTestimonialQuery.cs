using Application.Repositories;
using AutoMapper;
using MediatR;

namespace Application.Features.Mediator.Testimonials.Queries.GetList
{
    public class GetListTestimonialQuery : IRequest<List<GetListTestimonialResponse>>
    {
        public class GetListTestimonialQueryHandler : IRequestHandler<GetListTestimonialQuery, List<GetListTestimonialResponse>>
        {
            private readonly ITestimonialRepository _TestimonialRepository;
            private readonly IMapper _mapper;

            public GetListTestimonialQueryHandler(ITestimonialRepository TestimonialRepository, IMapper mapper)
            {
                _TestimonialRepository = TestimonialRepository;
                _mapper = mapper;
            }

            public async Task<List<GetListTestimonialResponse>> Handle(GetListTestimonialQuery request, CancellationToken cancellationToken)
            {
                var Testimonial = await _TestimonialRepository.GetAllAsync();
                return _mapper.Map<List<GetListTestimonialResponse>>(Testimonial);
            }
        }
    }
}
