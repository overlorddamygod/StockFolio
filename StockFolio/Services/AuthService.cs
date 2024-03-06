using System.ComponentModel.DataAnnotations;
using System.Net.Mail;
using StockFolio.Model;

namespace StockFolio.Services
{
    public class AuthService
    {
        IUserService userService;
        IHashService hashService;
        public static User? LoggedInUser;
        public AuthService(DbConnection conn, IHashService hashService)
        {
            userService = new UserService(conn);
            this.hashService = hashService;
        }

        public AuthService(IUserService userService, IHashService hashService)
        {
            this.userService = userService;
            this.hashService = hashService;
        }
        public void Register(string username, string email, string password)
        {
            ValidateUsername(username);
            ValidateEmail(email);
            ValidatePassword(password);

            User? user = userService.GetUserWithEmail(email);

            if (user != null)
            {
                throw new Exception("User with email already exists");
            }

            string hashedPassword = hashService.HashPassword(password);

            userService.AddUser(new User
            {
                Username = username,
                Email = email,
                Password = hashedPassword
            });
        }
        public User Login(string email, string password)
        {
            ValidateEmail(email);
            ValidatePassword(password);
            User? user = userService.GetUserWithEmail(email);

            if (user == null)
            {
                throw new Exception("User with email doesn't exist");
            }

            if (!hashService.VerifyPassword(password, user.Password))
            {
                throw new Exception("Password Mismatch");
            }

            return user;
        }

        public static void SetLoggedInUser(User user)
        {
            LoggedInUser = user;
        }

        public static User? Logout()
        {
            LoggedInUser = null;
            return LoggedInUser;
        }

        public void ValidateUsername(string username)
        {
            if (string.IsNullOrEmpty(username))
            {
                throw new ValidationException("Username Required");
            }

            if (username.Length < 6)
            {
                throw new ValidationException("Username should be at least 6 characters");
            }
        }

        public void ValidateEmail(string email)
        {
            if (string.IsNullOrEmpty(email))
            {
                throw new ValidationException("Email Required");
            }

            try
            {
                var emailAddress = new MailAddress(email);
            }
            catch
            {
                throw new ValidationException("Invalid Email Format");
            }
        }

        public void ValidatePassword(string password)
        {
            if (string.IsNullOrEmpty(password))
            {
                throw new ValidationException("Password Required");
            }

            if (password.Length < 6)
            {
                throw new ValidationException("Password should be at least 6 characters");
            }
        }
    }
}
