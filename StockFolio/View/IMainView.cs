using StockFolio.Presenter;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockFolio.View
{
    public interface IMainView
    {
        MainPresenter Presenter { get; set; }
        public String TotalInvestment { get; set; }
        public String NetWorth { get; set; }
        public String TotalQuantity { get; set; }
        public String TotalProfit { get; set; }
        public Label LblTotalProfit { get; }
        public int BuyQuantity { get; set; }
        public String BuyPrice { get; set; }
        public ComboBox CBBuyStocks { get; }
        public int SellQuantity { get; set; }
        public String SellPrice { get; set; }
        public ComboBox CBSellStocks { get; }

        public DataGridView DataGridUserStocks { get; }
        public DataGridView DataGridViewStocksList { get; }
    }
}
