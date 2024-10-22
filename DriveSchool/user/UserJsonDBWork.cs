using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace DriveSchool.user
{
    class UserJsonDBWork
    {
        private static void PutNewUserInFile(UserReg user) {

            try
            {
                string path = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
                path += "\\DriveSchool\\User\\RegData\\List.json";
            
                string data = File.ReadAllText(path);
                List<UserReg> users = Newtonsoft.Json.JsonConvert.DeserializeObject<List<UserReg>>(data);
                users.Add(user);

                string jsn = Newtonsoft.Json.JsonConvert.SerializeObject(users);

                File.WriteAllText(path, jsn);

            }
            catch (Exception)
            {
              
                throw;
            }
        }

        private static List<UserReg> GetUsersFromFile() { 
            List<UserReg> users = new List<UserReg>();
            
            string path = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
            path += "\\DriveSchool\\User\\RegData\\List.json";

            string data = File.ReadAllText(path);

            users = Newtonsoft.Json.JsonConvert.DeserializeObject<List<UserReg>>(data);

            return users;
        }

        private static bool RegistationCheck(UserReg user)
        {
            List<UserReg> users = GetUsersFromFile();

            foreach (var item in users)
            {
                if (item.Name == user.Name)
                {
                    return false; //Такое имя уже занято 
                }
            }

            return true;
        }

        public static UserReg Registration(UserReg user)
        {
            if (!RegistationCheck(user))
            {
                return user;
            }
            
            List<UserReg> users = GetUsersFromFile();
            string MaxId = users[users.Count - 1].Id;
            user.Id = MaxId;
            users.Clear();
           
            PutNewUserInFile(user);
            return user;
        }


        //Если пользователь нашелся, то у него будет Id
        //Если нет, то соответственно не будет 
        public static UserReg LogIn(UserReg user) {
            List<UserReg> users = GetUsersFromFile();

            foreach (var item in users) {
                if (item.Name == user.Name && item.Password == user.Password) {
                    user = item;
                    return user;
                }

            }

            return user;
        }

    }
}
