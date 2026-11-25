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
    /// Логика взаимодействия для LoginPage.xaml
    /// </summary>
    public partial class LoginPage : Page
    {
        public LoginPage()
        {
            InitializeComponent();
        }

        private void BtnLogin_Click(object sender, RoutedEventArgs e)
        {
            var user = Data.AppData.Users.Authenticate(tbLogin.Text.Trim(), pbPassword.Password);
            if (user == null)
            {
                MessageBox.Show("Неверный логин или пароль");
                return;
            }
            NavigateToCabinet(user, NavigationService);
        }

        private void BtnRegister_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new RegisterPage());
            NavigationService.RemoveBackEntry();
        }

        /// <summary>Единая точка перехода в кабинет по роли (используется и из RegisterPage).</summary>
        internal static void NavigateToCabinet(User user, NavigationService nav)
        {
            if (user.Role == UserRole.Student)
                nav.Navigate(new StudentPage(user));
            else
                nav.Navigate(new TeacherPage(user));
            nav.RemoveBackEntry(); // нельзя вернуться «Назад» на логин
        }
    }
}

