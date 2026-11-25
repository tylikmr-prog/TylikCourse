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
    /// <summary>
    /// Логика взаимодействия для TeacherPage.xaml
    /// </summary>
    public partial class TeacherPage : Page
    {
        private readonly User _user;
        public TeacherPage(User user)
        {
            InitializeComponent();
            _user = user;
            lblUserName.Text = $"Преподаватель: {_user.FullName} (логин: {_user.Login})";
        }

        private void BtnCourses_Click(object sender, RoutedEventArgs e)
            => NavigationService.Navigate(new CoursePage(_user));

        private void BtnLogout_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.ClearJournalHistory();
            NavigationService.Navigate(new LoginPage());
            NavigationService.RemoveBackEntry();
        }
    }
}
