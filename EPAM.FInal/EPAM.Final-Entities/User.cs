using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EPAM.Final_Entities
{
    public class User
    {
        public User(int id, string username, string[] roles)
        {
            this.Id = id;
            this.Username = username;
            this.Roles = roles;
        }

        public int Id { get; }

        public string Username { get; }

        public string[] Roles { get; }
    }
}
