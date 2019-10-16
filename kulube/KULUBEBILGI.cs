using System;
using Newtonsoft.Json;

namespace kulube
{
    public class KULUBEBILGI
    {
        [JsonProperty("id")]
        public string id { get; set; }

        [JsonProperty("ad")]
        public string ad { get; set; }

        [JsonProperty("su")]
        public string su { get; set; }

        [JsonProperty("yemek")]
        public string yemek { get; set; }

        [JsonProperty("temp")]
        public int temp { get; set; }

        [JsonProperty("updatedAt")]
        public DateTime updatedAt { get; set; }

        [JsonProperty("version")]
        public string version { get; set; }

        [JsonProperty("createdAt")]
        public DateTime createdAt { get; set; }

        [JsonProperty("deleted")]
        public bool deleted { get; set; }
    }
}