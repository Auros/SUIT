using System.Text.Json.Serialization;

namespace SUIT.Models.Twitch
{
    public class TwitchUser
    {
        [JsonPropertyName("id")]
        public string ID { get; set; }

        [JsonPropertyName("login")]
        public string Login { get; set; }

        [JsonPropertyName("display_name")]
        public string DisplayName { get; set; }
       
        [JsonPropertyName("type")]
        public string Type { get; set; }

        [JsonPropertyName("broadcaster_type")]
        public string BroadcasterType { get; set; }

        [JsonPropertyName("description")]
        public string Description { get; set; }

        [JsonPropertyName("profile_image_url")]
        public string ProfileImageURL { get; set; }

        [JsonPropertyName("offline_image_url")]
        public string OfflineImageURL { get; set; }

        [JsonPropertyName("view_count")]
        public ulong ViewCount { get; set; }
    }
}