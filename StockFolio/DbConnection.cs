using Npgsql;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Configuration.Json;

namespace StockFolio
{
    public class DbConnection
    {

        NpgsqlConnection conn;

        public NpgsqlConnection Connection { get { return conn; } }

        public DbConnection()
        {
            InitConnection();
        }

        private void InitConnection()
        {
            IConfiguration configuration = new ConfigurationBuilder()
            .AddJsonFile("appSettings.json", optional: false, reloadOnChange: true)
            .Build();
            string connectionString = configuration.GetConnectionString("DefaultConnection")!;

            conn = new NpgsqlConnection(connectionString);
            conn.Open();
        }

        ~DbConnection()
        {
            conn.Close();
        }
    }
}
