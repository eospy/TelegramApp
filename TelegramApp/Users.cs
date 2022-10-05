using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TelegramApp
{
    public class Users
    {
        public Users(string chatid,string login,string password )
        {
            this.Chatid= chatid;
            this.Login= login;
            this.Password= password;
        }
        public int Id { get; set; }
        public string Chatid { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }
    }
}
