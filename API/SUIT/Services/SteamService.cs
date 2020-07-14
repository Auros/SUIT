using System.Net.Http;
using System.Text.Json;
using SUIT.Models.Steam;
using SUIT.Models.Settings;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using System.Text.Json.Serialization;

namespace SUIT.Services
{
    /// <summary>
    /// Service provider for fetching data from Steam
    /// </summary>
    public class SteamService
    {
        private readonly string _key;
        private readonly HttpClient _client;
        private readonly ILogger<SteamService> _logger;

        public SteamService(HttpClient client, IAuthorizationSettings settings, ILogger<SteamService> logger)
        {
            _logger = logger;
            _client = client;
            _key = settings.SteamKey;
        }

        /// <summary>
        /// Gets a Steam User
        /// </summary>
        /// <param name="id">The ID of the user</param>
        /// <returns></returns>
        public async Task<SteamUser> GetSteamUser(string id)
        {
            HttpResponseMessage response = await _client.GetAsync("https://api.steampowered.com/ISteamUser/GetPlayerSummaries/v2/?key=" + _key + "&steamids=" + id);
            if (response.IsSuccessStatusCode)
            {
                string responseString = await response.Content.ReadAsStringAsync();
                SteamUserResponseWrapper wrapper = JsonSerializer.Deserialize<SteamUserResponseWrapper>(responseString);
                if (wrapper.Response.Players.Length > 0)
                {
                    return wrapper.Response.Players[0];
                }
            }
            return null;
        }

        public async Task<SteamGame[]> GetRecentPlayedGames(string id)
        {
            HttpResponseMessage response = await _client.GetAsync("http://api.steampowered.com/IPlayerService/GetRecentlyPlayedGames/v0001/?key=" + _key + "&steamid=" + id + "?format=json");
            if (response.IsSuccessStatusCode)
            {
                string responseString = await response.Content.ReadAsStringAsync();
                SteamGameSummariesResponseWrapper wrapper = JsonSerializer.Deserialize<SteamGameSummariesResponseWrapper>(responseString);
                return wrapper.Response.Games;
            }
            return new SteamGame[0];
        }


        /// <summary>
        /// Literally WHO designs a return value like this?!
        /// </summary>
        private class SteamUserResponseWrapper
        {
            [JsonPropertyName("response")]
            public SteamUserResponse Response { get; set; }

            public class SteamUserResponse
            {
                [JsonPropertyName("players")]
                public SteamUser[] Players { get; set; }
            }
        }

        private class SteamGameSummariesResponseWrapper
        {
            [JsonPropertyName("response")]
            public SteamGameSummariesResponse Response { get; set; }

            public class SteamGameSummariesResponse
            {
                [JsonPropertyName("total_count")]
                public int TotalCount { get; set; }

                [JsonPropertyName("games")]
                public SteamGame[] Games { get; set; }
            }
        }
    }
}