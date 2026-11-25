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
using CoursesApp.Helpers;


namespace CoursesApp.Pages
{
    public partial class LoginPage : UserControl
    {
        public LoginPage() { InitializeComponent(); }

        private void BtnLogin_Click(object sender, RoutedEventArgs e)
        {
            var user = Data.AppData.Users.Authenticate(tbLogin.Text.Trim(), pbPassword.Password);
            if (user == null)
            {
                MessageBox.Show("Неверный логин или пароль");
                return;
            }
            NavigateToCabinet(user);
        }

        private void BtnRegister_Click(object sender, RoutedEventArgs e)
        {
            NavigationHelper.MainVM.CurrentPage = new RegisterPage();
        }

        internal static void NavigateToCabinet(User user)
        {
            if (user.Role == UserRole.Student)
                NavigationHelper.MainVM.CurrentPage = new StudentPage(user);
            else
                NavigationHelper.MainVM.CurrentPage = new TeacherPage(user);
        }
    }
}
