using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EPAM.Final_Entities
{
    public class User
    {
        public string Username { get; }
        public string Password { get; }
        public bool IsAdmin { get; }

        public User(string username, string password)
        {
            Username = username;
            Password = password;
            IsAdmin = false;
        }
    }
}
