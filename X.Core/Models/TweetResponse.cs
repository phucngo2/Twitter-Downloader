using System.Text.Json.Serialization;

namespace X.Core.Models;

public class TweetResponse
{
    [JsonPropertyName("tweetResult")]
    public TweetResult? TweetResult { get; set; }
}
