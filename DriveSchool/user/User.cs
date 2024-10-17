using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DriveSchool.user
{
    internal class User
    {
        public string Id;
        public string Name;

        private string password;

        public string Password
        {
            get { return password; }
            set { password = value; }
        }


    }
}
