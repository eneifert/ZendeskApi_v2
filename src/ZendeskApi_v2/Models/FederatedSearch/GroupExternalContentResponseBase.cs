using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using ZendeskApi_v2.Extensions;
using ZendeskApi_v2.Models.FederatedSearch;

namespace ZendeskApi_v2.Models.FederatedSearch
{
    public interface IGroupExternalContentResponseBase
    {
        GroupExternalContentResponseMeta Meta {get;set;}
    }

    public interface IExternalContentMetaResponseBase
    {
        [JsonProperty("has_more")]
        bool HasMore {get;set;}
        [JsonProperty("after_cursor")]
        string AfterCursor{ get; set;}
        [JsonProperty("before_cursor")]
        string BeforeCursor {get; set;}
    }

    public class GroupExternalContentResponseBase : IGroupExternalContentResponseBase
    {
        [JsonProperty("meta")]
        public GroupExternalContentResponseMeta Meta {get;set;}
    }

    public class GroupExternalContentResponseMeta : IExternalContentMetaResponseBase
    {
        [JsonProperty("has_more")]
        public bool HasMore { get ; set ; }
        [JsonProperty("after_cursor")]
        public string AfterCursor { get; set; }
        [JsonProperty("before_cursor")]
        public string BeforeCursor { get; set; }
    }
}
