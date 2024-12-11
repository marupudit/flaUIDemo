using FlaUI.Core.Input;
using FlaUIPoC.AgencyCloud.Window.MainLoginWindow;
using FlaUIPoC.Base;

public class BaseSetup
{
    public ApplicationLaunchSetUp App { get; private set; }

    public MainLoginWindow MainWindow { get; private set; }

    [SetUp]
    public void Setup()
    {
        App = new ApplicationLaunchSetUp();
        App.Init();

        // Create main login window
        MainWindow = new MainLoginWindow(App);
        Wait.UntilResponsive(MainWindow.Window);
    }

    [TearDown]
    public void TearDown()
    {
        App?.Cleanup();
    }
}
