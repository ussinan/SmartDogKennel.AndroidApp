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

namespace kulube
{
    [Activity(Label = "Kulube", Theme = "@style/AppTheme", MainLauncher = true)]
    public class MainActivity : Activity
    {

        private Button mButtonLogin;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Bu MobileServiceClient, uygulama URL'si kullanılarak Azure Mobil Uygulaması ve
            // Azure Ağ Geçidi ile iletişim kurmak üzere yapılandırılmıştır. Mobil uygulamanızı kullanmaya başlayabilirsiniz!
            MobileServiceClient paticlubClient = new MobileServiceClient("https://paticlub.azurewebsites.net");
            CurrentPlatform.Init();


            SetContentView(Resource.Layout.activity_main);

            mButtonLogin = FindViewById<Button>(Resource.Id.buttonLogin);
            mButtonLogin.Click += (object Sender, EventArgs args) =>
            {
                FragmentTransaction transaction = FragmentManager.BeginTransaction();
                girisYap girisKutusu = new girisYap();
                girisKutusu.Show(transaction, "dialog kutusu");
                girisKutusu.mLoginComplete += GirisKutusu_mLoginComplete;

            };
        }

        private void GirisKutusu_mLoginComplete(object sender, loginEvent e)
        {

            adminLogin newAdminLogin = new adminLogin();
            newAdminLogin.mAdminName = e.eUserName;
            newAdminLogin.mAdminPassword = e.eUserPassword;

            userLogin newUserLogin = new userLogin();
            newUserLogin.mUserName = e.eUserName;
            newUserLogin.mUserPassword = e.eUserPassword;

            int kontrol = 5;
            kontrol = newUserLogin.dogrulama();
            if (kontrol == 1)
            {
                Thread thread = new Thread(ActLikeARequest);
                thread.Start();
            }
            else
            {
                kontrol = newAdminLogin.dogrulama();
                // if (kontrol == 1)
                //    {
                //        Thread thread2 = new Thread(ActAnotherRequest);
                //        thread2.Start();
                //    }
            }
        }

        private void ActLikeARequest()
        {
            Intent intent = new Intent(this, typeof(GirisAktivite));
            this.StartActivity(intent);
        }

        //   private void ActAnotherRequest()
        //  {
        //     Intent intent2 = new Intent(this, typeof(AdminActivity));
        //      this.StartActivity(intent2);
        //  }
    }
}

