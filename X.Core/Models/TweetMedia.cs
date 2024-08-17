using System.Text.Json.Serialization;

namespace X.Core.Models;

public class TweetMedia
{
    [JsonPropertyName("display_url")]
    public string DisplayUrl { get; set; } = string.Empty;

    [JsonPropertyName("expanded_url")]
    public string ExpandedUrl { get; set; } = string.Empty;

    [JsonPropertyName("id_str")]
    public string IdStr { get; set; } = string.Empty;

    [JsonPropertyName("source_status_id_str")]
    public string? SourceStatusIdStr { get; set; }

    [JsonPropertyName("media_key")]
    public string MediaKey { get; set; } = string.Empty;

    [JsonPropertyName("media_url_https")]
    public string MediaUrlHttps { get; set; } = string.Empty;

    [JsonPropertyName("type")]
    public string Type { get; set; } = string.Empty;

    [JsonPropertyName("video_info")]
    public TweetVideoInfo? VideoInfo { get; set; }
}
