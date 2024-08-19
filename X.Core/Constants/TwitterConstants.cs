using System.Text.Json;
using System.Text.RegularExpressions;
using X.Core.Models;

namespace X.Core.Constants;

public static partial class TwitterConstants
{
    public const string XGraphqlURL = "https://api.x.com/graphql/I9GDzyCGZL2wSoYFFrrTVw/TweetResultByRestId";
    public const string XTokenURL = "https://api.x.com/1.1/guest/activate.json";

    public static readonly string TweetFeatures = JsonSerializer.Serialize(new
    {
        creator_subscriptions_tweet_preview_api_enabled = true,
        communities_web_enable_tweet_community_results_fetch = true,
        c9s_tweet_anatomy_moderator_badge_enabled = true,
        articles_preview_enabled = true,
        tweetypie_unmention_optimization_enabled = true,
        responsive_web_edit_tweet_api_enabled = true,
        graphql_is_translatable_rweb_tweet_is_translatable_enabled = true,
        view_counts_everywhere_api_enabled = true,
        longform_notetweets_consumption_enabled = true,
        responsive_web_twitter_article_tweet_consumption_enabled = true,
        tweet_awards_web_tipping_enabled = false,
        creator_subscriptions_quote_tweet_preview_enabled = false,
        freedom_of_speech_not_reach_fetch_enabled = true,
        standardized_nudges_misinfo = true,
        tweet_with_visibility_results_prefer_gql_limited_actions_policy_enabled = true,
        rweb_video_timestamps_enabled = true,
        longform_notetweets_rich_text_read_enabled = true,
        longform_notetweets_inline_media_enabled = true,
        rweb_tipjar_consumption_enabled = true,
        responsive_web_graphql_exclude_directive_enabled = true,
        verified_phone_label_enabled = false,
        responsive_web_graphql_skip_user_profile_image_extensions_enabled = false,
        responsive_web_graphql_timeline_navigation_enabled = true,
        responsive_web_enhance_cards_enabled = false
    });

    public static readonly string TweetFieldToggles = JsonSerializer.Serialize(new
    {
        withArticleRichContentState = true,
        withArticlePlainText = false,
        withGrokAnalyze = false
    });

    public static string GetTweetVariables(string tweetId) => JsonSerializer.Serialize(new
    {
        tweetId,
        withCommunity = false,
        includePromotedContent = false,
        withVoice = false
    });

    public static readonly Dictionary<string, string> XHeaders = new()
    {
        { "user-agent", GeneralConstants.GeneralUserAgent },
        { "authorization", "Bearer AAAAAAAAAAAAAAAAAAAAANRILgAAAAAAnNwIzUejRCOuH5E6I8xnZz4puTs%3D1Zv7ttfk8LF81IUq16cHjhLTvJu4FA33AGWWjCpTnA" },
        { "x-twitter-client-language", "en" },
        { "x-twitter-active-user", "yes" },
        { "accept-language", "en" },
        { "content-type", "application/json" }
    };

    public static HttpRequestMessage ApplyHeaders(HttpRequestMessage requestMessage)
    {
        foreach (var header in XHeaders)
        {
            requestMessage.Headers.TryAddWithoutValidation(header.Key, header.Value);
        }
        return requestMessage;
    }

    [GeneratedRegex(@"x\.com\/[^\/]+\/status\/(\d+)", RegexOptions.Compiled)]
    public static partial Regex XUrlRegex();
    [GeneratedRegex(@"twitter\.com\/[^\/]+\/status\/(\d+)", RegexOptions.Compiled)]
    public static partial Regex TwitterUrlRegex();

    public static readonly string[] ValidTweetTypeNames = ["Tweet", "TweetWithVisibilityResults"];

    public static XCookie? GetCookie()
    {
        string? value = Environment.GetEnvironmentVariable("X_COOKIE");

        if (string.IsNullOrEmpty(value))
        {
            return null;
        }

        string[] claims = value.Split("; ");
        string? ct0 = null;
        foreach (var claim in claims)
        {
            if (claim.StartsWith("ct0=", StringComparison.OrdinalIgnoreCase))
            {
                ct0 = claim.Split("=")[1];
                break;
            }
        }

        if (string.IsNullOrEmpty(ct0))
        {
            return null;
        }

        return new XCookie
        {
            CookieStr = value,
            Ct0 = ct0
        };
    }
}
