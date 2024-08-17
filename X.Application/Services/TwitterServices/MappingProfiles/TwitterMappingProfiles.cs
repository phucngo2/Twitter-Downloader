using AutoMapper;
using X.Application.Services.TwitterServices.Dtos;
using X.Core.Models;

namespace X.Application.Services.TwitterServices.MappingProfiles;

public class TwitterMappingProfiles : Profile
{
    public TwitterMappingProfiles()
    {
        CreateMap<TweetMedia, TweetMediaDto>()
            .ForMember(
                destination => destination.VideoVariants,
                options => options.MapFrom(src => src.VideoInfo == null ? null : src.VideoInfo.Variants)
            );
    }
}
