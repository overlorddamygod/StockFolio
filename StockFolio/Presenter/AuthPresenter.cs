using StockFolio.Model;
using StockFolio.Services;
using StockFolio.View;
using System.ComponentModel.DataAnnotations;

namespace StockFolio.Presenter
{
    public class AuthPresenter
    {
        IAuthView view;
        AuthService authService;
        public AuthPresenter(IAuthView view, AuthService authService) {
            this.view = view;
            this.authService = authService;
        }
        public void Register()
        {
            String username = view.RegisterUsername;
            String email = view.RegisterEmail;
            String password = view.RegisterPassword;

            try
            {
                authService.Register(username, email, password);
                MessageBox.Show("Account created successfully. Please log in.");
                view.TabControl.SelectedIndex = 0;
                view.LoginEmail = email;
                view.RegisterUsername = "";
                view.RegisterEmail = "";
                view.RegisterPassword = "";
            }
            catch(ValidationException ex)
            {
                MessageBox.Show(ex.Message, "Validation error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error occured", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public void Login()
        {
            String email = view.LoginEmail;
            String password = view.LoginPassword;

            try
            {
                User u = authService.Login(email, password);
                AuthService.SetLoggedInUser(u);

                MainView mainForm = new MainView();

                mainForm.Show();
                view.HideView();
            }
            catch (ValidationException ex)
            {
                MessageBox.Show(ex.Message, "Validation error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error occured", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
