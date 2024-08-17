using System.Text.Json.Serialization;

namespace X.Core.Models;

public class TweetVideoInfo
{
    [JsonPropertyName("variants")]
    public List<TweetVideoVariant> Variants { get; set; } = new List<TweetVideoVariant>();
}
