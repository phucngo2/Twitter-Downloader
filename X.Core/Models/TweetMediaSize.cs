using System.Text.Json.Serialization;

namespace X.Core.Models;

public class TweetMediaSize
{
    [JsonPropertyName("h")]
    public int H {  get; set; }
    [JsonPropertyName("w")]
    public int W { get; set; }
    [JsonPropertyName("resize")]
    public string Resize { get; set; } = string.Empty;
}
