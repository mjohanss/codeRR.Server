using codeRR.Server.Web.Tests.Selenium.LiveServer.Fixtures;
using codeRR.Server.Web.Tests.Selenium.LiveServer.Pages;
using Xunit;

namespace codeRR.Server.Web.Tests.Selenium.LiveServer.Tests
{
    [Collection("LiveServerCollection")]
    [Trait("Category", "Integration")]
    public class RegisterPageTests : LiveServerTestBase
    {
        public RegisterPageTests(LiveServerFixture fixture) : base(fixture)
        {
        }

        [Fact]
        public void Should_not_be_able_to_register_with_empty_email()
        {
            UITest(() =>
            {
                var sut = new RegisterPage(Fixture)
                    .RegisterWithNoEMailSpecified();

                sut.VerifyRequireEMail();
            });
        }

        [Fact]
        public void Should_not_be_able_to_register_with_empty_password()
        {
            UITest(() =>
            {
                var sut = new RegisterPage(Fixture)
                    .RegisterWithNoPasswordSpecified();

                sut.VerifyRequirePassword();
            });
        }

        [Fact]
        public void Should_not_be_able_to_register_with_passwords_not_matching()
        {
            UITest(() =>
            {
                var sut = new RegisterPage(Fixture)
                    .RegisterWithPasswordsNotMatching();

                sut.VerifyPasswordsNotMatchingPasswords();
            });
        }

        [Fact]
        public void Should_not_be_able_to_create_user_that_already_exists()
        {
            UITest(() =>
            {
                var sut = new RegisterPage(Fixture)
                    .RegisterUserThatAlreadyExists();

                sut.VerifyRegisterUserThatAlreadyExists();
            });
        }

        [Fact]
        public void Should_be_able_to_create_user()
        {
            UITest(() =>
            {
                var sut = new RegisterPage(Fixture)
                    .RegisterUser();

                sut.VerifyPageLoaded();
            });
        }
    }
}
