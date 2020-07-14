using SUIT.Services;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace SUIT.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class DiscordController : ControllerBase
    {
        private readonly DiscordService _discord;
        private readonly ILogger<DiscordController> _logger;

        public DiscordController(DiscordService discord, ILogger<DiscordController> logger)
        {
            _discord = discord;
            _logger = logger;
        }

        [HttpGet("user/{id}")]
        public async Task<IActionResult> GetUser(string id)
        {
            _logger.LogInformation("User {0} requested from {1}", id, HttpContext.Connection.RemoteIpAddress.ToString());
            return Ok(await _discord.GetDiscordUser(id));
        }
    }
}