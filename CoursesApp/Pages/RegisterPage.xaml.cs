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
    /// Логика взаимодействия для RegisterPage.xaml
    /// </summary>
    public partial class RegisterPage : Page
    {
        public RegisterPage()
        {
            InitializeComponent();
        }

        private void BtnRegister_Click(object sender, RoutedEventArgs e)
        {
            var login = tbLogin.Text.Trim();
            var pwd = pbPassword.Password;
            var name = tbFullName.Text.Trim();

            if (string.IsNullOrWhiteSpace(login) ||
                string.IsNullOrWhiteSpace(pwd) ||
                string.IsNullOrWhiteSpace(name))
            {
                MessageBox.Show("Заполните все поля");
                return;
            }
            if (Data.AppData.Users.LoginExists(login))
            {
                MessageBox.Show("Такой логин уже занят");
                return;
            }

            var user = new User
            {
                Login = login,
                Password = pwd,
                FullName = name,
                Role = cbRole.SelectedIndex == 1 ? UserRole.Teacher : UserRole.Student
            };
            Data.AppData.Users.Add(user);

            LoginPage.NavigateToCabinet(user, NavigationService); 
        }

        private void BtnBack_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new LoginPage());
            NavigationService.RemoveBackEntry();
        }
    }
}

