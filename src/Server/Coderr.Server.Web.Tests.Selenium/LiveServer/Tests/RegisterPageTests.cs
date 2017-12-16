using codeRR.Server.Web.Tests.Selenium.LiveServer.Fixtures;
using codeRR.Server.Web.Tests.Selenium.LiveServer.Pages;
using Xunit;

namespace codeRR.Server.Web.Tests.Selenium.LiveServer.Tests
{
    [Collection("LiveServerCollection")]
    [Trait("Category", "Integration")]
    public class RegisterPageTests : TestBase
    {
        private readonly LiveServerFixture _fixture;

        public RegisterPageTests(LiveServerFixture fixture) : base(fixture.WebDriver)
        {
            _fixture = fixture;
        }

        [Fact]
        public void Should_not_be_able_to_register_with_empty_email()
        {
            UITest(() =>
            {
                var sut = new RegisterPage(_fixture.WebDriver, _fixture.UserName, _fixture.Password)
                    .RegisterWithNoEMailSpecified();

                sut.VerifyRequireEMail();
            });
        }

        [Fact]
        public void Should_not_be_able_to_register_with_empty_password()
        {
            UITest(() =>
            {
                var sut = new RegisterPage(_fixture.WebDriver, _fixture.UserName, _fixture.Password)
                    .RegisterWithNoPasswordSpecified();

                sut.VerifyRequirePassword();
            });
        }

        [Fact]
        public void Should_not_be_able_to_register_with_passwords_not_matching()
        {
            UITest(() =>
            {
                var sut = new RegisterPage(_fixture.WebDriver, _fixture.UserName, _fixture.Password)
                    .RegisterWithPasswordsNotMatching();

                sut.VerifyPasswordsNotMatchingPasswords();
            });
        }

        [Fact]
        public void Should_not_be_able_to_create_user_that_already_exists()
        {
            UITest(() =>
            {
                var sut = new RegisterPage(_fixture.WebDriver, _fixture.UserName, _fixture.Password)
                    .RegisterUserThatAlreadyExists();

                sut.VerifyRegisterUserThatAlreadyExists();
            });
        }

        [Fact]
        public void Should_be_able_to_create_user()
        {
            UITest(() =>
            {
                var sut = new RegisterPage(_fixture.WebDriver, _fixture.UserName, _fixture.Password)
                    .RegisterUser();

                sut.VerifyRegisterUser();
            });
        }
    }
}
