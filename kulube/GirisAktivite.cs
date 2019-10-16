using System;
using Android.App;
using Android.OS;
using Android.Content;
using Android.Runtime;
using Android.Support.Design.Widget;
using Android.Support.V7.App;
using Android.Views;
using Android.Widget;
using System.Threading;
using Microsoft.WindowsAzure.MobileServices;
using Microsoft.WindowsAzure.MobileServices.SQLiteStore;
using Microsoft.WindowsAzure.MobileServices.Sync;
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

        protected override async void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            MobileServiceClient baskentpaticlubClient = new MobileServiceClient("https://baskentpaticlub.azurewebsites.net");
            IMobileServiceTable KULUBETEMELTABLO = baskentpaticlubClient.GetTable("KULUBETEMEL");
            CurrentPlatform.Init();


            SetContentView(Resource.Layout.activity_kulubesec);
            mSpinner = FindViewById<Spinner>(Resource.Id.spinner1);

            JToken babayaro = await KULUBETEMELTABLO.ReadAsync("$select= id , createdAt , updatedAt, version , deleted ,KULUBEADI, KULUBEBOLGE, KULUBEID ");
            List<KULUBETEMEL> items = JsonConvert.DeserializeObject<List<KULUBETEMEL>>(babayaro.ToString());

            int count = items.Count;

            kSituation = new List<string>();



            for (int i = 0; i < count; i++)
            {
                kSituation.Add(items[i].KULUBEADI);
            }

            ArrayAdapter<string> adapter = new ArrayAdapter<string>(this, Android.Resource.Layout.SimpleListItem1, kSituation);
            mSpinner.Adapter = adapter;
            string firstitem = mSpinner.SelectedItem.ToString();
        }

        private void ActLikeARequest()
        {
            Intent intent = new Intent(this, typeof(UserActivity));
            this.StartActivity(intent);
        }


    }
}
