using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Newtonsoft.Json;

namespace kulube
{
    public class KULUBETEMEL
    {
        [JsonProperty("id")]
        public string id { get; set; }

        [JsonProperty("createdAt")]
        public DateTime createdAt { get; set; }

        [JsonProperty("updatedAt")]
        public DateTime updatedAt { get; set; }

        [JsonProperty("version")]
        public string version { get; set; }

        [JsonProperty("deleted")]
        public bool deleted { get; set; }

        [JsonProperty("KULUBEADI")]
        public string KULUBEADI { get; set; }

        [JsonProperty("KULUBEBOLGE")]
        public string KULUBEBOLGE { get; set; }

        [JsonProperty("KULUBEID")]
        public int KULUBEID { get; set; }

    }

    public class KULUBETEMELWrapper : Java.Lang.Object
    {
        public KULUBETEMELWrapper(KULUBETEMEL item)
        {
            KULUBETEMEL = item;
        }

        public KULUBETEMEL KULUBETEMEL { get; private set; }
    }
}