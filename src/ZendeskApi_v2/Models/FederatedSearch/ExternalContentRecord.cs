using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System;
using System.Collections.Generic;
using ZendeskApi_v2.Models.HelpCenter.Translations;

namespace ZendeskApi_v2.Models.FederatedSearch
{
    public class ExternalContentRecord
    {
        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("title")]
        public string Title { get; set; }

        [JsonProperty("url")]
        public string Url { get; set; }

        [JsonProperty("locale")]
        public string Locale { get; set; }

        [JsonProperty("body")]
        public string Body { get; set; }

        [JsonProperty("external_id")]
        public string ExternalId { get; set; }

        [JsonProperty("user_segment_id", NullValueHandling = NullValueHandling.Include,
            DefaultValueHandling = DefaultValueHandling.Include )]
        public string UserSegmentId { get; set; }        

        [JsonProperty("source")]
        public ExternalContentSource Source { get; set; }

        [JsonProperty("type")]
        public ExternalContentType Type { get; set; }

        [JsonProperty("created_at", NullValueHandling = NullValueHandling.Include)]
        [JsonConverter(typeof(IsoDateTimeConverter))]
        public DateTimeOffset CreatedAt { get; set; }

        [JsonProperty("updated_at", NullValueHandling = NullValueHandling.Include)]
        [JsonConverter(typeof(IsoDateTimeConverter))]
        public DateTimeOffset UpdatedAt { get; set; }
    }
    //New class for create/update operations since the Source/Type structures are only required for GET operations
    public class CreateUpdateExternalContentRecord
    {
        [JsonProperty("title")]
        public string Title { get; set; }

        [JsonProperty("url")]
        public string Url { get; set; }

        [JsonProperty("locale")]
        public string Locale { get; set; }

        [JsonProperty("body")]
        public string Body { get; set; }

        [JsonProperty("external_id")]
        public string ExternalId { get; set; }

        [JsonProperty("user_segment_id", NullValueHandling = NullValueHandling.Include,
            DefaultValueHandling = DefaultValueHandling.Include )]
        public string UserSegmentId { get; set; }        

        [JsonProperty("source_id")]
        public string SourceId { get; set; }

        [JsonProperty("type_id")]
        public string TypeId { get; set; }
    }

    public class ExternalContentRecordRequest {
          [JsonProperty("record")]
          public CreateUpdateExternalContentRecord Record { get; set; }
    }
}
