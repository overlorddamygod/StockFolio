using Npgsql;
using StockFolio.Model;

namespace StockFolio.Repository
{
    public class TransactionRepository
    {
        DbConnection conn;
        public TransactionRepository(DbConnection conn)
        {
            this.conn = conn;
        }

        public async Task AddTransaction(Transaction transaction)
        {
            string query = "INSERT INTO transactions (user_id, stock_id, quantity, price, type, profit, transaction_date) VALUES (@user_id, @stock_id, @quantity, @price, @type, @profit, @transaction_date)";

            using (NpgsqlCommand cmd = new NpgsqlCommand(query, conn.Connection))
            {
                cmd.Parameters.AddWithValue("user_id", transaction.UserId);
                cmd.Parameters.AddWithValue("stock_id", transaction.StockId);
                cmd.Parameters.AddWithValue("quantity", transaction.Quantity);
                cmd.Parameters.AddWithValue("price", transaction.Price);
                cmd.Parameters.AddWithValue("profit", transaction.Profit);
                cmd.Parameters.AddWithValue("type", (int)transaction.Type);
                cmd.Parameters.AddWithValue("transaction_date", transaction.TransactionDate);

                await cmd.ExecuteNonQueryAsync();
            }
        }

        public List<Transaction> GetTransactionsByUser(int userId)
        {
            List<Transaction> transactions = new List<Transaction>();

            string query = "SELECT * FROM transactions WHERE user_id = @user_id";

            using (NpgsqlCommand cmd = new NpgsqlCommand(query, conn.Connection))
            {
                cmd.Parameters.AddWithValue("user_id", userId);

                using (NpgsqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        Transaction transaction = new Transaction
                        {
                            Id = (Int64)reader["id"],
                            UserId = (int)reader["user_id"],
                            StockId = (int)reader["stock_id"],
                            Quantity = (Int64)reader["quantity"],
                            Price = (Int64)reader["price"],
                            Type = (TransactionType)(int)reader["type"],
                            TransactionDate = Convert.ToDateTime(reader["transaction_date"]),
                            Sold = (Int64)reader["sold"],
                            Profit = (Int64)reader["profit"]
                        };

                        transactions.Add(transaction);
                    }
                }
            }

            return transactions;
        }
        public List<Transaction> GetBuyStockTransactionsByUser(int userId, int stockId)
        {
            List<Transaction> transactions = new List<Transaction>();

            string query = "SELECT * FROM transactions WHERE user_id = @user_id and stock_id = @stock_id and type = 0 ORDER BY transaction_date ASC";

            using (NpgsqlCommand cmd = new NpgsqlCommand(query, conn.Connection))
            {
                cmd.Parameters.AddWithValue("user_id", userId);
                cmd.Parameters.AddWithValue("stock_id", stockId);

                using (NpgsqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        Transaction transaction = new Transaction
                        {
                            Id = (Int64)reader["id"],
                            UserId = (int)reader["user_id"],
                            StockId = (int)reader["stock_id"],
                            Quantity = (Int64)reader["quantity"],
                            Price = (Int64)reader["price"],
                            Type = (TransactionType)(int)reader["type"],
                            TransactionDate = Convert.ToDateTime(reader["transaction_date"]),
                            Sold = (Int64)reader["sold"],
                            Profit = (Int64)reader["profit"]
                        };

                        transactions.Add(transaction);
                    }
                }
            }

            return transactions;
        }

    }
}
