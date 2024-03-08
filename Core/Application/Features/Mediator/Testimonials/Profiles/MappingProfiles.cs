using Application.Features.Mediator.Testimonials.Commands.Create;
using Application.Features.Mediator.Testimonials.Commands.Delete;
using Application.Features.Mediator.Testimonials.Commands.Update;
using Application.Features.Mediator.Testimonials.Queries.GetById;
using Application.Features.Mediator.Testimonials.Queries.GetList;
using AutoMapper;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Mediator.Testimonials.Profiles
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {
            CreateMap<Testimonial, CreatedTestimonialCommand>().ReverseMap();
            CreateMap<Testimonial, CreatedTestimonialResponse>().ReverseMap();

            CreateMap<Testimonial, UpdatedTestimonialCommand>().ReverseMap();
            CreateMap<Testimonial, UpdatedTestimonialResponse>().ReverseMap();

            CreateMap<Testimonial, DeletedTestimonialCommand>().ReverseMap();
            CreateMap<Testimonial, DeletedTestimonialResponse>().ReverseMap();

            CreateMap<Testimonial, GetListTestimonialResponse>().ReverseMap();
            CreateMap<Testimonial, GetByIdTestimonialResponse>().ReverseMap();

        }
    }
}
