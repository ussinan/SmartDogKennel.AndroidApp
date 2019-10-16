using System;

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