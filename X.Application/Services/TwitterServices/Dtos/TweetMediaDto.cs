using X.Core.Models;

namespace X.Application.Services.TwitterServices.Dtos;

public class TweetMediaDto
{
    public string DisplayUrl { get; set; } = string.Empty;
    public string ExpandedUrl { get; set; } = string.Empty;
    public string IdStr { get; set; } = string.Empty;
    public string MediaUrlHttps { get; set; } = string.Empty;
    public string Type { get; set; } = string.Empty;
    public List<TweetVideoVariant>? VideoVariants { get; set; }
    public Dictionary<string, TweetMediaSize>? Sizes { get; set; }
}
