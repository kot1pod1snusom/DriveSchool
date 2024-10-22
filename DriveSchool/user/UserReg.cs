using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DriveSchool.user
{
    internal class UserReg
    {
        public string Id;
        public string Name;

        //Путь до файла с данными пользователя 
        private string UserDataPath;

        private string password;

        public string Password
        {
            get { return password; }
            set { password = value; }
        }

        public string GetUserDataPath() { return UserDataPath; }

    }
}
