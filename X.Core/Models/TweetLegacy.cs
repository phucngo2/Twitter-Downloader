using System.Text.Json.Serialization;

namespace X.Core.Models;

public class TweetLegacy
{
    [JsonPropertyName("extended_entities")]
    public TweetLegacyExtendedEntities? ExtendedEntities { get; set; }
}
