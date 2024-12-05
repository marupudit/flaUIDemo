using FlaUIPoC.AgencyCloud.Pages.Login;


namespace FlaUIPoC.AgencyCloud.Tests.Login
{
    internal class LoginScreenTests : BaseSetup
    {
        private LoginScreenPage _loginScreenPage;
        private MainPage _mainPage;

        [SetUp]
        public void TestSetup()
        {
            _loginScreenPage = new LoginScreenPage(App, Automation);
            _mainPage = new MainPage(App, Automation);
        }

        [Test]
        public void CheckTheLoginFunctionality()
        {
            _loginScreenPage.EnterLoginCredentails();
        }

        [Test]
        public void CheckTheHomepageScreen()
        {
            _loginScreenPage.EnterLoginCredentails();
            _mainPage.ClickStartButton();

        }
    }
}
