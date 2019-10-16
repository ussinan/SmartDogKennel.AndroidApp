using Newtonsoft.Json;

namespace kulube
{
    public class KULUBETEMEL
    {

        [JsonProperty("KULUBEADI")]
        public string KULUBEADI { get; set; }

        [JsonProperty("KULUBEBOLGE")]
        public string KULUBEBOLGE { get; set; }

        [JsonProperty("KULUBEID")]
        public int KULUBEID { get; set; }

        [JsonProperty("LAT")]
        public float LAT { get; set; }

        [JsonProperty("LNG")]
        public float LNG { get; set; }
    }
}