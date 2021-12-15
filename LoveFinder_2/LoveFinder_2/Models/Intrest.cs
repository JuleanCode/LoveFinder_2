using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace LoveFinder.Models
{
    public class Intrest
    {
        [PrimaryKey, AutoIncrement]
        public int ID { get; set; }
        public string Content { get; set; }

        //public List<User> Users { get; set; }
    }
}
