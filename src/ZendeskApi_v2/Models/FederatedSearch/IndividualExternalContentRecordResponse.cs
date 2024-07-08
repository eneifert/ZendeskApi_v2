using System.Collections.Generic;
using Newtonsoft.Json;
using ZendeskApi_v2.Models.FederatedSearch;

namespace ZendeskApi_v2.Models.FederatedSearch
{
    public class IndividualExternalContentRecordResponse
    {
        [JsonProperty("record")]
        public ExternalContentRecord Record { get; set; }
    }
}
