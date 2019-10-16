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

namespace kulube
{
    class user
    {
        private String UserName;
        private String UserPassword;

        public String mUserName
        {
            get{ return UserName;}
            set { UserName = value; }
        }

        public String mUserPassword
        {
            get { return UserPassword; }
            set { UserPassword = value; }
        }


    }
}