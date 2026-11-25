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
    /// Логика взаимодействия для CoursePage.xaml
    /// </summary>
    public partial class CoursePage : Page
    {
        private readonly User _user;
        public CoursePage(User user)
        {
            InitializeComponent();
            _user = user;
            lblUserName.Text = $"{_user.FullName} — {(_user.Role == UserRole.Student ? "студент" : "преподаватель")}";
            lbCourses.ItemsSource = Data.AppData.Courses;
        }

        private void BtnBack_Click(object sender, RoutedEventArgs e)
        {
            if (_user.Role == UserRole.Student)
                NavigationService.Navigate(new StudentPage(_user));
            else
                NavigationService.Navigate(new TeacherPage(_user));

            NavigationService.RemoveBackEntry();
        }

        private void BtnLogout_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.ClearJournalHistory();
            NavigationService.Navigate(new LoginPage());
            NavigationService.RemoveBackEntry();
        }
    }
}
