using CoursesApp.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace CoursesApp.Helpers
{
    public static class NavigationHelper
    {
        public static MainViewModel MainVM =>
            (MainViewModel)Application.Current.MainWindow.DataContext;
    }
}
