using Microsoft.AspNetCore.Mvc;
using X.Application.Services.TwitterServices;
using X.Application.Services.TwitterServices.Dtos;

namespace X.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class TweeterController(ITweeterService tweeterService) : ControllerBase
{
    private readonly ITweeterService _tweeterService = tweeterService;

    [HttpPost]
    public async Task<IActionResult> ListTweetMediasAsync(TweetMediasRequest request)
    {
        var res = await _tweeterService.ListTweetMediasAsync(request);
        return Ok(res);
    }
}
