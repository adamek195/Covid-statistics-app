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
    /// Interaction logic for WindowSignUp.xaml
    /// </summary>
    public partial class WindowSignUp : Window
    {
        private readonly UsersRepository usersRepository;

        /// <summary>
        /// Contructor for SingUp
        /// </summary>
        public WindowSignUp()
        {
            usersRepository = new UsersRepository();
            InitializeComponent();
            WindowStartupLocation = WindowStartupLocation.CenterScreen;
        }

        /// <summary>
        /// Logic for button SingUp
        /// </summary>
        /// <param name="sender">Sender</param>
        /// <param name="e">Event</param>
        private void ButtonSignUp_Click(object sender, RoutedEventArgs e)
        {
            string firstName = TextBoxFirstName.Text;
            string lastName = TextBoxLastName.Text;
            string email = TextBoxEmail.Text;
            string newPassword = PasswordBoxPassword.Password;
            string newPasswordConfirm = PasswordBoxPasswordConfirm.Password;


            if (newPassword == newPasswordConfirm)
            {
                if (usersRepository.SignUp(firstName, lastName, email, newPassword))
                {
                    MessageBox.Show("You signed up!", "Information", MessageBoxButton.OK, MessageBoxImage.Information);
                }
                else
                {
                    MessageBox.Show("The user with such data already exists!", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
            else
            {
                MessageBox.Show("Passwords are not the same!", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }

            TextBoxFirstName.Text = "";
            TextBoxLastName.Text = "";
            TextBoxEmail.Text = "";
            PasswordBoxPassword.Password = "";
            PasswordBoxPasswordConfirm.Password = "";
        }
    }
}
