using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DriveSchool
{
    internal class User
    {
        public string Id;
        public string Name { get; set; }

        private string password;

        public string Password
        {
            get { return password; }
            set { password = value; }
        }
    }



}
