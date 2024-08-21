using System.Collections.Generic;
using Newtonsoft.Json;

namespace ZendeskApi_v2.Models.Users
{
    public class GroupUserFieldResponse : GroupResponseBase
    {
        [JsonProperty("user_fields")]
        public IList<UserField> UserFields { get; set; }
    }
}
