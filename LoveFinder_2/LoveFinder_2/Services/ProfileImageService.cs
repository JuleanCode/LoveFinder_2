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
    public static class ProfileImageService
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

        public static void CreateProfileImagesNewUser()
        {
            Init();

            ProfileImage profileImage = new ProfileImage()
            {
                ImageUrl = "BlankProfile.jpg",
                User_ID = Int32.Parse(Application.Current.Properties["CurentUser_id"].ToString())
            };

            db.Insert(profileImage);
        }
        public static void UpdateUserProfileImages(string NewImagePath)
        {
            Init();

            List<ProfileImage> profileImage = GetUserProfileImages(Int32.Parse(Application.Current.Properties["CurentUser_id"].ToString()));
            profileImage[0].ImageUrl = NewImagePath;

            db.Update(profileImage[0]);
        }
        public static List<ProfileImage> GetUserProfileImages(int ID)
        {
            Init();

            return db.Table<ProfileImage>().Where(x => x.ID == ID).ToList();
        }
    }
}
