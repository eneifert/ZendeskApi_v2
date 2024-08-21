using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using ZendeskApi_v2.Models.Shared;

namespace ZendeskApi_v2.Models.Users
{
    public class UserField
    {
        [JsonProperty("url")]
        public string Url { get; set; }

        [JsonProperty("id")]
        public long? Id { get; set; }

        [JsonProperty("type")]
        public string Type { get; set; }

        [JsonProperty("key")]
        public string Key { get; set; }

        [JsonProperty("title")]
        public string Title { get; set; }

        [JsonProperty("description")]
        public string Description { get; set; }

        [JsonProperty("raw_title")]
        public string RawTitle { get; set; }

        [JsonProperty("raw_description")]
        public string RawDescription { get; set; }

        [JsonProperty("position")]
        public long? Position { get; set; }

        [JsonProperty("active")]
        public bool? Active { get; set; }

        [JsonProperty("system")]
        public bool? System { get; set; }

        [JsonProperty("regexp_for_validation")]
        public string RegexpForValidation { get; set; }

        [JsonProperty("created_at")]
        [JsonConverter(typeof(IsoDateTimeConverter))]
        public DateTimeOffset? CreatedAt { get; set; }

        [JsonProperty("updated_at")]
        [JsonConverter(typeof(IsoDateTimeConverter))]
        public DateTimeOffset? UpdatedAt { get; set; }

        [JsonProperty("tag")]
        public string Tag { get; set; }

        [JsonProperty("custom_field_options")]
        public IList<CustomFieldOption> CustomFieldOptions { get; set; }
    }
}
