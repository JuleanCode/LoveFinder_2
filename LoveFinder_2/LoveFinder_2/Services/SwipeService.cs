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
    public static class SwipeService
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

        public static void Swipe(int firstUser_ID, int secondUser_ID, bool liked)
        {
            Init();

            if(CheckSwipe(firstUser_ID, secondUser_ID))
            {
                Swipe swipe = new Swipe()
                {
                    FirstUser_ID = firstUser_ID,
                    SecondUser_ID = secondUser_ID,
                    Liked = liked
                };

                db.Insert(swipe);

                if(CheckMatch(firstUser_ID, secondUser_ID))
                {
                    ChatService.CreateChat(firstUser_ID, secondUser_ID);

                    Application.Current.MainPage.DisplayAlert("Alert", "It's a match!", "OK");
                }
            }
        }

        public static bool CheckSwipe(int firstUser_ID, int secondUser_ID)
        {
            Init();

            try
            {
                var swipe = db.Table<Swipe>().First(x => x.FirstUser_ID == firstUser_ID && x.SecondUser_ID == secondUser_ID);
                return false;
            }
            catch
            {
                return true;
            }
        }

        public static bool CheckMatch(int firstUser_ID, int secondUser_ID)
        {
            Init();

            try
            {
                var swipe = db.Table<Swipe>().First(x => x.FirstUser_ID == secondUser_ID && x.SecondUser_ID == firstUser_ID);

                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}
