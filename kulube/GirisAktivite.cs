using Android.App;
using Android.OS;
using Android.Content;
using Android.Widget;
using Microsoft.WindowsAzure.MobileServices;
using System.Collections.Generic;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace kulube
{
    [Activity(Label = "GirisAktivite")]
    public class GirisAktivite : Activity
    {
        private List<string> kSituation;
        private Spinner mSpinner;
        private string kisim;
        private string kId;
        private int counter = 0;

        protected override async void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            MobileServiceClient baskentpaticlubClient = new MobileServiceClient("https://baskentpaticlub.azurewebsites.net");
            IMobileServiceTable KULUBETEMELTABLO = baskentpaticlubClient.GetTable("KULUBETEMEL");
            CurrentPlatform.Init();
            SetContentView(Resource.Layout.activity_kulubesec);
            mSpinner = FindViewById<Spinner>(Resource.Id.spinner1);

            JToken JKulube = await KULUBETEMELTABLO.ReadAsync("$select= KULUBEADI, KULUBEBOLGE, KULUBEID, LAT, LNG");
            List <KULUBETEMEL> items = JsonConvert.DeserializeObject<List<KULUBETEMEL>>(JKulube.ToString());

            int count = items.Count;
            kSituation = new List<string>();
            kSituation.Add ("");
          
            for (int i = 0; i < count; i++)
            {
               kSituation.Add(items[i].KULUBEADI);
            }
            ArrayAdapter<string> adapter = new ArrayAdapter<string>(this, Android.Resource.Layout.SimpleListItem1, kSituation);
            mSpinner.Adapter = adapter;
            mSpinner.ItemSelected += mSpinner_ItemSelected;
        }

        async void mSpinner_ItemSelected(object sender, AdapterView.ItemSelectedEventArgs e)
        {
            if (counter == 0) { counter++; }
            else { 
            MobileServiceClient baskentpaticlubClient = new MobileServiceClient("https://baskentpaticlub.azurewebsites.net");
            IMobileServiceTable KULUBETEMELTABLO = baskentpaticlubClient.GetTable("KULUBETEMEL");
            
            kisim = e.Parent.GetItemAtPosition(e.Position).ToString();
            JToken JKulube = await KULUBETEMELTABLO.ReadAsync("$filter=KULUBEADI eq" + "'" + kisim +"'" );
            List<KULUBETEMEL> items = JsonConvert.DeserializeObject<List<KULUBETEMEL>>(JKulube.ToString());
            var activity2 = new Intent(this, typeof(UserActivity));
            kId = (items[0].KULUBEID).ToString();
                activity2.PutExtra("kId", kId);
                activity2.PutExtra("kAd", items[0].KULUBEADI);
                StartActivity(activity2);
            }
        }
    }
}
