
using Application.Features.Mediator.Sliders.Commands.Create;
using Application.Features.Mediator.Sliders.Commands.Delete;
using Application.Features.Mediator.Sliders.Commands.Update;
using Application.Features.Mediator.Sliders.Queries.GetById;
using Application.Features.Mediator.Sliders.Queries.GetList;
using Application.Features.Mediator.SocialMedias.Commands.Create;
using Application.Features.Mediator.SocialMedias.Commands.Delete;
using Application.Features.Mediator.SocialMedias.Commands.Update;
using Application.Features.Mediator.SocialMedias.Queries.GetById;
using Application.Features.Mediator.SocialMedias.Queries.GetList;
using AutoMapper;
using Domain.Entities;

namespace Application.Features.Mediator.Sliders.Profiles
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {
            CreateMap<Slider, CreatedSliderCommand>().ReverseMap();
            CreateMap<Slider, CreatedSliderResponse>().ReverseMap();

            CreateMap<Slider, UpdatedSliderCommand>().ReverseMap();
            CreateMap<Slider, UpdatedSliderResponse>().ReverseMap();

            CreateMap<Slider, DeletedSliderCommand>().ReverseMap();
            CreateMap<Slider, DeletedSliderResponse>().ReverseMap();

            CreateMap<Slider, GetListSliderResponse>().ReverseMap();
            CreateMap<Slider, GetByIdSliderResponse>().ReverseMap();

        }
    }
}
