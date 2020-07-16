namespace SUIT.Models.Settings
{
    public class AuthorizationSettings : IAuthorizationSettings
    {
        public string SteamKey { get; set; }
        public string TwitchID { get; set; }
        public string TwitchToken { get; set; }
        public string DiscordToken { get; set; }
    }

    public interface IAuthorizationSettings
    {
        string SteamKey { get; set; }
        string TwitchID { get; set; }
        string TwitchToken { get; set; }
        string DiscordToken { get; set; }
    }
}