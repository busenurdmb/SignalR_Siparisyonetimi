using Application.Features.Mediator.Testimonials.Commands.Create;
using Application.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Mediator.Testimonials.Commands.Create
{
    public class CreatedTestimonialCommand : IRequest<CreatedTestimonialResponse>
    {
        public string Name { get; set; }
        public string Title { get; set; }
        public string Comment { get; set; }
        public string ImageUrl { get; set; }
        public bool Status { get; set; }
        public class CreatedTestimonialCommandHandler : IRequestHandler<CreatedTestimonialCommand, CreatedTestimonialResponse>
        {
            private readonly ITestimonialRepository _TestimonialRepository;
            private readonly IMapper _mapper;

            public CreatedTestimonialCommandHandler(ITestimonialRepository TestimonialRepository, IMapper mapper)
            {
                _TestimonialRepository = TestimonialRepository;
                _mapper = mapper;
            }

            public async Task<CreatedTestimonialResponse> Handle(CreatedTestimonialCommand request, CancellationToken cancellationToken)
            {
                var testimonial = _mapper.Map<Testimonial>(request);
                await _TestimonialRepository.CreateAsync(testimonial);
                return _mapper.Map<CreatedTestimonialResponse>(testimonial);
            }
        }
    }
}
