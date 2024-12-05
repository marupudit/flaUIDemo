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

    public static class IdentifyElement
    {
        public const SearchType defaultSearchType = SearchType.ById;
        public const SearchType byName = SearchType.ByName;
        public const SearchType byId = SearchType.ById;
        public const SearchType byClassName = SearchType.ByClassName;
        public const SearchType byText = SearchType.ByText;
    }

    private static AutomationElement FindElement(Window window, SearchType searchType, string searchValue)
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

    public static void ClickButton(Window window, SearchType searchType, string searchValue)
    {
        var button = FindElement(window, searchType, searchValue)?.AsButton();
        button?.Invoke();
    }

    public static void EnterText(Window windowName, SearchType elementIdType, string elementIdValue, string textToEnter)
    {
        var textBox = FindElement(windowName, elementIdType, elementIdValue)?.AsTextBox();
        if (textBox != null)
        {
            textBox.Text = textToEnter;
        }
    }

    public static string GetText(Window window, SearchType searchType, string searchValue)
    {
        var textBox = FindElement(window, searchType, searchValue)?.AsTextBox();
        return textBox?.Text;
    }

    public static void SelectComboBoxItem(Window window, SearchType searchType, string searchValue, string itemText)
    {
        var comboBox = FindElement(window, searchType, searchValue)?.AsComboBox();
        if (comboBox != null)
        {
            comboBox.Select(itemText);
        }
    }

    public static void SetCheckboxState(Window window, SearchType searchType, string searchValue, bool isChecked)
    {
        var checkBox = FindElement(window, searchType, searchValue)?.AsCheckBox();
        if (checkBox != null)
        {
            checkBox.IsChecked = isChecked;
        }
    }
}
