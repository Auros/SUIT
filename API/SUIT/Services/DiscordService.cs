using System.Net.Http;
using System.Text.Json;
using SUIT.Models.Discord;
using SUIT.Models.Settings;
using System.Threading.Tasks;
using System.Net.Http.Headers;

namespace SUIT.Services
{
    /// <summary>
    /// Service provider for fetching data from Discord
    /// </summary>
    public class DiscordService
    {
        private readonly string _token;
        private readonly HttpClient _client;

        public DiscordService(HttpClient client, IAuthorizationSettings settings)
        {
            _client = client;
            _token = settings.DiscordToken;
        }

        /// <summary>
        /// Gets a Discord User
        /// </summary>
        /// <param name="id">The ID of the user</param>
        /// <returns></returns>
        public async Task<DiscordUser> GetDiscordUser(string id)
        {
            _client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bot", _token);
            HttpResponseMessage response = await _client.GetAsync("https://discordapp.com/api/v6/users/" + id);
            if (response.IsSuccessStatusCode)
            {
                string responseString = await response.Content.ReadAsStringAsync();
                DiscordUser discordUser = JsonSerializer.Deserialize<DiscordUser>(responseString);
                return discordUser;
            }
            return null;
        }
    }
}