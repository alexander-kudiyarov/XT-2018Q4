namespace EPAM.Final_Entities
{
    public class User
    {
        public User(int id, string username, string role)
        {
            this.Id = id;
            this.Username = username;
            this.Role = role;
        }

        public int Id { get; }

        public string Username { get; }

        public string Role { get; }
    }
}