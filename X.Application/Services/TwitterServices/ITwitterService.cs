using X.Application.Services.TwitterServices.Dtos;

namespace X.Application.Services.TwitterServices;

public interface ITwitterService
{
    public Task<TweetMediasResponse> ListTweetMediasAsync(TweetMediasRequest request);
}
