using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Runtime.Serialization.Json;
using System.Runtime.Serialization;

using System.IO;
using Newtonsoft.Json;

namespace SerializeJSON
{
    class Program
    {
        public static List<User> Users;

        static void Main(string[] args)
        {
            User user = new User();
            int i = 0;
            
            for(i=0; i<5; i++)
            {
                user = CreateUser();
                Serialize(user);
            }

            Users = Deserialize();

            for (i=0; i<Users.Count; i++)
            {
                ShowUser(Users[i]);
            }
        }

        public static void ShowUser(User u)
        {
            string write = "Name - " + u.Name + "\nAge - " + u.Age + "\nSex - " + u.Sex + "\nId - " + u.Id + "\n";
            Console.WriteLine(write);
        }

        public static void Serialize(User user)
        {
            var fileName = "DATA.json";
            var users = Deserialize();
            users.Add(user);
            var json = JsonConvert.SerializeObject(users);
            File.WriteAllText(fileName, json);
        }

        public static List<User> Deserialize()
        {
            var users = new List<User>();
            var fileName = "DATA.json";

            if (File.Exists(fileName))
            {
                var jsonText = File.ReadAllText(fileName);
                users = JsonConvert.DeserializeObject<List<User>>(jsonText);
            }

            return users;
        }

        public static User CreateUser()
        {
            string[] str = { "Name ", "Age ", "Sex ( 0 = Man, 1 = Woman) ", "Id ", "Exit y/n ?", "Show Users? y/n" };
            var user = new User();
            user.Id = MyRand.RandSrt(5);
            user.Name = MyRand.RandSrt(10);
            Console.WriteLine(str[0] + user.Name);
            user.Age = MyRand.RandNum(18, 40);
            Console.WriteLine(str[1] + user.Age);
            user.Sex = (Gender)MyRand.RandNum(0, 2);
            Console.WriteLine(str[2] + user.Sex);
            return user;
        }

    }

    }
