using AutoMapper;
using X.Application.Services.TwitterServices.Dtos;
using X.Core.Constants;
using X.Core.Exceptions;
using X.Core.Models;

namespace X.Application.Services.TwitterServices;

public partial class TwitterService(IMapper mapper) : ITwitterService
{
    private readonly IMapper _mapper = mapper;
    public async Task<TweetMediasResponse> ListTweetMediasAsync(TweetMediasRequest request)
    {
        string? tweetId = GetTweetIdFromUrl(request.Url);
        if (string.IsNullOrEmpty(tweetId))
        {
            throw new BadRequestException("Url not valid!");
        }

        string? token = await RequestGuestTokenAsync();
        if (string.IsNullOrEmpty(token))
        {
            throw new Exception("Could not request api token!");
        }

        TweetResponse? tweetResponse = await RequestTweetAsync(tweetId, token);
        if (tweetResponse?.TweetResult?.Result is null)
        {
            throw new NotFoundException("Tweet not found!");
        }

        string tweetTypename = tweetResponse.TweetResult.Result.TypeName;
        if (tweetTypename == "TweetUnavailable")
        {
            string reason = tweetResponse.TweetResult.Result.Reason;
            if (reason == "Protected")
            {
                throw new Exception("Tweet protected!");
            }
            if (reason == "NsfwLoggedOut")
            {
                // TODO: Request using cookie
                throw new Exception("Tweet nsfw!");
            }
        }

        if (!TwitterConstants.ValidTweetTypeNames.Contains(tweetTypename))
        {
            throw new Exception("Tweet unavailable!");
        }

        Tweet tweet = tweetResponse.TweetResult.Result;
        TweetLegacy tweetLegacy = tweet.Legacy;

        List<TweetMedia>? mediaList = tweetLegacy?.ExtendedEntities?.Media;
        if (mediaList is null || mediaList.Count == 0)
        {
            throw new NotFoundException("Tweet media not found!");
        }

        List<TweetMediaDto> mediaDtoList = _mapper.Map<List<TweetMediaDto>>(mediaList);
        return new TweetMediasResponse
        {
            Medias = mediaDtoList
        };
    }
}
