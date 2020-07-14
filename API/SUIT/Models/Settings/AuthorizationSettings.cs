namespace SUIT.Models.Settings
{
    public class AuthorizationSettings : IAuthorizationSettings
    {
        public string SteamKey { get; set; }
        public string DiscordToken { get; set; }
    }

    public interface IAuthorizationSettings
    {
        string SteamKey { get; set; }
        string DiscordToken { get; set; }
    }
}