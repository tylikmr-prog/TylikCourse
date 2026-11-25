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
    /// Логика взаимодействия для StudentPage.xaml
    /// </summary>
    public partial class StudentPage : Page
    {
        private readonly User _user;

        public StudentPage(User user)
        {
            InitializeComponent();
            _user = user;
            lblUserName.Text = $"Студент: {_user.FullName} (логин: {_user.Login})";
        }

        private void BtnCourses_Click(object sender, RoutedEventArgs e)
            => NavigationService.Navigate(new CoursePage(_user));

        private void BtnLogout_Click(object sender, RoutedEventArgs e)
        {
            // 1) очищаем журнал истории перед выходом
            NavigationService.ClearJournalHistory();
            // 2) на страницу входа
            NavigationService.Navigate(new LoginPage());
            NavigationService.RemoveBackEntry();
        }
    }
}
