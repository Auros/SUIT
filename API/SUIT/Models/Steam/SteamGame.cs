using System.Text.Json.Serialization;

namespace SUIT.Models.Steam
{
    public partial class SteamGame
    {
        [JsonPropertyName("appid")]
        public long AppID { get; set; }

        [JsonPropertyName("name")]
        public string Name { get; set; }

        [JsonPropertyName("playtime_2weeks")]
        public long Playtime2Weeks { get; set; }

        [JsonPropertyName("playtime_forever")]
        public long PlaytimeForever { get; set; }

        [JsonPropertyName("img_icon_url")]
        public string ImgIconUrl { get; set; }

        [JsonPropertyName("img_logo_url")]
        public string ImgLogoURL { get; set; }

        [JsonPropertyName("playtime_windows_forever")]
        public long PlaytimeWindowsForever { get; set; }

        [JsonPropertyName("playtime_mac_forever")]
        public long PlaytimeMacForever { get; set; }

        [JsonPropertyName("playtime_linux_forever")]
        public long PlaytimeLinuxForever { get; set; }
    }
}