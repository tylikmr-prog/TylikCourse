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
    public partial class StudentPage : UserControl
    {
        private User _user;

        public StudentPage() { InitializeComponent(); }

        public StudentPage(User user) : this()
        {
            _user = user;
            lblUserName.Text = $"Студент: {user.FullName} (логин: {user.Login})";
        }

        private void BtnCourses_Click(object sender, RoutedEventArgs e)
        {
            NavigationHelper.MainVM.CurrentPage = new CoursePage(_user);
        }

        private void BtnLogout_Click(object sender, RoutedEventArgs e)
        {
            NavigationHelper.MainVM.CurrentPage = new LoginPage();
        }
    }
}
