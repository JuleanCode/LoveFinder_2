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
    public static class ChatService
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

        public static void CreateChat(int firstUser_ID, int secondUser_ID)
        {
            Init();

            Chat chat = new Chat()
            {
                FirstUser_ID = firstUser_ID,
                SecondUser_ID = secondUser_ID
            };

            db.Insert(chat);
        }
    }
}
