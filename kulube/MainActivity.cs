using Android.App;
using Android.OS;
using Android.Content;
using Microsoft.WindowsAzure.MobileServices;

namespace kulube
{
    [Activity(Label = "Kulube", Theme = "@style/AppTheme", MainLauncher = true)]
    public class MainActivity : Activity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
          
            base.OnCreate(savedInstanceState);
            Intent intent = new Intent(this, typeof(AcilisAktivite));
            StartActivity(intent);
            CurrentPlatform.Init();
        }
    }
}

