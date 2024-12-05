using FlaUI.Core;
using FlaUI.Core.AutomationElements;
using FlaUI.UIA3;

public class MainPage
{
    private readonly Window _window;

    public MainPage(Application App, UIA3Automation Automation)
    {
        _window = AutomationHelper.GetMainWindow(App, Automation);
    }

    public void ClickStartButton()
    {
        AutomationHelper.ClickButton(_window, "Eight", AutomationHelper.SearchType.ById);
    }
}