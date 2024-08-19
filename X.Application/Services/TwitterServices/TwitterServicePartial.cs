using System.Text.Json;
using X.Application.Services.TwitterServices.Dtos;
using X.Core.Constants;
using X.Core.Exceptions;
using X.Core.Models;

namespace X.Application.Services.TwitterServices;

public partial class TwitterService
{
    private static HttpClient _httpClient = new();

    private static async Task<string?> RequestGuestTokenAsync()
    {
        var requestUri = new Uri(TwitterConstants.XTokenURL);

        var requestMessage = new HttpRequestMessage(HttpMethod.Post, requestUri.ToString());
        requestMessage = TwitterConstants.ApplyHeaders(requestMessage);

        var response = await _httpClient.SendAsync(requestMessage);
        response.EnsureSuccessStatusCode();

        var jsonResponse = await response.Content.ReadAsStringAsync();
        var result = JsonSerializer.Deserialize<JsonElement>(jsonResponse);
        return result.GetProperty("guest_token").GetString();
    }

    private static async Task<TweetResponse?> RequestTweetAsync(string tweetId, string token)
    {
        var requestUri = GenerateRequestUri(tweetId);

        var requestMessage = new HttpRequestMessage(HttpMethod.Get, requestUri.ToString());
        requestMessage = TwitterConstants.ApplyHeaders(requestMessage);
        requestMessage.Headers.TryAddWithoutValidation("x-guest-token", token);
        requestMessage.Headers.TryAddWithoutValidation("cookie", $"guest_id={Uri.EscapeDataString($"v1:{token}")}");

        var response = await _httpClient.SendAsync(requestMessage);
        response.EnsureSuccessStatusCode();

        var jsonResponse = await response.Content.ReadAsStringAsync();
        var result = JsonSerializer.Deserialize<TweetRequestResult>(jsonResponse);

        return result?.Data;
    }

    private static async Task<TweetResponse?> RequestTweetAsync(string tweetId, XCookie xCookie)
    {
        var requestUri = GenerateRequestUri(tweetId);

        var requestMessage = new HttpRequestMessage(HttpMethod.Get, requestUri.ToString());
        requestMessage = TwitterConstants.ApplyHeaders(requestMessage);
        requestMessage.Headers.TryAddWithoutValidation("X-Twitter-Auth-Type", "OAuth2Session");
        requestMessage.Headers.TryAddWithoutValidation("x-csrf-token", xCookie.Ct0);
        requestMessage.Headers.TryAddWithoutValidation("cookie", xCookie.CookieStr);

        var response = await _httpClient.SendAsync(requestMessage);
        response.EnsureSuccessStatusCode();

        var jsonResponse = await response.Content.ReadAsStringAsync();
        var result = JsonSerializer.Deserialize<TweetRequestResult>(jsonResponse);

        return result?.Data;
    }

    private static string? GetTweetIdFromUrl(string url)
    {
        var regexes = new[] { TwitterConstants.XUrlRegex(), TwitterConstants.TwitterUrlRegex() };
        foreach (var regex in regexes)
        {
            var match = regex.Match(url);
            if (match.Success)
            {
                return match.Groups[1].Value;
            }
        }
        return null;
    }

    private static UriBuilder GenerateRequestUri(string tweetId)
    {
        return new UriBuilder(TwitterConstants.XGraphqlURL)
        {
            Query = $"variables={Uri.EscapeDataString(TwitterConstants.GetTweetVariables(tweetId))}&" +
                    $"features={Uri.EscapeDataString(TwitterConstants.TweetFeatures)}&" +
                    $"fieldToggles={Uri.EscapeDataString(TwitterConstants.TweetFieldToggles)}"
        };
    }

    private void ValidateTweetResponse(TweetResponse? tweetResponse)
    {
        if (tweetResponse?.TweetResult?.Result == null)
        {
            throw new NotFoundException("Tweet not found!");
        }
    }
}
