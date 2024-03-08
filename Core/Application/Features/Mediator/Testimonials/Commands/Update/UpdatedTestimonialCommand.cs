using Application.Features.Mediator.Testimonials.Commands.Update;
using Application.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Mediator.Testimonials.Commands.Update
{
    public class UpdatedTestimonialCommand : IRequest<UpdatedTestimonialResponse>
    {
        public int TestimonialID { get; set; }
        public string Name { get; set; }
        public string Title { get; set; }
        public string Comment { get; set; }
        public string ImageUrl { get; set; }
        public bool Status { get; set; }
     
        public class UpdatedTestimonialCommandHandler : IRequestHandler<UpdatedTestimonialCommand, UpdatedTestimonialResponse>
        {
            private readonly ITestimonialRepository _TestimonialRepository;
            private readonly IMapper _mapper;

            public UpdatedTestimonialCommandHandler(ITestimonialRepository TestimonialRepository, IMapper mapper)
            {
                _TestimonialRepository = TestimonialRepository;
                _mapper = mapper;
            }

            public async Task<UpdatedTestimonialResponse> Handle(UpdatedTestimonialCommand request, CancellationToken cancellationToken)
            {
                Testimonial? Testimonial = await _TestimonialRepository.GetByFilterAsync(c => c.TestimonialID == request.TestimonialID);

                Testimonial = _mapper.Map(request, Testimonial);

                await _TestimonialRepository.UpdateAsync(Testimonial);

                return _mapper.Map<UpdatedTestimonialResponse>(Testimonial);

            }
        }
    }
}
