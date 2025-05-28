using LanguageExt.Common;
using X.Application.Services.TwitterServices.Dtos;

namespace X.Application.Services.TwitterServices;

public interface ITwitterService
{
    public Task<Result<TweetMediasResponse>> ListTweetMediasAsync(TweetMediasRequest request);
}
