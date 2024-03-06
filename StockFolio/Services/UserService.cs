using Npgsql;
using StockFolio.Model;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace StockFolio.Services
{
    public class UserService: IUserService
    {
        DbConnection conn;

        public UserService(DbConnection conn)
        {
            this.conn = conn;
        }
        public User? GetUserWithEmail(string email)
        {
            using (NpgsqlCommand cmd = new NpgsqlCommand("SELECT * FROM users WHERE email = @email LIMIT 1", conn.Connection))
            {
                cmd.Parameters.AddWithValue("email", email);

                using (NpgsqlDataReader reader = cmd.ExecuteReader())
                {
                    if (!reader.Read())
                    {
                        return null;
                    }

                    return new User
                    {
                        Id = (int)reader["id"],
                        Username = (string)reader["username"],
                        Email = (string)reader["email"],
                        Password = (string)reader["password"]
                    };
                }
            }
        }

        public User? AddUser(User user)
        {
            string query = "INSERT INTO users (username, email, password) VALUES (@username, @email, @password)";
            try
            {
                using (NpgsqlCommand cmd = new NpgsqlCommand(query, conn.Connection))
                {
                    cmd.Parameters.AddWithValue("username", user.Username);
                    cmd.Parameters.AddWithValue("email", user.Email);
                    cmd.Parameters.AddWithValue("password", user.Password);
                    cmd.ExecuteNonQuery();
                    return user;
                }
            } catch { return null; }
        }
    }
}
