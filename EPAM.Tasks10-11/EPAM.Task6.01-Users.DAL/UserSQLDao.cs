using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EPAM.Task6._01_Users.Entities;

namespace EPAM.Task6._01_Users.DAL
{
    public class UserSQLDao : IUserDao
    {
        private string connectionString;
        private TextInfo textInfo = new CultureInfo("us-US", false).TextInfo;

        public UserSQLDao()
        {
            this.connectionString = ConfigurationManager.ConnectionStrings["Default"].ConnectionString;
        }

        public bool AddAward(Award award)
        {
            using (var sqlConnection = new SqlConnection(this.connectionString))
            {
                var cmd = sqlConnection.CreateCommand();

                cmd.CommandText = "AddAward";
                cmd.CommandType = CommandType.StoredProcedure;

                var parameterTitle = new SqlParameter("@Title", award.Title);
                cmd.Parameters.Add(parameterTitle);

                sqlConnection.Open();
                cmd.ExecuteNonQuery();
                return true;
            }
        }

        public void AddAwardToUser(int id, Award award)
        {
            using (var sqlConnection = new SqlConnection(this.connectionString))
            {
                var cmd = sqlConnection.CreateCommand();

                cmd.CommandText = "AddAwardToUser";
                cmd.CommandType = CommandType.StoredProcedure;

                var parametereUserId = new SqlParameter("@USerID", id);
                cmd.Parameters.Add(parametereUserId);

                var parameterAwardTitle = new SqlParameter("@AwardTitle", award.Title);
                cmd.Parameters.Add(parameterAwardTitle);

                sqlConnection.Open();
                cmd.ExecuteNonQuery();
            }
        }

        public void AddProgramUser(ProgramUser user)
        {
            using (var sqlConnection = new SqlConnection(this.connectionString))
            {
                var cmd = sqlConnection.CreateCommand();

                cmd.CommandText = "AddProgramUser";
                cmd.CommandType = CommandType.StoredProcedure;

                var parameterName = new SqlParameter("@Name", user.Name);
                cmd.Parameters.Add(parameterName);

                var parameterPassword = new SqlParameter("@Password", user.Password);
                cmd.Parameters.Add(parameterPassword);

                var parameterRole = new SqlParameter("@Role", user.Role);
                cmd.Parameters.Add(parameterRole);

                sqlConnection.Open();
                cmd.ExecuteNonQuery();
            }
        }

        public void AddUser(User user)
        {
            using (var sqlConnection = new SqlConnection(this.connectionString))
            {
                var cmd = sqlConnection.CreateCommand();

                cmd.CommandText = "AddUser";
                cmd.CommandType = CommandType.StoredProcedure;

                var parameterFirstName = new SqlParameter("@FirstName", user.FirstName);
                cmd.Parameters.Add(parameterFirstName);

                var parameterLastName = new SqlParameter("@LastName", user.LastName);
                cmd.Parameters.Add(parameterLastName);

                var parameterDateOfBirth = new SqlParameter("@DateOfBirth", user.DateOfBirth);
                cmd.Parameters.Add(parameterDateOfBirth);

                if (user.Image != null)
                {
                    var parameterImage = new SqlParameter("@Image", user.Image);
                    cmd.Parameters.Add(parameterImage);
                }

                sqlConnection.Open();
                cmd.ExecuteNonQuery();
            }
        }

        public bool Authorization(string name, string password)
        {
            string savedPassword;
            using (var sqlConnection = new SqlConnection(this.connectionString))
            {
                var cmd = sqlConnection.CreateCommand();

                cmd.CommandText = "GetPassword";
                cmd.CommandType = CommandType.StoredProcedure;

                var parameterName = new SqlParameter("@Name", name);
                cmd.Parameters.Add(parameterName);

                sqlConnection.Open();
                cmd.ExecuteNonQuery();

                var reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    savedPassword = (string)reader["Password"];
                    if (savedPassword.Equals(password))
                    {
                        return true;
                    }
                }
            }

            return false;
        }

        public void EditProgramUser(string username, string newRole)
        {
            if (!username.ToLower().Equals("admin"))
            {
                using (var sqlConnection = new SqlConnection(this.connectionString))
                {
                    var cmd = sqlConnection.CreateCommand();

                    cmd.CommandText = "EditProgramUser";
                    cmd.CommandType = CommandType.StoredProcedure;

                    var parameterName = new SqlParameter("@Name", username);
                    cmd.Parameters.Add(parameterName);

                    var parameterRole = new SqlParameter("@Role", newRole);
                    cmd.Parameters.Add(parameterRole);

                    sqlConnection.Open();
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public void EditUser(int id, string f_name, string l_name, string b_date)
        {
            using (var sqlConnection = new SqlConnection(this.connectionString))
            {
                var cmd = sqlConnection.CreateCommand();

                cmd.CommandText = "EditUser";
                cmd.CommandType = CommandType.StoredProcedure;

                var parameterId = new SqlParameter("@Id", id);
                cmd.Parameters.Add(parameterId);

                if (!string.IsNullOrWhiteSpace(f_name))
                {
                    var parameterFirstName = new SqlParameter("@FirstName", f_name);
                    cmd.Parameters.Add(parameterFirstName);
                }
                else
                {
                    var parameterFirstName = new SqlParameter("@FirstName", DBNull.Value);
                    cmd.Parameters.Add(parameterFirstName);
                }

                if (!string.IsNullOrWhiteSpace(l_name))
                {
                    var parameterLastName = new SqlParameter("@LastName", l_name);
                    cmd.Parameters.Add(parameterLastName);
                }
                else
                {
                    var parameterLastName = new SqlParameter("@LastName", DBNull.Value);
                    cmd.Parameters.Add(parameterLastName);
                }

                if (!string.IsNullOrWhiteSpace(b_date))
                {
                    if (DateTime.TryParse(b_date, out DateTime temp))
                    {
                        var parameterBirthDate = new SqlParameter("@DateOfBirth", b_date);
                        cmd.Parameters.Add(parameterBirthDate);
                    }
                }
                else
                {
                    var parameterBirthDate = new SqlParameter("@DateOfBirth", DBNull.Value);
                    cmd.Parameters.Add(parameterBirthDate);
                }

                sqlConnection.Open();
                cmd.ExecuteNonQuery();
            }
        }

        public IEnumerable<ProgramUser> GetAllProgramUsers()
        {
            var result = new List<ProgramUser>();
            using (var sqlConnection = new SqlConnection(this.connectionString))
            {
                var cmd = sqlConnection.CreateCommand();
                cmd.CommandText = "GetAllProgramUsers";
                cmd.CommandType = CommandType.Text;
                sqlConnection.Open();
                var reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    result.Add(new ProgramUser((string)reader["Name"], (string)reader["Password"], (string)reader["Role"]));
                }

                return result;
            }
        }

        public IEnumerable<User> GetAllUsers()
        {
            var result = new List<User>();
            using (var sqlConnection = new SqlConnection(this.connectionString))
            {
                var cmd = sqlConnection.CreateCommand();
                cmd.CommandText = "GetAllUsers";
                cmd.CommandType = CommandType.Text;
                sqlConnection.Open();
                var reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    result.Add(new User
                    {
                        Id = (int)reader["ID"],
                        FirstName = (string)reader["FirstName"],
                        LastName = reader["LastName"] as string,
                        DateOfBirth = (DateTime)reader["DateOfBirth"],
                        Image = reader["Image"] as byte[],
                    });
                }

                return result;
            }
        }

        public string GetProgramUserRole(string name)
        {
            string role;
            using (var sqlConnection = new SqlConnection(this.connectionString))
            {
                var cmd = sqlConnection.CreateCommand();

                cmd.CommandText = "GetRole";
                cmd.CommandType = CommandType.StoredProcedure;

                var parameterName = new SqlParameter("@Name", name);
                cmd.Parameters.Add(parameterName);

                sqlConnection.Open();
                cmd.ExecuteNonQuery();

                var reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    role = (string)reader["Role"];
                    return role;
                }
            }

            return string.Empty;
        }

        public string GetUserAwards(int id)
        {
            var result = new List<string>();
            using (var sqlConnection = new SqlConnection(this.connectionString))
            {
                var cmd = sqlConnection.CreateCommand();
                cmd.CommandText = "GetUserAwards";
                cmd.CommandType = CommandType.StoredProcedure;

                var parameterId = new SqlParameter("@Id", id);
                cmd.Parameters.Add(parameterId);

                sqlConnection.Open();
                var reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    result.Add((string)reader["AwardTitle"]);
                }

                StringBuilder temp = new StringBuilder();
                if (result.Count > 0)
                {
                    temp.Append(" Awards: ");
                    foreach (var title in result)
                    {
                        temp.Append($"{this.textInfo.ToTitleCase(title)}, ");
                    }

                    temp.Remove(temp.Length - 2, 2);
                    return temp.ToString();
                }
                else
                {
                    return string.Empty;
                }
            }
        }

        public void RemoveAward(string awardTitle)
        {
            using (var sqlConnection = new SqlConnection(this.connectionString))
            {
                var cmd = sqlConnection.CreateCommand();

                cmd.CommandText = "DeleteAward";
                cmd.CommandType = CommandType.StoredProcedure;

                var parameterAwardTitile = new SqlParameter("@AwardTitle", awardTitle);
                cmd.Parameters.Add(parameterAwardTitile);

                sqlConnection.Open();
                cmd.ExecuteNonQuery();
            }
        }

        public void RemoveProgramUser(string username)
        {
            if (!username.ToLower().Equals("admin"))
            {
                using (var sqlConnection = new SqlConnection(this.connectionString))
                {
                    var cmd = sqlConnection.CreateCommand();

                    cmd.CommandText = "DeleteProgramUser";
                    cmd.CommandType = CommandType.StoredProcedure;

                    var parameterId = new SqlParameter("@Name", username);
                    cmd.Parameters.Add(parameterId);

                    sqlConnection.Open();
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public void RemoveUser(int id)
        {
            using (var sqlConnection = new SqlConnection(this.connectionString))
            {
                var cmd = sqlConnection.CreateCommand();

                cmd.CommandText = "DeleteUser";
                cmd.CommandType = CommandType.StoredProcedure;

                var parameterId = new SqlParameter("@ID", id);
                cmd.Parameters.Add(parameterId);

                sqlConnection.Open();
                cmd.ExecuteNonQuery();
            }
        }
    }
}