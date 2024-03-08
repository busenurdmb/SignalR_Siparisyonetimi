using Application.Features.Mediator.Testimonials.Commands.Delete;
using Application.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Mediator.Testimonials.Commands.Delete
{
    public class DeletedTestimonialCommand : IRequest<DeletedTestimonialResponse>
    {
        public int Id { get; set; }

        public class DeletedTestimonialCommandHandler : IRequestHandler<DeletedTestimonialCommand, DeletedTestimonialResponse>
        {
            private readonly ITestimonialRepository _TestimonialRepository;
            private readonly IMapper _mapper;

            public DeletedTestimonialCommandHandler(ITestimonialRepository TestimonialRepository, IMapper mapper)
            {
                _TestimonialRepository = TestimonialRepository;
                _mapper = mapper;
            }

            public async Task<DeletedTestimonialResponse> Handle(DeletedTestimonialCommand request, CancellationToken cancellationToken)
            {
                Testimonial? Testimonial = await _TestimonialRepository.GetByFilterAsync(c => c.TestimonialID == request.Id);

                await _TestimonialRepository.RemoveAsync(Testimonial);

                return _mapper.Map<DeletedTestimonialResponse>(Testimonial);

            }
        }
    }
}
