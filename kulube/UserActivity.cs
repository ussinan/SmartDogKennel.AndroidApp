using System;
using System.Collections.Generic;
using Android.App;
using Android.Content;
using Android.OS;
using Android.Widget;
using Microsoft.WindowsAzure.MobileServices;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace kulube
{
    [Activity(Label = "activity_user")]
    public class UserActivity : Activity
    {
        private const string Path = "ad";
        private List<string> kSituation;
        private ListView mListView;
        private string gelenKulubeAd;
        private int gelenKulubeId;
        private Button mButtonKonum;
        private Button mButtonKulube;
        private String KullanimSayisi;
        private String tarih;
        private String saat;

        protected override async void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);  
            MobileServiceClient baskentpaticlubClient = new MobileServiceClient("https://baskentpaticlub.azurewebsites.net");
            CurrentPlatform.Init();
            IMobileServiceTable KULUBETABLO = baskentpaticlubClient.GetTable("KULUBEBILGI2");
            kulube newKulube = new kulube();
            gelenKulubeId = Int32.Parse(Intent.GetStringExtra("kId")); 
            gelenKulubeAd = Intent.GetStringExtra("kAd");

            JToken Jkulube = await KULUBETABLO.ReadAsync("$filter=kid eq " + "'" + gelenKulubeId  + "'" + "&$orderby=tarih desc");
            List <KULUBEBILGI2> items = JsonConvert.DeserializeObject<List<KULUBEBILGI2>>(Jkulube.ToString());


            newKulube.mKulubeAdi = "Bölge  : " + gelenKulubeAd;
           
            if(items[0].su == true)
            {
                newKulube.mKulubeSu = "Su Kabı : DOLU...";
            }
            else
            {
                newKulube.mKulubeSu = "Su Kabı : BOŞ !!!";
            }

            if(items[0].yemek == true)
            {
                newKulube.mKulubeYemek = "Yemek Kabı : DOLU...";
            }
            else
            {
                newKulube.mKulubeYemek = "Yemek Kabı : BOŞ !!!";
            }

            newKulube.mKulubeTemp = Convert.ToInt32(items[0].sicaklik);
            newKulube.KulubeHavaDurumu();
            newKulube.mKulubeGirisCikis = items[0].giriscikis;

            SetContentView(Resource.Layout.activity_user);
            mListView = FindViewById<ListView>(Resource.Id.listView);

            if (newKulube.mKulubeGirisCikis > 1)
            {
                KullanimSayisi = (newKulube.mKulubeGirisCikis / 2).ToString();
            }
            if(newKulube.mKulubeGirisCikis <= 1)
            {
                KullanimSayisi = newKulube.mKulubeGirisCikis.ToString();
            }
            tarih = "Son Güncelleme : " + items[0].tarih.ToShortDateString() +" " + items[0].tarih.ToShortTimeString();
            kSituation = new List<string>();
            kSituation.Add(newKulube.mKulubeAdi);
            kSituation.Add(newKulube.mKulubeSu);
            kSituation.Add(newKulube.mKulubeYemek);
            kSituation.Add(newKulube.mKulubeHava);
            kSituation.Add("Kulübe Kullanımı : " + KullanimSayisi + " KEZ..." );
            kSituation.Add(tarih);
          
            ArrayAdapter<string> adapter = new ArrayAdapter<string>(this, Android.Resource.Layout.SimpleListItem1, kSituation);
            mListView.Adapter = adapter;

            mButtonKonum = FindViewById<Button>(Resource.Id.buttonKonum);
            mButtonKonum.Click += (object Sender, EventArgs args) =>
            {
                FragmentTransaction transaction = FragmentManager.BeginTransaction();
                var mapActivity = new Intent(this, typeof(Gmaps));            
                mapActivity.PutExtra("kName",gelenKulubeAd);
                StartActivity(mapActivity);
            };
            mButtonKulube = FindViewById<Button>(Resource.Id.buttonKulube);
            mButtonKulube.Click += (object Sender, EventArgs args) =>
            {
                FragmentTransaction transaction = FragmentManager.BeginTransaction();
                var kulubeActivity = new Intent(this, typeof(GirisAktivite));
                StartActivity(kulubeActivity);
            };
        }
    }
}