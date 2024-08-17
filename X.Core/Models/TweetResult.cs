using System.Text.Json.Serialization;

namespace X.Core.Models;

public class TweetResult
{
    [JsonPropertyName("result")]
    public Tweet? Result { get; set; }
}
