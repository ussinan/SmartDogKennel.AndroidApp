using System;
using Android.App;
using Android.OS;
using Android.Views;
using Android.Widget;

namespace kulube
{
    public class loginEvent : EventArgs
    {
        private String sUserName;
        private String sUserPassword;

        public string eUserName
        {
            get { return sUserName; }
            set { sUserName = value; }
        }

        public string eUserPassword
        {
            get { return sUserPassword; }
            set { sUserPassword = value; }
        }

        public loginEvent(string userName,string userPassword) : base()
        {
            eUserName = userName;
            eUserPassword = userPassword;
        }
    }

    class girisYap : DialogFragment
    {

        private EditText txtUser;
        private EditText txtPass;
        private Button buttonGiris;

        public event EventHandler<loginEvent> mLoginComplete;

        public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        {
           base.OnCreateView(inflater, container, savedInstanceState);

            var view = inflater.Inflate(Resource.Layout.girisDiyalog, container, false);

            txtUser = view.FindViewById<EditText>(Resource.Id.txtUserName);
            txtPass = view.FindViewById<EditText>(Resource.Id.txtPassword);
            buttonGiris = view.FindViewById<Button>(Resource.Id.buttonGirisYap);

            buttonGiris.Click += ButtonGiris_Click;


            return view;

        }

        private void ButtonGiris_Click(object sender, EventArgs e)
        {
            mLoginComplete.Invoke(this, new loginEvent(txtUser.Text, txtPass.Text));
            this.Dismiss();
        }
    }
}