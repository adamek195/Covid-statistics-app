using CovidStatisticsApp.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace CovidStatisticsApp.Views
{
    /// <summary>
    /// Interaction logic for WindowLogin.xaml
    /// </summary>
    public partial class WindowLogin : Window
    {
        private readonly UsersRepository usersRepository;

        /// <summary>
        /// Contructor for WindowLogin
        /// </summary>
        public WindowLogin()
        {
            usersRepository = new UsersRepository();
            InitializeComponent();
            WindowStartupLocation = WindowStartupLocation.CenterScreen;
        }

        /// <summary>
        /// logic for button SignIn
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ButtonSignIn_Click(object sender, RoutedEventArgs e)
        {
            string firstName = TextBoxFirstName.Text;
            string lastName = TextBoxLastName.Text;
            string password = PasswordBoxPassword.Password;

            bool logged = usersRepository.SignIn(firstName, lastName, password);

            if (logged)
            {
                MessageBox.Show("You have logged in!", "Information", MessageBoxButton.OK, MessageBoxImage.Information);
                TextBoxFirstName.Text = "";
                TextBoxLastName.Text = "";
                PasswordBoxPassword.Password = "";
                MainWindow mainWindow = new MainWindow();
                mainWindow.Show();
            }
            else
            {
                MessageBox.Show("Invalid username or password!", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                TextBoxFirstName.Text = "";
                TextBoxLastName.Text = "";
                PasswordBoxPassword.Password = "";
            }
        }

        /// <summary>
        /// logic for button ChangePassword
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ButtonChangePassword_Click(object sender, RoutedEventArgs e)
        {
            WindowChangePassword windowChangePassword = new WindowChangePassword();
            windowChangePassword.Show();
        }

        /// <summary>
        /// logic for button SignUp
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ButtonSignUp_Click(object sender, RoutedEventArgs e)
        {
            WindowSignUp windowSignUp = new WindowSignUp();
            windowSignUp.Show();
        }
    }
}
