using System.Text.Json.Serialization;

namespace X.Core.Models;

public class TweetLegacyExtendedEntities
{
    [JsonPropertyName("media")]
    public List<TweetMedia>? Media { get; set; }
}
