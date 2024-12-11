using FlaUI.Core;
using FlaUI.Core.AutomationElements;
using FlaUI.UIA3;
using System.Diagnostics;

namespace FlaUIPoC.Base
{
    public class ApplicationLaunchSetUp
    {
        //public Window Window { get; set; }
        public static Application Application { get; set; }
        public static UIA3Automation Automation { get; set; }

        public ApplicationLaunchSetUp() { }

        public void Init()
        {
            Automation = new UIA3Automation();
            var si = new ProcessStartInfo();
            si.LoadUserProfile = false;
            si.UseShellExecute = false;
            si.FileName = @"C:\Program Files\QGIS 3.16\bin\qgis-ltr-bin-g7.exe";
            Application = Application.AttachOrLaunch(si);
            Console.WriteLine($"Launched application with process ID: {Application.ProcessId}");
            WaitForApplicationLaunch();
           // Window = Application.GetMainWindow(Automation, TimeSpan.FromSeconds(300));
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
                    windowCount = Application.GetAllTopLevelWindows(Automation).Length;
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

        public void Cleanup()
        {
            Automation.Dispose();
            Application.Close();
            Application.Kill();
        }

        public Window FindWindow(Func<Window, bool> predicateFunc)
        {
            using (var automation = new UIA3Automation())
            {
                return Application.GetAllTopLevelWindows(automation).FirstOrDefault(predicateFunc);
            }
        }
    }
}
