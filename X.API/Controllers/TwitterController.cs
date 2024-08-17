using Microsoft.AspNetCore.Mvc;
using X.Application.Services.TwitterServices;
using X.Application.Services.TwitterServices.Dtos;

namespace X.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class TwitterController(ITwitterService twitterService) : ControllerBase
{
    private readonly ITwitterService _twitterService = twitterService;

    [HttpPost]
    public async Task<IActionResult> ListTweetMediasAsync(TweetMediasRequest request)
    {
        var res = await _twitterService.ListTweetMediasAsync(request);
        return Ok(res);
    }
}
