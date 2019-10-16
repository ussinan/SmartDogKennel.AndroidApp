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
    public class KULUBEBILGI2
    {
        [JsonProperty("ad")]
        public string ad { get; set; }

        [JsonProperty("su")]
        public string su { get; set; }

        [JsonProperty("yemek")]
        public string yemek { get; set; }

        [JsonProperty("temp")]
        public int temp { get; set; }


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