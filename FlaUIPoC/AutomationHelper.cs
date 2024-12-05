using FlaUI.Core;
using FlaUI.Core.AutomationElements;
using FlaUI.Core.Conditions;
using FlaUI.UIA3;

public static class AutomationHelper
{
    public static Window GetMainWindow(Application app, UIA3Automation automation)
    {
        return app.GetMainWindow(automation);
    }

    public enum SearchType
    {
        ByName,
        ById,
        ByClassName,
        ByText
    }

    private static AutomationElement FindElement(Window window, string searchValue, SearchType searchType)
    {
        var conditionFactory = new ConditionFactory(new UIA3PropertyLibrary());

        return searchType switch
        {
            SearchType.ByName => window.FindFirstDescendant(cf => cf.ByName(searchValue)),
            SearchType.ById => window.FindFirstDescendant(cf => cf.ByAutomationId(searchValue)),
            SearchType.ByClassName => window.FindFirstDescendant(cf => cf.ByClassName(searchValue)),
            SearchType.ByText => window.FindFirstDescendant(cf => cf.ByText(searchValue)),
            _ => throw new ArgumentOutOfRangeException(nameof(searchType), searchType, null)
        };
    }

    public static void ClickButton(Window window, string searchValue, SearchType searchType)
    {
        var button = FindElement(window, searchValue, searchType)?.AsButton();
        button?.Invoke();
    }

    public static void EnterText(Window window, string searchValue, SearchType searchType, string text)
    {
        var textBox = FindElement(window, searchValue, searchType)?.AsTextBox();
        if (textBox != null)
        {
            textBox.Text = text;
        }
    }

    public static string GetText(Window window, string searchValue, SearchType searchType)
    {
        var textBox = FindElement(window, searchValue, searchType)?.AsTextBox();
        return textBox?.Text;
    }

    public static void SelectComboBoxItem(Window window, string searchValue, SearchType searchType, string itemText)
    {
        var comboBox = FindElement(window, searchValue, searchType)?.AsComboBox();
        if (comboBox != null)
        {
            comboBox.Select(itemText);
        }
    }

    public static void SetCheckboxState(Window window, string searchValue, SearchType searchType, bool isChecked)
    {
        var checkBox = FindElement(window, searchValue, searchType)?.AsCheckBox();
        if (checkBox != null)
        {
            checkBox.IsChecked = isChecked;
        }
    }
}
