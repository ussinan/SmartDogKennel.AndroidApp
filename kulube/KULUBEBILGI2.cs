using Newtonsoft.Json;
using System;

namespace kulube
{
    public class KULUBEBILGI2
    {
        [JsonProperty("kid")]
        public int kid { get; set; }

        [JsonProperty("su")]
        public bool su { get; set; }

        [JsonProperty("yemek")]
        public bool yemek { get; set; }

        [JsonProperty("sicaklik")]
        public float sicaklik { get; set; }

        [JsonProperty("giriscikis")]
        public int giriscikis { get; set; }

        [JsonProperty("tarih")]
        public DateTime tarih { get; set; }


    }

    public class KULUBEBILGI2Wrapper : Java.Lang.Object
    {
        public KULUBEBILGI2Wrapper(KULUBEBILGI2 item)
        {
            KULUBEBILGI2 = item;
        }

        public KULUBEBILGI2 KULUBEBILGI2 { get; private set; }
    }
}