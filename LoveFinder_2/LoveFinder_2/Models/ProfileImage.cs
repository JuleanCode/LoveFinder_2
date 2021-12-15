using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace LoveFinder.Models
{
    public class ProfileImage
    {
        [PrimaryKey, AutoIncrement]
        public int ID { get; set; }
        public string ImageUrl { get; set; }
        public int User_ID { get; set; }

        //public User User { get; set; }
    }
}
