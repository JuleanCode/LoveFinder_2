using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace LoveFinder.Models
{
    public class Swipe
    {
        [PrimaryKey, AutoIncrement]
        public int ID { get; set; }
        public int FirstUser_ID { get; set; }
        public int SecondUser_ID { get; set; }
        public bool Liked { get; set; }

        //public User FirstUser { get; set; }
        //public User SecondtUser { get; set; }
    }
}
