using System.Collections.Generic;
using Newtonsoft.Json;
using ZendeskApi_v2.Models.FederatedSearch;

namespace ZendeskApi_v2.Models.FederatedSearch
{
    public class GroupExternalContentSourcesResponse : GroupExternalContentResponseBase
    {

        [JsonProperty("Sources")]
        public IList<ExternalContentSource> Sources { get; set; }
    }
}