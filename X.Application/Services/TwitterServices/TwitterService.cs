using AutoMapper;
using LanguageExt.Common;
using X.Application.Services.TwitterServices.Dtos;
using X.Core.Constants;
using X.Core.Exceptions;
using X.Core.Models;

namespace X.Application.Services.TwitterServices;

public partial class TwitterService(IMapper mapper) : ITwitterService
{
    private readonly IMapper _mapper = mapper;
    public async Task<Result<TweetMediasResponse>> ListTweetMediasAsync(TweetMediasRequest request)
    {
        string? tweetId = GetTweetIdFromUrl(request.Url);
        if (string.IsNullOrEmpty(tweetId))
        {
            return new Result<TweetMediasResponse>(new BadRequestException("Url not valid!"));
        }

        string? token = await RequestGuestTokenAsync();
        if (string.IsNullOrEmpty(token))
        {
            return new Result<TweetMediasResponse>(new Exception("Could not request api token!"));
        }

        TweetResponse? tweetResponse = await RequestTweetAsync(tweetId, token);
        if (tweetResponse?.TweetResult?.Result is null)
        {
            return new Result<TweetMediasResponse>(new NotFoundException("Tweet not found!"));
        }

        string tweetTypename = tweetResponse.TweetResult.Result.TypeName;
        if (tweetTypename == "TweetUnavailable")
        {
            string reason = tweetResponse.TweetResult.Result.Reason;
            if (reason == "Protected")
            {
                return new Result<TweetMediasResponse>(new Exception("Tweet protected!"));
            }
            if (reason == "NsfwLoggedOut")
            {
                XCookie? cookie = TwitterConstants.GetCookie();
                if (cookie != null)
                {
                    tweetResponse = await RequestTweetAsync(tweetId, cookie);
                    if (tweetResponse?.TweetResult?.Result is null)
                    {
                        return new Result<TweetMediasResponse>(new NotFoundException("Nsfw Tweet not found!"));
                    }
                    tweetTypename = tweetResponse.TweetResult.Result.TypeName;
                }
                else
                {
                    return new Result<TweetMediasResponse>(new Exception("Tweet nsfw!"));
                }
            }
        }

        if (!TwitterConstants.ValidTweetTypeNames.Contains(tweetTypename))
        {
            return new Result<TweetMediasResponse>(new Exception("Tweet unavailable!"));
        }

        Tweet tweet = tweetResponse.TweetResult.Result;
        TweetLegacy tweetLegacy = tweet.Legacy;

        List<TweetMedia>? mediaList = tweetLegacy?.ExtendedEntities?.Media;
        if (mediaList is null || mediaList.Count == 0)
        {
            return new Result<TweetMediasResponse>(new NotFoundException("Tweet media not found!"));
        }

        List<TweetMediaDto> mediaDtoList = _mapper.Map<List<TweetMediaDto>>(mediaList);
        return new TweetMediasResponse
        {
            Medias = mediaDtoList
        };
    }
}
