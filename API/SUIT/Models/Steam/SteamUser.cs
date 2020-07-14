using System;
using System.Text.Json.Serialization;

namespace SUIT.Models.Steam
{
    public partial class SteamUser
    {
        [JsonPropertyName("steamid")]
        public string SteamID { get; set; }

        [JsonPropertyName("communityvisibilitystate")]
        public long CommunityVisibilityState { get; set; }

        [JsonPropertyName("profilestate")]
        public long ProfileState { get; set; }

        [JsonPropertyName("personaname")]
        public string PersonaName { get; set; }

        [JsonPropertyName("commentpermission")]
        public long CommentPermission { get; set; }

        [JsonPropertyName("profileurl")]
        public Uri ProfileURL { get; set; }

        [JsonPropertyName("avatar")]
        public Uri Avatar { get; set; }

        [JsonPropertyName("avatarmedium")]
        public Uri AvatarMedium { get; set; }

        [JsonPropertyName("avatarfull")]
        public Uri AvatarFull { get; set; }

        [JsonPropertyName("avatarhash")]
        public string AvatarHash { get; set; }

        [JsonPropertyName("lastlogoff")]
        public long LastLogOff { get; set; }

        [JsonPropertyName("personastate")]
        public long PersonaState { get; set; }

        [JsonPropertyName("primaryclanid")]
        public string PrimaryClanID { get; set; }

        [JsonPropertyName("timecreated")]
        public long TimeCreated { get; set; }

        [JsonPropertyName("personastateflags")]
        public long PersonaStateFlags { get; set; }

        [JsonPropertyName("loccountrycode")]
        public string LocCountryCode { get; set; }
    }
}
