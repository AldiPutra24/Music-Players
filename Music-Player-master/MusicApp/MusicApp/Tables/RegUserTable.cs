using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace MusicApp.Tables
{
    public class RegUserTable
    {
        [PrimaryKey, AutoIncrement]
        public int UserId { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }

        public string email { get; set; }

    }
}
