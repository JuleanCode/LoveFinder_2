using System;
using System.IO;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Xamarin.Forms;
using SQLite;
using LoveFinder.Models;


namespace LoveFinder_2.Services
{
    public static class UserService
    {
        static SQLiteConnection db;
        static void Init()
        {
            if (db != null)
                return;

            var dataBasePath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "LoveFinder_2.db");

            db = new SQLiteConnection(dataBasePath);

            db.CreateTable<User>();
            db.CreateTable<ProfileImage>();
            db.CreateTable<Swipe>();
            db.CreateTable<Chat>();
            db.CreateTable<Text>();
            db.CreateTable<Intrest>();
        }

        public static void CreateUser(User user)
        {
            Init();

            db.Insert(user);

            user = GetUserByEmail(user.Email);
            Application.Current.Properties["CurentUser_id"] = user.ID.ToString();

            ProfileImageService.CreateProfileImagesNewUser();
        }
        
        public static User GetUser(int ID)
        {
            Init();

            User user  = db.Get<User>(ID);
            return user;
        }

        public static User GetUserByEmail(string Email)
        {
            Init();

            User user = db.Table<User>().First(x => x.Email == Email);
            return user;
        }

        public static void UpdateUser(User user)
        {
            Init();

            db.Update(user);
        }

        public static void DeleteUser(int ID)
        {
            Init();

            db.Delete<User>(ID);
        }

        public static List<User> GetAllUser()
        {
            Init();

            List<User> users  = db.Query<User>($"SELECT * FROM user WHERE ID != {Application.Current.Properties["CurentUser_id"]}");
            return users;
        }

        public static bool CheckUser(string Email, string Password)
        {
            Init();

            try
            {
                var user = db.Table<User>().First(x => x.Email == Email && x.Password == Password);

                Application.Current.Properties["CurentUser_id"] = user.ID.ToString();

                return true;
            }
            catch
            {
                return false;
            }
        }

        public static void DeleteAllUsers()
        {
            Init();

            db.DeleteAll<User>();
        }
    }
}
