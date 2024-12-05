using FlaUI.Core;
using FlaUI.Core.AutomationElements;
using FlaUI.UIA3;
using static AutomationHelper;

public class MainPage
{
    private readonly Window _window;

    public MainPage(Application App, UIA3Automation Automation)
    {
        _window = AutomationHelper.GetMainWindow(App, Automation);
    }

    public void ClickStartButton()
    {
        AutomationHelper.ClickButton(_window, IdentifyElement.byId, "Eight");
    }
}