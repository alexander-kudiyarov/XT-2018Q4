using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EPAM.Task6._01_Users.Entities
{
    [Serializable]
    public class ProgramUser
    {
        public ProgramUser(string name, string password, string role)
        {
            this.Name = name;
            this.Password = password;
            this.Role = role.ToLower();
        }

        public string Name { get; }

        public string Password { get; }

        public string Role { get; }
    }
}
