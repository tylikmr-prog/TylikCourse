using CoursesApp.Helpers;
using CoursesApp.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace CoursesApp.Pages
{
    public partial class CoursePage : UserControl
    {
        private User _user;

        public CoursePage() { InitializeComponent(); }

        public CoursePage(User user) : this()
        {
            _user = user;
            lblUserName.Text = $"{user.FullName} — {(user.Role == UserRole.Student ? "студент" : "преподаватель")}";
            lbCourses.ItemsSource = Data.AppData.Courses;
        }

        private void BtnBack_Click(object sender, RoutedEventArgs e)
        {
            if (_user.Role == UserRole.Student)
                NavigationHelper.MainVM.CurrentPage = new StudentPage(_user);
            else
                NavigationHelper.MainVM.CurrentPage = new TeacherPage(_user);
        }

        private void BtnLogout_Click(object sender, RoutedEventArgs e)
        {
            NavigationHelper.MainVM.CurrentPage = new LoginPage();
        }
    }
}

