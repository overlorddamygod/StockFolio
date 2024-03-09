using StockFolio.Presenter;
using StockFolio.Services;

namespace StockFolio.View
{
    public partial class MainView : Form, IMainView
    {
        public MainPresenter Presenter { get; set; }
        public String TotalInvestment { get => lblTotalInvestment.Text; set => lblTotalInvestment.Text = value; }
        public String NetWorth { get => lblNetWorth.Text; set => lblNetWorth.Text = value; }
        public String TotalQuantity { get => lblTotalQuantity.Text; set => lblTotalQuantity.Text = value; }
        public String TotalProfit { get => lblTotalProfit.Text; set => lblTotalProfit.Text = value; }
        public DataGridView DataGridUserStocks { get => this.dataGridUserStocks; }
        public DataGridView DataGridViewStocksList { get => this.dataGridViewStocksList; }
        public Label LblTotalProfit { get => this.lblTotalProfit; }
        public int BuyQuantity { get => (int)nUDQuantity.Value; set => nUDQuantity.Value = value; }
        public string BuyPrice { get => tbBuyPrice.Text; set => tbBuyPrice.Text = value; }
        public ComboBox CBBuyStocks => cbStock;

        public int SellQuantity { get => (int)nUDSellQuantity.Value; set => nUDSellQuantity.Value = value; }
        public string SellPrice { get => tbSellPrice.Text; set => tbSellPrice.Text = value; }

        public ComboBox CBSellStocks => cbSellStock;

        public MainView()
        {
            InitializeComponent();
            DbConnection conn = new DbConnection();
            this.Presenter = new MainPresenter(this, new AuthService(conn, new BCryptHashService()), new PortfolioService(conn));
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            lblGreeting.Text = $"Hi {AuthService.LoggedInUser!.Username},";

            Presenter.PopulateUI();
        }

        private void lblGreeting_Click(object sender, EventArgs e)
        {
        }

        private void btnLogout_Click(object sender, EventArgs e)
        {
            AuthService.Logout();
            this.Hide();
            var authView = new AuthView();
            authView.Show();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void lblTotalUnits_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void btnBuy_Click(object sender, EventArgs e)
        {
            Presenter.BuyStock();
        }

        private void btnSell_Click(object sender, EventArgs e)
        {
            Presenter.SellStock();
        }

        private void tabPortfolio_Click(object sender, EventArgs e)
        {

        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            Presenter.PopulateUI();
        }
    }
}
