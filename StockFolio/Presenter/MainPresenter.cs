using StockFolio.Model;
using StockFolio.Services;
using StockFolio.View;
using System.ComponentModel.DataAnnotations;

namespace StockFolio.Presenter
{
    public class MainPresenter
    {
        IMainView view;
        AuthService authService;
        PortfolioService portfolioService;
        public MainPresenter(IMainView view, AuthService authService, PortfolioService portfolioService) {
            this.view = view;
            this.authService = authService;
            this.portfolioService = portfolioService;
        }

        public void PopulateUI()
        {
            if (AuthService.LoggedInUser == null)
            {
                MessageBox.Show("Not logged in");
                return;
            }

            var state = portfolioService.GetUserPortfolioStats(AuthService.LoggedInUser.Id);

            if (state != null)
            {
                view.TotalInvestment = state.TotalInvestment.ToString();
                view.NetWorth = state.NetWorth.ToString();
                view.LblTotalProfit.ForeColor = state.TotalProfit > 0 ? Color.Green : Color.Red;
                view.TotalProfit = $"Rs. {state.TotalProfit.ToString("0.00")} ({state.TotalProfitPercent.ToString("0.00")}%)";
                view.TotalQuantity = state.TotalQuantity.ToString();
                view.DataGridUserStocks.DataSource = state.UserStocks;

                view.CBBuyStocks.DataSource = state.Stocks;
                view.CBBuyStocks.DisplayMember = "Symbol";
                view.CBBuyStocks.ValueMember = "Id";

                

                view.CBBuyStocks.SelectedIndexChanged += delegate
                {
                    if (view.CBBuyStocks.SelectedIndex < 0 )
                    {
                        return;
                    } 
                    Stock s = view.CBBuyStocks.Items[view.CBBuyStocks.SelectedIndex] as Stock;

                    view.BuyPrice = ((double)s.Ltp / 100).ToString();
                };
                if (state.Stocks.Count > 0)
                {
                    Stock s = view.CBBuyStocks.Items[view.CBBuyStocks.SelectedIndex] as Stock;

                    view.BuyPrice = ((double)s.Ltp / 100).ToString();

                }
                view.CBSellStocks.DataSource = state.UserStocks;
                view.CBSellStocks.DisplayMember = "StockSymbol";
                view.CBSellStocks.ValueMember = "StockId";


                view.CBSellStocks.SelectedIndexChanged += delegate
                {
                    if (view.CBSellStocks.SelectedIndex < 0)
                    {
                        return;
                    }
                    UserStocksDataModel s = view.CBSellStocks.Items[view.CBSellStocks.SelectedIndex] as UserStocksDataModel;

                    view.SellPrice = s.Ltp.ToString();
                };
                if (state.UserStocks.Count > 0)
                {
                    UserStocksDataModel s = view.CBSellStocks.Items[view.CBSellStocks.SelectedIndex] as UserStocksDataModel;

                    if (s != null)
                    {
                        view.SellPrice = s.Ltp.ToString();
                    }
                }

            }

            var dt = portfolioService.GetStocksDataTable();
            view.DataGridViewStocksList.DataSource = dt;
        }

        public async Task BuyStock()
        {
            if (AuthService.LoggedInUser == null)
            {
                MessageBox.Show("Not logged in");
                return;
            }

            try
            {
                if (view.BuyQuantity <= 0)
                {
                    throw new ValidationException("Buy Quantity must be greater than 0") ;
                }

                if (view.CBBuyStocks.SelectedIndex < 0)
                {
                    throw new ValidationException("Select the Stock to buy");

                }
                Stock s = view.CBBuyStocks.Items[view.CBBuyStocks.SelectedIndex] as Stock;
                
                int stockId = s.Id;
                double price = Double.Parse(view.BuyPrice);
                int priceInPaisa = 0;
                if (view.BuyPrice.Contains("."))
                {
                    var decimalRightLength = view.BuyPrice.Split('.')[1].Length;
                    if (decimalRightLength > 0 && decimalRightLength > 2)
                    {
                        throw new Exception("Buy Price: Only 1 or 2 digit after decimal");
                    }

                    if (price <= 0)
                    {
                        throw new ValidationException("Buy Price must be greater than 0");
                    }
                }
                priceInPaisa = (int)(price * 100);

                await this.portfolioService.BuyStock(AuthService.LoggedInUser.Id, stockId,view.BuyQuantity, priceInPaisa);
                PopulateUI();
                MessageBox.Show($"Successfully bought {view.BuyQuantity} units of  {s.Symbol} @ Rs.{price.ToString("0.00")}");
            } catch (Exception ex)
            {
                MessageBox.Show(ex.StackTrace);
                MessageBox.Show(ex.Message);
            }
        }
        public async Task SellStock()
        {
            if (AuthService.LoggedInUser == null)
            {
                MessageBox.Show("Not logged in");
                return;
            }

            try
            {
                if (view.SellQuantity <= 0)
                {
                    throw new ValidationException("Sell Quantity must be greater than 0");
                }

                if (view.CBSellStocks.SelectedIndex < 0)
                {
                    throw new ValidationException("Select the Stock to buy");
                }
                UserStocksDataModel s = view.CBSellStocks.Items[view.CBSellStocks.SelectedIndex] as UserStocksDataModel;

                int stockId = s.StockId;
                double price = Double.Parse(view.SellPrice);
                int priceInPaisa = 0;
                if (view.BuyPrice.Contains("."))
                {
                    var decimalRightLength = view.SellPrice.Split('.')[1].Length;
                    if (decimalRightLength > 0 && decimalRightLength > 2)
                    {
                        throw new Exception("Buy Price: Only 1 or 2 digit after decimal");
                    }

                    priceInPaisa = (int)(price * 100);
                    if (price <= 0)
                    {
                        throw new ValidationException("Buy Price must be greater than 0");
                    }
                }

                await this.portfolioService.SellStock(AuthService.LoggedInUser.Id, stockId, view.SellQuantity, priceInPaisa);
                PopulateUI();
                MessageBox.Show($"Successfully sold {view.SellQuantity} units of  {s.StockSymbol} @ Rs.{price.ToString("0.00")}");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }


    }
}
