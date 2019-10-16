using System;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System;
using System.Collections.Generic;
using System.Linq;


using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Microsoft.WindowsAzure.MobileServices;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using SQLite;
using System.Runtime.Serialization.Json;
using System.Runtime.Serialization;



using kulube;
using Simple.OData.Client;
using Java.Lang;

namespace kulube
{
    [Activity(Label = "activity_user")]
    public class UserActivity : Activity
    {
        private const string Path = "ad";
        private List<string> kSituation;
        private ListView mListView;
        private IMobileServiceTable<KULUBEBILGI2> KULUBETABLO;
       

        protected override async void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            // AzureMobileService azureClient = new AzureMobileService();
            MobileServiceClient baskentpaticlubClient = new MobileServiceClient("https://baskentpaticlub.azurewebsites.net");
          //  MobileServiceClient paticlubClient = new MobileServiceClient("https://paticlub.azurewebsites.net");
            CurrentPlatform.Init();
            IMobileServiceTable KULUBETABLO = baskentpaticlubClient.GetTable("KULUBEBILGI2");
            IMobileServiceTable KULUBETEMELTABLO = baskentpaticlubClient.GetTable("KULUBETEMEL");

            kulube newKulube = new kulube();
           // INSERT INTO KULUBETEMEL(KULUBEADI, KULUBEBOLGE, KULUBEID) VALUES('birlik', 'cankaya', 1);


            string kad = "Birlik";

            JToken ktemel = await KULUBETEMELTABLO.ReadAsync("$filter = KULUBEADI  ");



            JToken babayaro = await KULUBETABLO.ReadAsync("$filter=AD eq " + "'" + kad  + "'"  );
            JObject jo = new JObject();
            var obj = JsonConvert.DeserializeObject(babayaro.ToString());
            string asd = obj.ToString();
            List<KULUBEBILGI> items = JsonConvert.DeserializeObject<List<KULUBEBILGI>>(babayaro.ToString());

            // JObject jo = new JObject();

            // var tracknames = klb.ad;


            //jo.Add("AD", "Hello World");
            //jo.Add("SU", "ASFD");

            // var inserted = await KULUBETABLO.InsertAsync(jo);

            


            newKulube.mKulubeAdi = items[0].ad;
            newKulube.mKulubeSu = items[0].su;
            newKulube.mKulubeYemek = items[0].yemek;
            newKulube.mKulubeTemp = items[0].temp;
            newKulube.KulubeHavaDurumu();

            SetContentView(Resource.Layout.activity_user);
            mListView = FindViewById<ListView>(Resource.Id.listView1);
            kSituation = new List<string>();
            kSituation.Add(newKulube.mKulubeAdi);
            kSituation.Add(newKulube.mKulubeSu);
            kSituation.Add(newKulube.mKulubeYemek);
            kSituation.Add(newKulube.mKulubeHava);
          
            ArrayAdapter<string> adapter = new ArrayAdapter<string>(this, Android.Resource.Layout.SimpleListItem1, kSituation);
            mListView.Adapter = adapter;


        }
    }
}