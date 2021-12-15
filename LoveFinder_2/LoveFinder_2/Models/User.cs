using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace LoveFinder.Models
{
    public class User
    {
        [PrimaryKey, AutoIncrement]
        public int ID { get; set; } 
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int Age { get; set; }
        public string Gender { get; set; }
        public string SexualOrientation { get; set; }
        public string Email { get; set; }
        public string Location { get; set; }
        public string Biography { get; set; }
        public string Password { get; set; }

        //public List<Chat> Chats { get; set; }
        //public List<Text> Texts { get; set; }
        //public List<Intrest> Intrests { get; set; }
        //public List<ProfileImage> ProfileImages { get; set; }
    }
}
