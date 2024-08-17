using System.Text.Json.Serialization;
using X.Core.Models;

namespace X.Application.Services.TwitterServices.Dtos;

public class TweetRequestResult
{
    [JsonPropertyName("data")]
    public TweetResponse? Data { get; set; }
}
