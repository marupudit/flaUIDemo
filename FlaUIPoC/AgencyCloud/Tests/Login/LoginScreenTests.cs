using FlaUIPoC.AgencyCloud.Pages.Login;


namespace FlaUIPoC.AgencyCloud.Tests.Login
{
    internal class LoginScreenTests : BaseSetup
    {
        private LoginScreenWindow _loginScreenPage;

        [Test]
        public void CheckTheLoginFunctionalityWithValidCredentails()
        {
            var loginPage = MainWindow.LoginScreen;
            loginPage.EnterLoginCredentials("ATT","password");
        }

        [Test]
        public void CheckTheLoginFunctionalityWithInValidCredentails()
        {
            var loginPage = MainWindow.LoginScreen;
            loginPage.EnterLoginCredentials("ATT", "wrong");
        }
    }
}
