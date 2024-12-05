using FlaUI.Core;
using FlaUI.Core.AutomationElements;
using FlaUI.UIA3;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static AutomationHelper;

namespace FlaUIPoC.AgencyCloud.Pages.Login
{
    public class LoginScreenPage
    {
        private readonly Window _window;

        public LoginScreenPage(Application App, UIA3Automation Automation)
        {
            _window = AutomationHelper.GetMainWindow(App, Automation);
        }

        // Reusable Actions
        public void EnterLoginCredentails()
        {
            AutomationHelper.EnterText(_window, IdentifyElement.byName, "txt_login", "ATT");
            AutomationHelper.EnterText(_window, IdentifyElement.byName, "txt_password", "password");
            AutomationHelper.ClickButton(_window, IdentifyElement.byName, "login");
        }

        public void ClickStartButton()
        {
            AutomationHelper.ClickButton(_window, IdentifyElement.byId, "Eight");
        }
    }
}
