using System;

namespace kulube
{
    class userLogin
    {
        private String UserName;
        private String UserPassword;

        public String mUserName
        {
            get { return UserName; }
            set { UserName = value; }
        }

        public String mUserPassword
        {
            get { return UserPassword; }
            set { UserPassword = value; }
        }

        public int dogrulama() {
            int cmp = 5;

            cmp = string.Compare(this.UserName, "sinan");
            if (cmp == 0)
                return 1;
            else
                return 0;
          }
    }
}