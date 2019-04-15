using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EPAM.Final_Entities
{
    public class User
    {
        public User(int id, string username, string password, string role, bool isBanned)
        {
            this.Id = id;
            this.Username = username;
            this.Password = password;
            this.Role = role;
            this.IsBanned = isBanned;
        }

        public int Id { get; }

        public string Username { get; }

        private string Password { get; }

        public string Role { get; }

        public bool IsBanned { get; }
    }
}

