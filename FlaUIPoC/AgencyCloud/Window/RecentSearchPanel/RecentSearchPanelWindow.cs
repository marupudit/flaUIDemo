using FlaUI.Core.AutomationElements;
using FlaUI.Core.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlaUIPoC.AgencyCloud.Window.RecentSearchPanel
{
    public class RecentSearchPanelWindow
    {
        readonly AutomationElement _RecentSearchPanelWindow;

        public RecentSearchPanelWindow(FlaUI.Core.AutomationElements.Window window)
        {
            Wait.UntilResponsive(window);
            _RecentSearchPanelWindow = window.FindFirstDescendant(cf => cf.ByClassName("RecentPanel"));
            Assume.That(_RecentSearchPanelWindow, Is.Not.Null);
        }
    }
}
