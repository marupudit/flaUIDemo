using FlaUI.Core.AutomationElements;
using FlaUI.Core.Input;
using static AutomationHelper;

namespace FlaUIPoC.AgencyCloud.Pages.Login
{
    public class LoginScreenWindow
    {
        private readonly FlaUI.Core.AutomationElements.Window _window;
        private readonly AutomationElement _loginWindow;

        public LoginScreenWindow(FlaUI.Core.AutomationElements.Window window)
        {
            Wait.UntilResponsive(window);
            _window = window;
            _loginWindow = window.FindFirstDescendant(cf => cf.ByClassName("LoginScreen"));
            Assume.That(_loginWindow, Is.Not.Null);

        }

        public void EnterLoginCredentials(string userName, string password)
        {
            AutomationHelper.EnterText(_window, IdentifyElement.byName, "txt_login", "ATT");
            AutomationHelper.EnterText(_window, IdentifyElement.byName, "txt_password", "password");
            AutomationHelper.ClickButton(_window, IdentifyElement.byName, "login");
        }
    }
}