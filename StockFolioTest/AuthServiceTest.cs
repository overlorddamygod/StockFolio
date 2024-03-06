using StockFolio.Model;
using StockFolio.Services;
using System.ComponentModel.DataAnnotations;
using Telerik.JustMock;

namespace StockFolioTest
{
    public class AuthServiceTest
    {
        private readonly AuthService authService;

        public AuthServiceTest()
        {
            IUserService mockUserService = Mock.Create<IUserService>();
            User u = new User
            {
                Id = 1,
                Username = "testuser1",
                Email = "testuser1@test.com",
                Password = "testuser1pass"
            };
            Mock.Arrange(() => mockUserService.GetUserWithEmail(Arg.IsAny<string>())).Returns((String email) => email == u.Email ? u : null);
            
            IHashService mockHashService = Mock.Create<IHashService>();
            Mock.Arrange(() => mockHashService.HashPassword(Arg.IsAny<string>())).Returns((String password) => password);
            Mock.Arrange(() => mockHashService.VerifyPassword(Arg.IsAny<string>(), Arg.IsAny<string>())).Returns((String text, String hash) => text==hash);

            authService = new AuthService(mockUserService, mockHashService);
        }

        [Fact]
        public void Username_Should_Be_valid()
        {
            string validUsername = "TestUser123";

            Assert.Null(Record.Exception(() => authService.ValidateUsername(validUsername)));
        }

        [Theory]
        [InlineData(null)]
        [InlineData("")]
        [InlineData("  ")]
        public void NullOrEmpty_Username_Should_Throw_ValidationException(string invalidUsername)
        {
            Assert.Throws<ValidationException>(() => authService.ValidateUsername(invalidUsername));
        }

        [Theory]
        [InlineData("shyam")]
        [InlineData("ram")]
        [InlineData("hari")]
        public void Username_With_Length_Less_Than_6_Should_Be_Invalid(string invalidUsername)
        {
            Assert.Throws<ValidationException>(() => authService.ValidateUsername(invalidUsername));
        }

        [Fact]
        public void Email_Should_Be_Valid()
        {
            string validEmail = "test@example.com";

            Assert.Null(Record.Exception(() => authService.ValidateEmail(validEmail)));
        }

        [Theory]
        [InlineData("shyam")]
        [InlineData("ram@")]
        [InlineData("@")]
        public void Email_Should_Not_Be_Invalid(string invalidEmail)
        {
            Assert.Throws<ValidationException>(() => authService.ValidateEmail(invalidEmail));
        }

        [Fact]
        public void Password_Should_Be_Valid()
        {
            string validPassword = "password123";

            Assert.Null(Record.Exception(() => authService.ValidatePassword(validPassword)));
        }

        [Theory]
        [InlineData(null)]
        [InlineData("")]
        [InlineData("  ")]
        public void NullOrEmpty_Password_Should_Throw_ValidationException(string invalidPassword)
        {
            Assert.Throws<ValidationException>(() => authService.ValidatePassword(invalidPassword));
        }

        [Theory]
        [InlineData("pa")]
        [InlineData("passw")]
        [InlineData("abcd")]
        public void Password_With_Length_Less_Than_6_Should_Throw_ValidationException(string invalidPassword)
        {
            Assert.Throws<ValidationException>(() => authService.ValidatePassword(invalidPassword));
        }

        [Fact]
        public void Should_Register_User()
        {
            Assert.Null(Record.Exception(()=>authService.Register("testuser2", "testuser2@test.com", "testuser2pass")));
        }

        [Fact]
        public void Should_Login_User()
        {
            String email = "testuser1@test.com";
            String password = "testuser1pass";
            User loggedInUser = authService.Login(email, password);

            Assert.True(loggedInUser != null);
            Assert.Equal(email, loggedInUser.Email);
        }

        [Fact]
        public void Should_Not_Login_User()
        {
            Assert.Throws<Exception>(() => authService.Login("testuser2@test.com", "testuser2pass"));
        }
    }
}