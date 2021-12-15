using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace LoveFinder.Models
{
    public class Text
    {
        [PrimaryKey, AutoIncrement]
        public int ID { get; set; }
        public string Content { get; set; }
        public int Chat_ID { get; set; }
        public int User_ID { get; set; }

        //public Chat Chat { get; set; }
        //public User User { get; set; }
    }
}
