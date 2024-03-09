using Microsoft.VisualBasic.ApplicationServices;
using Microsoft.VisualBasic.Devices;
using Npgsql;
using StockFolio.Model;
using StockFolio.Repository;
using System.Data;

namespace StockFolio.Services
{
    class MyPortfolio
    {
        public int TotalInvestment;
    }

    public class PortfolioService
    {
        TransactionRepository transactionRepository;
        DbConnection conn;
        public PortfolioService(DbConnection conn)
        {
            this.conn = conn;
            transactionRepository = new TransactionRepository(conn);
        }
        public void AddTransaction(Transaction transaction)
        {
            transactionRepository.AddTransaction(transaction);
        }

        public List<Transaction> GetTransactionsByUser(int userId)
        {
            return transactionRepository.GetTransactionsByUser(userId);
        }

        public List<Stock> GetStocks()
        {
            List<Stock> stocks = new List<Stock>();

            string query = "SELECT * FROM stocks";

            using (NpgsqlCommand cmd = new NpgsqlCommand(query, conn.Connection))
            {
                using (NpgsqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        Stock stock = new Stock
                        {
                            Id = (int)reader["id"],
                            CompanyName = reader["company_name"].ToString(),
                            Symbol = reader["symbol"].ToString(),
                            Ltp = (Int64)reader["ltp"],
                            SectorId = (Int64)reader["sector_id"],
                        };

                        stocks.Add(stock);
                    }
                }
            }

            return stocks;
        }
        public List<UserStock> GetStocksByUser(int userId)
        {
            List<UserStock> userStocks = new List<UserStock>();

            string query = "SELECT * FROM user_stocks where user_id = @userId and quantity > 0";

            using (NpgsqlCommand cmd = new NpgsqlCommand(query, conn.Connection))
            {
                cmd.Parameters.AddWithValue("userId", userId);
                using (NpgsqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        UserStock userStock = new UserStock
                        {
                            Id = (Int64)reader["id"],
                            UserId = (int) reader["user_id"],
                            StockId = (int) reader["stock_id"],
                            Investment = (Int64)reader["investment"],
                            Quantity = (Int64)reader["quantity"],
                        };

                        userStocks.Add(userStock);
                    }
                }
            }

            return userStocks;
        }
        public DataTable GetStocksDataTable()
        {
            string query = "SELECT * FROM stocks";

            using (NpgsqlCommand cmd = new NpgsqlCommand(query, conn.Connection))
            {
                using (NpgsqlDataReader reader = cmd.ExecuteReader())
                {
                    DataTable dataTable = new DataTable();
                    dataTable.Load(reader);
                    return dataTable;
                }
            }
        }

        public async Task BuyStock(int userId, int stockId, int quantity, int price)
        {
            try
            {
                // Add the transaction
                await transactionRepository.AddTransaction(new Model.Transaction
                {
                    UserId = userId,
                    StockId = stockId,
                    Quantity = quantity,
                    Price = price,
                    Type = (int)TransactionType.Buy,
                    TransactionDate = DateTime.Now
                });

                // Check if the user already has stocks of this type
                string query = "SELECT * FROM user_stocks WHERE user_id = @userId AND stock_id = @stockId limit 1";
                NpgsqlCommand cmd = new NpgsqlCommand(query, conn.Connection);
                cmd.Parameters.AddWithValue("userId", userId);
                cmd.Parameters.AddWithValue("stockId", stockId);

                NpgsqlDataReader reader = await cmd.ExecuteReaderAsync();

                if (reader.Read())
                {
                    // var userStockQuantity = (Int64)reader["quantity"];
                    reader.Close();

                    // userStockQuantity += quantity;

                    // Update user_stocks table with the new quantity
                    string updateQuery = "UPDATE user_stocks SET quantity = quantity + @quantity, investment = investment + @investment WHERE user_id = @userId AND stock_id = @stockId";
                    NpgsqlCommand updateCmd = new NpgsqlCommand(updateQuery, conn.Connection);
                    updateCmd.Parameters.AddWithValue("quantity", quantity);
                    updateCmd.Parameters.AddWithValue("userId", userId);
                    updateCmd.Parameters.AddWithValue("stockId", stockId);
                    updateCmd.Parameters.AddWithValue("investment", price * quantity);

                    await updateCmd.ExecuteNonQueryAsync();

                }
                else
                {
                    reader.Close();
                    // If the user does not have stocks of this type, insert a new record
                    string insertQuery = "INSERT INTO user_stocks (user_id, stock_id, quantity, investment) VALUES (@userId, @stockId, @quantity, @investment)";
                    NpgsqlCommand insertCmd = new NpgsqlCommand(insertQuery, conn.Connection);
                    insertCmd.Parameters.AddWithValue("userId", userId);
                    insertCmd.Parameters.AddWithValue("stockId", stockId);
                    insertCmd.Parameters.AddWithValue("quantity", quantity);
                    insertCmd.Parameters.AddWithValue("investment", price * quantity);
                    await insertCmd.ExecuteNonQueryAsync();
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }

        public bool CheckSellable(int userId, int stockId, Int64 quantity)
        {
            // query user_stocks for quantity
            string query = "SELECT * FROM user_stocks WHERE user_id = @userId AND stock_id = @stockId";
            using (NpgsqlCommand cmd = new NpgsqlCommand(query, conn.Connection))
            {
                cmd.Parameters.AddWithValue("userId", userId);
                cmd.Parameters.AddWithValue("stockId", stockId);
                using (NpgsqlDataReader reader = cmd.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        Int64 userStockQuantity = (Int64)reader["quantity"];
                        if (userStockQuantity >= quantity)
                        {
                            return true;
                        }
                    }
                }
            }
            return false;
        }

        public async Task SellStock(int userId, int stockId, Int64 Quantity, Int64 Price)
        {
            if (!CheckSellable(userId, stockId, Quantity))
            {
                throw new Exception("Insufficient quantity to sell");
            }

            Int64 OriginalQuantity = Quantity;

            var transactions = transactionRepository.GetBuyStockTransactionsByUser(userId, stockId);
            Int64 totalInvestment = 0;
            foreach (var transaction in transactions)
            {
                Console.WriteLine("SAD" + transaction.Quantity);
                Int64 RemainingQuantity = transaction.Quantity - transaction.Sold;
                if (Quantity > 0)
                {
                    if (RemainingQuantity > Quantity)
                    {
                        Console.WriteLine($"1 Quantity: {Quantity} RemainingQty: {RemainingQuantity} TransactionId: {transaction.Id}");
                        string query = "UPDATE transactions SET sold = sold+@sold WHERE id = @id";
                        NpgsqlCommand updateTransactionCmd = new NpgsqlCommand(query, conn.Connection);
                        updateTransactionCmd.Parameters.AddWithValue("id", transaction.Id);
                        updateTransactionCmd.Parameters.AddWithValue("sold", Quantity);

                        totalInvestment += Quantity * transaction.Price;

                        await updateTransactionCmd.ExecuteNonQueryAsync();
                        Quantity = 0;
                        // break;
                    }
                    else
                    {
                        Console.WriteLine($"2 Quantity: {Quantity} RemainingQty: {RemainingQuantity} TransactionId: {transaction.Id}");

                        String query = "UPDATE transactions SET sold = sold+@sold WHERE id = @id";
                        NpgsqlCommand updateTransactionCmd = new NpgsqlCommand(query, conn.Connection);
                        updateTransactionCmd.Parameters.AddWithValue("id", transaction.Id);
                        updateTransactionCmd.Parameters.AddWithValue("sold", RemainingQuantity);

                        await updateTransactionCmd.ExecuteNonQueryAsync();

                        totalInvestment += transaction.Price * RemainingQuantity;
                        Quantity -= RemainingQuantity;
                    }
                }
                else
                {
                    break;
                }
            }
            var TotalProfit = OriginalQuantity * Price - totalInvestment;
            await transactionRepository.AddTransaction(new Model.Transaction
            {
                UserId = userId,
                StockId = stockId,
                Quantity = OriginalQuantity,
                Price = Price,
                Profit = TotalProfit,
                Type = TransactionType.Sell,
                TransactionDate = DateTime.Now
            });

            String updateQuery = "UPDATE user_stocks SET quantity = quantity - @quantity, investment = investment - @investment WHERE user_id = @userId AND stock_id = @stockId";
            using (NpgsqlCommand updateUserStockCmd = new NpgsqlCommand(updateQuery, conn.Connection))
            {
                updateUserStockCmd.Parameters.AddWithValue("quantity", OriginalQuantity);
                updateUserStockCmd.Parameters.AddWithValue("userId", userId);
                updateUserStockCmd.Parameters.AddWithValue("stockId", stockId);
                updateUserStockCmd.Parameters.AddWithValue("investment", totalInvestment);

                await updateUserStockCmd.ExecuteNonQueryAsync();
            }

        }

        public StockFolioState GetUserPortfolioStats(int userId)
        {
            List<UserStock> userStocks = GetStocksByUser(userId);
            var totalInvestment = (double) userStocks.Sum(userStock => userStock.Investment) / 100;
            var totalQuantity = (int) userStocks.Sum(userStock => userStock.Quantity);

            var stocks = GetStocks();
            Dictionary<int, Stock> stockMap = stocks.ToDictionary(stock => stock.Id);

            var netWorth = (double) userStocks.Sum(userStock => userStock.Quantity * stockMap[userStock.StockId].Ltp) / 100;
            var profit = (double) netWorth - totalInvestment;

            var transactions = GetTransactionsByUser(userId);

            foreach (Transaction transaction in transactions)
            {
                if (stockMap.ContainsKey(transaction.StockId))
                {
                    transaction.Stock = stockMap[transaction.StockId];
                }
            }

            List<UserStocksDataModel> userStocksData = new List<UserStocksDataModel>();
            
            foreach (UserStock userStock in userStocks)
            {

                userStocksData.Add(new UserStocksDataModel
                {
                    Id = userStock.Id,
                     StockSymbol = stockMap[userStock.StockId].Symbol,
                       StockId = userStock.StockId,
                        Quantity = userStock.Quantity,
                         Investment  = (double) userStock.Investment / 100,
                    Ltp = (double)stockMap[userStock.StockId].Ltp / 100,
                });
            }



            return new StockFolioState
            {
                TotalInvestment = totalInvestment,
                TotalQuantity = totalQuantity,
                NetWorth = netWorth,
                TotalProfit = profit,
                UserStocks = userStocksData,
                Stocks = stocks
            };
        }

        public void idk()
        {
            /*


            var transactions = GetTransactionsByUser(userId);

            foreach (Transaction transaction in transactions)
            {
                if (stockMap.ContainsKey(transaction.StockId))
                {
                    transaction.Stock = stockMap[transaction.StockId];
                }
            }

            var groupedTransactions = transactions.GroupBy(t => t.StockId);
            var stockProfitLossList = new List<StockProfitLoss>();

            foreach (var group in groupedTransactions)
            {
                var stockId = group.Key;
                var stockTransactions = group.ToList();

                var totalQuantityBought = stockTransactions
                    .Where(t => t.Type == TransactionType.Buy)
                    .Sum(t => t.Quantity);

                var totalQuantitySold = stockTransactions
                    .Where(t => t.Type == TransactionType.Sell)
                    .Sum(t => t.Quantity);

                var RemainingQuantity = totalQuantityBought - totalQuantitySold;

                // Calculate total buy and sell amounts for the current stock
                var totalBuyAmount = stockTransactions
                    .Where(t => t.Type == TransactionType.Buy)
                    .Sum(t => t.Quantity * t.Price);

                var totalSellAmount = stockTransactions
                    .Where(t => t.Type == TransactionType.Sell)
                    .Sum(t => t.Quantity * t.Price);

                // Calculate profit/loss
                var profitLoss = (totalSellAmount - totalBuyAmount) / 100;
                decimal currentInvestment = (totalBuyAmount - totalSellAmount) / 100;

                var NetWorth = (RemainingQuantity * stockMap[stockId].Ltp) / 100;
                var stock = stockMap[stockId];
                //MessageBox.Show($"{stock.Symbol}: Quantity: {RemainingQuantity} LTP: {stock.Ltp/100} Current Investment: {currentInvestment} NetWorth: {NetWorth}, ProfitLostt: {profitLoss}");
                // Retrieve the stock object

                // Add stock and its corresponding profit/loss to the list
                stockProfitLossList.Add(new StockProfitLoss
                {
                    Stock = stock,
                    ProfitLoss = profitLoss
                });
            }

            return stockProfitLossList;
            */
        }
    }

    public class StockFolioState
    {
        public double TotalInvestment;
        public double NetWorth;
        public int TotalQuantity;
        public double TotalProfit;
        public List<UserStocksDataModel> UserStocks;
        public double TotalProfitPercent { get => ((NetWorth - TotalInvestment) / TotalInvestment) * 100; }
        public List<Stock> Stocks;
    }

    public class UserStocksDataModel
    {
        public Int64 Id { get; set; }
        public String StockSymbol { get; set; }
        public int StockId { get; set; }
        public Int64 Quantity { get; set; }
        public double Investment { get; set; }
        public double Ltp { get; set; }
        public double NetWorth { get => Quantity * Ltp; }
        public double Profit { get => NetWorth - Investment; }
        public String ProfitPercent { get => (((NetWorth - Investment) / Investment) * 100).ToString("0.00")+"%"; }
    }

    public class StockProfitLoss
    {
        public Stock Stock { get; set; }
        public long ProfitLoss { get; set; }
    }
}
