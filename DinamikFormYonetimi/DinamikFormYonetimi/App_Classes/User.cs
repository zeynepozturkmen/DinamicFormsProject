using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DinamikFormYonetimi.App_Classes
{
    public class User
    {
        public string UserName { get; set; }
        public string Password { get; set; }

        public string Email { get; set; }
        public string PasswordQuestion { get; set; }
        public string PasswordAnswer { get; set; }

    }
}