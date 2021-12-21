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
    public static class HelperService
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

        //function to thart with a fresh DB
        public static void FreshInstall()
        {
            Init();

            DeleteAllData("Delete All Data");

            List<User> users = new List<User>()
            {
                new User()
                {
                    FirstName = "Admin",
                    LastName = "Admin",
                    Age = 20,
                    Gender = "Male",
                    SexualOrientation = "Hetero",
                    Email = "Admin",
                    Location = "Maastricht",
                    Biography = "Dit is mijn bio",
                    Password = "P@ssw0rd"
                },
                new User()
                {
                    FirstName = "Julean",
                    LastName = "Hommel",
                    Age = 20,
                    Gender = "Male",
                    SexualOrientation = "Hetero",
                    Email = "juleanhommel@gmail.com",
                    Location = "Maastricht",
                    Biography = "Dit is mijn bio",
                    Password = "P@ssw0rd"
                },
                new User()
                {
                    FirstName = "Brandon",
                    LastName = "Weinands",
                    Age = 20,
                    Gender = "Male",
                    SexualOrientation = "Hetero",
                    Email = "brandonweinands@gmail.com",
                    Location = "Maastricht",
                    Biography = "Dit is mijn bio",
                    Password = "P@ssw0rd"
                },
                new User()
                {
                    FirstName = "Eva",
                    LastName = "Wittkatis",
                    Age = 20,
                    Gender = "Female",
                    SexualOrientation = "Hetero",
                    Email = "evawittkatis@gmail.com",
                    Location = "Kerkrade",
                    Biography = "Dit is mijn bio",
                    Password = "P@ssw0rd"
                }
            };
            db.InsertAll(users);

            var allUsers = db.Table<User>().ToList();

            List<ProfileImage> profileImages = new List<ProfileImage>()
            {
                new ProfileImage()
                {
                    ImageUrl = "BlankProfile.jpg",
                    User_ID = allUsers[0].ID
                },
                new ProfileImage()
                {
                    ImageUrl = "BlankProfile.jpg",
                    User_ID = allUsers[1].ID
                },
                new ProfileImage()
                {
                    ImageUrl = "BlankProfile.jpg",
                    User_ID = allUsers[2].ID
                },
                new ProfileImage()
                {
                    ImageUrl = "BlankProfile.jpg",
                    User_ID = allUsers[3].ID
                }
            };
            db.InsertAll(profileImages);

            List<Swipe> swipes = new List<Swipe>()
            {
                new Swipe()
                {
                    FirstUser_ID = allUsers[0].ID,
                    SecondUser_ID = allUsers[1].ID,
                    Liked = true
                },
                new Swipe()
                {
                    FirstUser_ID = allUsers[0].ID,
                    SecondUser_ID = allUsers[2].ID,
                    Liked = true
                },
                new Swipe()
                {
                    FirstUser_ID = allUsers[0].ID,
                    SecondUser_ID = allUsers[3].ID,
                    Liked = true
                },
                new Swipe()
                {
                    FirstUser_ID = allUsers[1].ID,
                    SecondUser_ID = allUsers[0].ID,
                    Liked = true
                },
                new Swipe()
                {
                    FirstUser_ID = allUsers[2].ID,
                    SecondUser_ID = allUsers[0].ID,
                    Liked = true
                },
                new Swipe()
                {
                    FirstUser_ID = allUsers[3].ID,
                    SecondUser_ID = allUsers[0].ID,
                    Liked = true
                }
            };
            db.InsertAll(swipes);

            List<Chat> chats = new List<Chat>()
            {
                new Chat()
                {
                    FirstUser_ID = allUsers[0].ID,
                    SecondUser_ID = allUsers[1].ID
                },
                new Chat()
                {
                    FirstUser_ID = allUsers[0].ID,
                    SecondUser_ID = allUsers[2].ID
                },
                new Chat()
                {
                    FirstUser_ID = allUsers[0].ID,
                    SecondUser_ID = allUsers[3].ID
                }
            };
            db.InsertAll(chats);

            var allChats = db.Table<Chat>().ToList();

            List<Text> texts = new List<Text>()
            {
                new Text()
                {
                    Content = "Hallo",
                    Chat_ID = allChats[0].ID,
                    User_ID = allUsers[0].ID
                },
                new Text()
                {
                    Content = "Hoe gaat het",
                    Chat_ID = allChats[0].ID,
                    User_ID = allUsers[0].ID
                },
                new Text()
                {
                    Content = "Hi",
                    Chat_ID = allChats[1].ID,
                    User_ID = allUsers[0].ID
                },
                new Text()
                {
                    Content = "Hoe gaat het",
                    Chat_ID = allChats[1].ID,
                    User_ID = allUsers[0].ID
                },
                new Text()
                {
                    Content = "Ey",
                    Chat_ID = allChats[2].ID,
                    User_ID = allUsers[0].ID
                },
                new Text()
                {
                    Content = "Hoe gaat het",
                    Chat_ID = allChats[2].ID,
                    User_ID = allUsers[0].ID
                },
            };
            db.InsertAll(texts);
        }

        public static void DeleteAllData(string delete)
        {
            //check so I don't accidentally use this function
            if (delete == "Delete All Data")
            {
                Init();

                db.DeleteAll<User>();
                db.DeleteAll<ProfileImage>();
                db.DeleteAll<Swipe>();
                db.DeleteAll<Chat>();
                db.DeleteAll<Text>();
            }
        }
    }
}
