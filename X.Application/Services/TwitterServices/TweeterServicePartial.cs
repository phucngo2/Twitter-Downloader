using System.Text.Json;
using X.Application.Services.TwitterServices.Dtos;
using X.Core.Constants;
using X.Core.Models;

namespace X.Application.Services.TwitterServices;

public partial class TweeterService
{
    private static HttpClient _httpClient = new();

    private static async Task<string?> RequestGuestTokenAsync()
    {
        var requestUri = new Uri(TweeterConstants.XTokenURL);

        var requestMessage = new HttpRequestMessage(HttpMethod.Post, requestUri.ToString());
        requestMessage = TweeterConstants.ApplyHeaders(requestMessage);

        var response = await _httpClient.SendAsync(requestMessage);
        response.EnsureSuccessStatusCode();

        var jsonResponse = await response.Content.ReadAsStringAsync();
        var result = JsonSerializer.Deserialize<JsonElement>(jsonResponse);
        return result.GetProperty("guest_token").GetString();
    }

    private static async Task<TweetResponse?> RequestTweetAsync(string tweetId, string token)
    {
        var requestUri = new UriBuilder(TweeterConstants.XGraphqlURL)
        {
            Query = $"variables={Uri.EscapeDataString(TweeterConstants.GetTweetVariables(tweetId))}&" +
                    $"features={Uri.EscapeDataString(TweeterConstants.TweetFeatures)}&" +
                    $"fieldToggles={Uri.EscapeDataString(TweeterConstants.TweetFieldToggles)}"
        };

        var requestMessage = new HttpRequestMessage(HttpMethod.Get, requestUri.ToString());
        requestMessage = TweeterConstants.ApplyHeaders(requestMessage);
        requestMessage.Headers.TryAddWithoutValidation("x-guest-token", token);
        requestMessage.Headers.TryAddWithoutValidation("cookie", $"guest_id={Uri.EscapeDataString($"v1:{token}")}");

        var response = await _httpClient.SendAsync(requestMessage);
        response.EnsureSuccessStatusCode();

        var jsonResponse = await response.Content.ReadAsStringAsync();
        var result = JsonSerializer.Deserialize<TweetRequestResult>(jsonResponse);

        return result?.Data;
    }

    private static string? GetTweetIdFromUrl(string url)
    {
        var regex = TweeterConstants.TwitterUrlRegex();
        var match = regex.Match(url);
        return match.Success ? match.Groups[1].Value : null;
    }
}
