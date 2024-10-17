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
        private static void PutNewUserInFile(User user) {
            
            string path = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
            path += "\\DriveSchool\\User\\List.json";

            
            string data = File.ReadAllText(path);
            List<User> users = Newtonsoft.Json.JsonConvert.DeserializeObject<List<User>>(data);
            users.Add(user);

            string jsn = Newtonsoft.Json.JsonConvert.SerializeObject(users);

            File.WriteAllText(path, jsn);
        }

        private static List<User> GetUsersFromFile() { 
            List<User> users = new List<User>();
            
            string path = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
            path += "\\DriveSchool\\User\\List.json";

            string data = File.ReadAllText(path);

            users = Newtonsoft.Json.JsonConvert.DeserializeObject<List<User>>(data);

            return users;
        }

        private static bool RegistationCheck(User user)
        {
            List<User> users = GetUsersFromFile();

            foreach (var item in users)
            {
                if (item.Name == user.Name)
                {
                    return false; //Такое имя уже занято 
                }
            }

            return true;
        }

        public static User Registration(User user)
        {
            if (!RegistationCheck(user))
            {
                return user;
            }
            
            List<User> users = GetUsersFromFile();
            string MaxId = users[users.Count - 1].Id;
            user.Id = MaxId;
            users.Clear();
           
            PutNewUserInFile(user);
            return user;
        }


        //Если пользователь нашелся, то у него будет Id
        //Если нет, то соответственно не будет 
        public static User LogIn(User user) {
            List<User> users = GetUsersFromFile();

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
