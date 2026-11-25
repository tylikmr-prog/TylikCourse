using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Navigation;

namespace CoursesApp.Helpers
{
    public static class NavigationServiceExtensions
    {
        public static void ClearJournalHistory(this NavigationService nav)
        {
            if (nav == null) return;
            while (nav.CanGoBack)
                nav.RemoveBackEntry();
        }
    }
}
