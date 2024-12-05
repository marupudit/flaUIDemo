
public class MainPageTests : BaseSetup
{
    private MainPage _mainPage;

    [SetUp]
    public void TestSetup()
    {
        _mainPage = new MainPage(App, Automation);
    }

    [Test]
    public void TestStartButton()
    {
        _mainPage.ClickStartButton();
        // Add assertions to verify the expected behavior
    }
}