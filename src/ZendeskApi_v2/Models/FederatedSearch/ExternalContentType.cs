using Newtonsoft.Json;

namespace ZendeskApi_v2.Models.FederatedSearch
{
    public class ExternalContentType : ExternalContentBase
    {
        [JsonProperty("name")]
        public string Name { get; set; }
    }

    public class ExternalContentTypeRequest {
        [JsonProperty("type")]
        public ExternalContentType Type { get; set; }    
    }
}
