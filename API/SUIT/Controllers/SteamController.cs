using SUIT.Services;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace SUIT.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class SteamController : ControllerBase
    {
        private readonly SteamService _steam;
        private readonly ILogger<SteamController> _logger;

        public SteamController(SteamService steam, ILogger<SteamController> logger)
        {
            _steam = steam;
            _logger = logger;
        }

        [HttpGet("user/{id}")]
        public async Task<IActionResult> GetUser(string id)
        {
            _logger.LogInformation("User {0} requested from {1}", id, HttpContext.Connection.RemoteIpAddress.ToString());
            return Ok(await _steam.GetSteamUser(id));
        }

        [HttpGet("recentgames/{id}")]
        public async Task<IActionResult> GetRecentGames(string id)
        {
            _logger.LogInformation("User {0} recent games requested from {1}", id, HttpContext.Connection.RemoteIpAddress.ToString());
            return Ok(await _steam.GetRecentPlayedGames(id));
        }
    }
}