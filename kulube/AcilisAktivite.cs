using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Android.App;
using Android.Content;
using Android.OS;

namespace kulube
{
    [Activity(Label = "AcilisAktivite")]
    public class AcilisAktivite : Activity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.Acilis);
            SimulateStartup();
            async void SimulateStartup()
            {
              await Task.Delay(2500); 
              StartActivity(new Intent(Application.Context, typeof(GirisAktivite)));
            }
        }
    }
}