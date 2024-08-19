using Newtonsoft.Json;

namespace ZendeskApi_v2.Models.Users
{
    public class IndividualUserFieldResponse
    {
        [JsonProperty("user_field")]
        public UserField UserField { get; set; }
    }
}
