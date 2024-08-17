using System.Text.Json.Serialization;

namespace X.Core.Models;

public class Tweet
{
    [JsonPropertyName("__typename")]
    public string TypeName { get; set; } = string.Empty;

    [JsonPropertyName("rest_id")]
    public string RestId { get; set; } = string.Empty;

    [JsonPropertyName("legacy")]
    public TweetLegacy Legacy { get; set; } = new TweetLegacy();

    [JsonPropertyName("reason")]
    public string Reason { get; set; } = string.Empty;
}
