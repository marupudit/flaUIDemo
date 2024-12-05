using FlaUI.Core;
using FlaUI.Core.AutomationElements;
using FlaUI.UIA3;
using System.Diagnostics;

public class BaseSetup
{
    public  Window Window { get; set; }
    public static Application App { get; set; }
    public static UIA3Automation Automation { get; set; }

    [SetUp]
    public void Setup()
    {
        Automation = new UIA3Automation();
        var si = new ProcessStartInfo();
        si.LoadUserProfile = false;
        si.UseShellExecute = false;
        si.FileName = @"C:\Program Files\QGIS 3.16\bin\qgis-ltr-bin-g7.exe";
        App = Application.AttachOrLaunch(si);
        Console.WriteLine($"Launched application with process ID: {App.ProcessId}");
        WaitForApplicationLaunch();
        Window = App.GetMainWindow(Automation, TimeSpan.FromSeconds(300));
        WaitForApplicationLaunch();
    }

    private static void WaitForApplicationLaunch()
    {
        int windowCount = 0;
        int count = 0;
        do
        {
            try
            {
                windowCount = App.GetAllTopLevelWindows(Automation).Length;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error while accessing the application :" + ex);
            }

            Thread.Sleep(1000);
            count++;
        }
        while (windowCount < 1 && count < 150);
    }

    [TearDown]
    public void TearDown()
    {
        Automation.Dispose();
        App.Close();
    }
}
