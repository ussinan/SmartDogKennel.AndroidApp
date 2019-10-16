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
    class admin
    {
        private String AdminName;
        private String AdminPassword;

        public String mAdminName
        {
            get { return AdminName; }
            set { AdminName = value; }
        }

        public String mAdminPassword
        {
            get { return AdminPassword; }
            set { AdminPassword = value; }
        }
    }
}