using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EPAM.Final_DAL.Interfaces;
using EPAM.Final_Entities;

namespace EPAM.Final_DAL
{
    public class UserSQLDao : SQLDao, IUserDao
    {
        public bool Authentication(string username, string password)
        {
            using (var sqlConnection = new SqlConnection(ConnectionString))
            {
                this.CreateSQLCommand(sqlConnection, out SqlCommand cmd, "Authentication");

                this.AddSQLParameter(cmd, "@username", username);

                sqlConnection.Open();

                var reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    string savedPassword = (string)reader["password"];
                    if (savedPassword.Equals(password))
                    {
                        return true;
                    }
                }

                return false;
            }
        }

        public string GetRole(string username)
        {
            using (var sqlConnection = new SqlConnection(ConnectionString))
            {
                this.CreateSQLCommand(sqlConnection, out SqlCommand cmd, "GetRole");

                this.AddSQLParameter(cmd, "@username", username);

                sqlConnection.Open();

                var reader = cmd.ExecuteReader();

                string role = null;

                while (reader.Read())
                {
                    role = (string)reader["role"];
                }

                return role;
            }
        }

        public int New(string username, string password)
        {
            using (var sqlConnection = new SqlConnection(ConnectionString))
            {
                this.CreateSQLCommand(sqlConnection, out SqlCommand cmd, "NewUser");

                this.AddSQLParameter(cmd, "@username", username);

                this.AddSQLParameter(cmd, "@password", password);

                int id = errorCode;

                if (ReadSQLResult(sqlConnection, cmd, out SqlDataReader reader))
                {
                    while (reader.Read())
                    {
                        id = (int)reader["id"];
                    }
                }

                return id;
            }
        }

        public int Edit(int id, string newUsername, string newPassword)
        {
            using (var sqlConnection = new SqlConnection(ConnectionString))
            {
                this.CreateSQLCommand(sqlConnection, out SqlCommand cmd, "EditUser");

                this.AddSQLParameter(cmd, "@id", id);

                if (!string.IsNullOrWhiteSpace(newUsername))
                {
                    this.AddSQLParameter(cmd, "@newUsername", newUsername);
                }
                else
                {
                    this.AddSQLParameter(cmd, "@newUsername", DBNull.Value);
                }

                if (!string.IsNullOrWhiteSpace(newPassword))
                {
                    this.AddSQLParameter(cmd, "@newPassword", newPassword);
                }
                else
                {
                    this.AddSQLParameter(cmd, "@newPassword", DBNull.Value);
                }

                return ExecuteSQLCommand(sqlConnection, cmd) ? id : errorCode;
            }
        }

        public int EditRole(int id, int newRoleId)
        {
            using (var sqlConnection = new SqlConnection(ConnectionString))
            {
                this.CreateSQLCommand(sqlConnection, out SqlCommand cmd, "EditUserRole");

                this.AddSQLParameter(cmd, "@userId", id);

                this.AddSQLParameter(cmd, "@newRoleId", newRoleId);

                return ExecuteSQLCommand(sqlConnection, cmd) ? id : errorCode;
            }
        }

        public int Delete(int id)
        {
            using (var sqlConnection = new SqlConnection(ConnectionString))
            {
                this.CreateSQLCommand(sqlConnection, out SqlCommand cmd, "DeleteUser");

                this.AddSQLParameter(cmd, "@id", id);

                return ExecuteSQLCommand(sqlConnection, cmd) ? id : errorCode;
            }
        }

        public User Get(int id)
        {
            using (var sqlConnection = new SqlConnection(ConnectionString))
            {
                this.CreateSQLCommand(sqlConnection, out SqlCommand cmd, "GetUser");

                this.AddSQLParameter(cmd, "@id", id);

                sqlConnection.Open();

                var reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    return new User((int)reader["id"], (string)reader["username"], (string)reader["role"]);
                }

                return null;
            }
        }

        public IEnumerable<User> GetAll()
        {
            using (var sqlConnection = new SqlConnection(ConnectionString))
            {
                this.CreateSQLCommand(sqlConnection, out SqlCommand cmd, "GetUsers");

                sqlConnection.Open();

                var reader = cmd.ExecuteReader();

                var result = new List<User>();

                while (reader.Read())
                {
                    result.Add(new User((int)reader["id"], (string)reader["username"], (string)reader["role"]));
                }

                return result;
            }
        }

        public int GetId(string username)
        {
            using (var sqlConnection = new SqlConnection(ConnectionString))
            {
                this.CreateSQLCommand(sqlConnection, out SqlCommand cmd, "GetUserId");

                this.AddSQLParameter(cmd, "@username", username);

                sqlConnection.Open();
                var reader = cmd.ExecuteReader();

                int id = errorCode;

                while (reader.Read())
                {
                    id = (int)reader["id"];
                }

                return id;
            }
        }
    }
}
