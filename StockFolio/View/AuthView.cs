using StockFolio.Model;
using StockFolio.Presenter;
using StockFolio.Services;

namespace StockFolio.View
{
    public partial class AuthView : Form, IAuthView
    {
        public string LoginEmail
        {
            get => this.txtLoginEmail.Text; set => this.txtLoginEmail.Text = value;
        }
        public string LoginPassword
        {
            get => this.txtLoginPassword.Text; set => this.txtLoginPassword.Text = value;
        }
        public string RegisterUsername
        {
            get => this.txtRegisterUsername.Text; set => this.txtRegisterUsername.Text = value;
        }
        public string RegisterEmail
        {
            get => this.txtRegisterEmail.Text; set => this.txtRegisterEmail.Text = value;
        }
        public string RegisterPassword
        {
            get => this.txtRegisterPassword.Text; set => this.txtRegisterPassword.Text = value;
        }
        public TabControl TabControl { get => this.tabControl; }
        public AuthPresenter Presenter { get; set; }
        public AuthView()
        {
            InitializeComponent();
            this.Presenter = new AuthPresenter(this, new AuthService(new DbConnection(), new BCryptHashService()));
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void btnRegister_Click(object sender, EventArgs e)
        {
            Presenter.Register();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            Presenter.Login();
        }

        public void HideView() => this.Hide();

        private void txtLoginPassword_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                e.Handled = true;
                Presenter.Login();
            }
        }

        private void txtRegisterPassword_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                e.Handled = true;
                Presenter.Register();
            }
        }
    }
}
