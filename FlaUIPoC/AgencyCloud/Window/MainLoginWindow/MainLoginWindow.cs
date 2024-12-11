using FlaUI.Core.Input;
using FlaUIPoC.AgencyCloud.Pages.Login;
using FlaUIPoC.Base;

namespace FlaUIPoC.AgencyCloud.Window.MainLoginWindow
{
    public class MainLoginWindow: WindowAdaptor
    {

        public LoginScreenWindow LoginScreen
        {
            get { return _LoginScreen ??= new LoginScreenWindow(Window);}
        }

        LoginScreenWindow _LoginScreen;
        ApplicationLaunchSetUp _Application;

        public MainLoginWindow(ApplicationLaunchSetUp app): base(app, "reapit")
        {
            Wait.UntilResponsive(Window);
            _Application = app;
            Window.Focus();
            Wait.UntilResponsive(Window);
        }
    }
}
