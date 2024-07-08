using Newtonsoft.Json;

namespace ZendeskApi_v2.Models.FederatedSearch
{
    public class ExternalContentSource : ExternalContentBase
    {
        [JsonProperty("name")]
        public string Name { get; set; }
    }

    public class ExternalContentSourceRequest {
        [JsonProperty("source")]
        public ExternalContentSource Source { get; set; }
    }
}
