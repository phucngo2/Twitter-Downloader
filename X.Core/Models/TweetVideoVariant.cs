using System.Text.Json.Serialization;

namespace X.Core.Models;

public class TweetVideoVariant
{
    [JsonPropertyName("bitrate")]
    public int? Bitrate { get; set; }

    [JsonPropertyName("content_type")]
    public string ContentType { get; set; } = string.Empty;

    [JsonPropertyName("url")]
    public string Url { get; set; } = string.Empty;
}
