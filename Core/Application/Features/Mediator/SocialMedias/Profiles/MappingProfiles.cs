
using Application.Features.Mediator.SocialMedias.Commands.Create;
using Application.Features.Mediator.SocialMedias.Commands.Delete;
using Application.Features.Mediator.SocialMedias.Commands.Update;
using Application.Features.Mediator.SocialMedias.Queries.GetById;
using Application.Features.Mediator.SocialMedias.Queries.GetList;
using AutoMapper;
using Domain.Entities;

namespace Application.Features.Mediator.SocialMedias.Profiles
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {
            CreateMap<SocialMedia, CreatedSocialMediaCommand>().ReverseMap();
            CreateMap<SocialMedia, CreatedSocialMediaResponse>().ReverseMap();

            CreateMap<SocialMedia, UpdatedSocialMediaCommand>().ReverseMap();
            CreateMap<SocialMedia, UpdatedSocialMediaResponse>().ReverseMap();

            CreateMap<SocialMedia, DeletedSocialMediaCommand>().ReverseMap();
            CreateMap<SocialMedia, DeletedSocialMediaResponse>().ReverseMap();

            CreateMap<SocialMedia, GetListSocialMediaResponse>().ReverseMap();
            CreateMap<SocialMedia, GetByIdSocialMediaResponse>().ReverseMap();

        }
    }
}
