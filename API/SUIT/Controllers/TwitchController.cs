using SUIT.Services;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace SUIT.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TwitchController : ControllerBase
    {
        private readonly TwitchService _twitch;
        private readonly ILogger<TwitchController> _logger;

        public TwitchController(TwitchService twitch, ILogger<TwitchController> logger)
        {
            _twitch = twitch;
            _logger = logger;
        }

        [HttpGet("user/{username}")]
        public async Task<IActionResult> GetUser(string username)
        {
            _logger.LogInformation("User {0} requested from {1}", username, HttpContext.Connection.RemoteIpAddress.ToString());
            return Ok(await _twitch.GetTwitchUser(username));
        }
    }
}