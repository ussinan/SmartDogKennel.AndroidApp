using System.Collections.Generic;
using Microsoft.WindowsAzure.MobileServices;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Android.App;
using Android.Content;
using Android.OS;
using Android.Gms.Maps;
using Android.Gms.Maps.Model;

namespace kulube
{
    [Activity(Label = "Gmaps")]
    public class Gmaps : Activity , IOnMapReadyCallback
    {
        private GoogleMap mMap;
        private string gelenKulube;
        private float lat;
        private float lng;
       // private string ad;
        protected override async void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);
            MobileServiceClient baskentpaticlubClient = new MobileServiceClient("https://baskentpaticlub.azurewebsites.net");
            IMobileServiceTable KULUBETEMELTABLO = baskentpaticlubClient.GetTable("KULUBETEMEL");
            CurrentPlatform.Init();

            gelenKulube = Intent.GetStringExtra("kName");
            JToken ktemel = await KULUBETEMELTABLO.ReadAsync("$filter=KULUBEADI eq " + "'" + gelenKulube + "'");
            List<KULUBETEMEL> Kitems = JsonConvert.DeserializeObject<List<KULUBETEMEL>>(ktemel.ToString()); 
            lat = Kitems[0].LAT;
            lng = Kitems[0].LNG;

            SetContentView(Resource.Layout.activity_gmaps);
            SetUpMap();
        }

        private void SetUpMap()
        {
            if (mMap == null)
            {
                var mapFragment = (MapFragment)FragmentManager.FindFragmentById(Resource.Id.map1);
                mapFragment.GetMapAsync(this);
            }
        }

        public void OnMapReady(GoogleMap googleMap)
        {

            LatLng latlng = new LatLng(lat,lng);
            mMap = googleMap;
            CameraUpdate camera = CameraUpdateFactory.NewLatLngZoom(latlng, 14);
            mMap.MoveCamera(camera);

            MarkerOptions markeropt1 = new MarkerOptions();
            markeropt1.SetPosition(latlng);
            markeropt1.SetTitle("PATI CLUB");
            markeropt1.SetSnippet(gelenKulube + " Pati Evi");
            googleMap.AddMarker(markeropt1);
        }
    }
}