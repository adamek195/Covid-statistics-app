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
    /// Interaction logic for WindowChangePassword.xaml
    /// </summary>
    public partial class WindowChangePassword : Window
    {
        private readonly UsersRepository usersRepository;

        /// <summary>
        /// Constructor for WindowChangePassword
        /// </summary>
        public WindowChangePassword()
        {
            InitializeComponent();
            WindowStartupLocation = WindowStartupLocation.CenterScreen;
            usersRepository = new UsersRepository();
        }

        /// <summary>
        /// logic for button NewPassword
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ButtonNewPassword_Click(object sender, RoutedEventArgs e)
        {
            string firstName = TextBoxFirstName.Text;
            string lastName = TextBoxLastName.Text;
            string email = TextBoxEmail.Text;
            string newPassword = PasswordBoxPassword.Password;
            string newPasswordConfirm = PasswordBoxPasswordConfirm.Password;


            if (newPassword == newPasswordConfirm)
            {
                if (usersRepository.ChangePassword(firstName, lastName, email, newPassword))
                {
                    MessageBox.Show("You changed password!", "Warning", MessageBoxButton.OK, MessageBoxImage.Warning);
                }
                else
                {
                    MessageBox.Show("There is no such user in the database!", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
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
