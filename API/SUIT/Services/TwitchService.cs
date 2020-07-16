using System.Net.Http;
using System.Text.Json;
using SUIT.Models.Discord;
using SUIT.Models.Settings;
using System.Threading.Tasks;
using System.Net.Http.Headers;
using System.Text.Json.Serialization;
using SUIT.Models.Twitch;

namespace SUIT.Services
{
    /// <summary>
    /// Service provider for fetching data from Twitch
    /// </summary>
    public class TwitchService
    {
        private readonly string _id;
        private readonly string _token;
        private readonly HttpClient _client;

        public TwitchService(HttpClient client, IAuthorizationSettings settings)
        {
            _client = client;
            _id = settings.TwitchID;
            _token = settings.TwitchToken;
            _client.DefaultRequestHeaders.Add("Client-ID", _id);
        }

        /// <summary>
        /// Gets a Twitch User
        /// </summary>
        /// <param name="username">The username of the user</param>
        /// <returns></returns>
        public async Task<TwitchUser> GetTwitchUser(string username)
        {
            _client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", _token);
            HttpResponseMessage response = await _client.GetAsync("https://api.twitch.tv/helix/users?login=" + username);
            if (response.IsSuccessStatusCode)
            {
                string responseString = await response.Content.ReadAsStringAsync();
                TwitchUserResponseWrapper wrapper = JsonSerializer.Deserialize<TwitchUserResponseWrapper>(responseString);
                if (wrapper.Users.Length > 0)
                {
                    return wrapper.Users[0];
                }
            }
            return null;
        }

        private class TwitchUserResponseWrapper
        {
            [JsonPropertyName("data")]
            public TwitchUser[] Users { get; set; }
        }
    }
}