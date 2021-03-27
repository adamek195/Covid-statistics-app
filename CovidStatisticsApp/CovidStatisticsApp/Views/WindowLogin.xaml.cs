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
    public partial class WindowLogin : Window
    {
        private readonly UsersRepository usersRepository;

        public WindowLogin()
        {
            usersRepository = new UsersRepository();
            InitializeComponent();

        }

        private void ButtonSignIn_Click(object sender, RoutedEventArgs e)
        {
            string firstName = TextBoxFirstName.Text;
            string lastName = TextBoxLastName.Text;
            string password = PasswordBoxPassword.Password;

            bool logged = usersRepository.SignIn(firstName, lastName, password);

            if (logged)
            {
                MessageBox.Show("You have logged in!", "Information", MessageBoxButton.OK, MessageBoxImage.Information );
                TextBoxFirstName.Text = "";
                TextBoxLastName.Text = "";
                PasswordBoxPassword.Password = "";
            }
            else
            {
                //Czyscimy dane
                MessageBox.Show("Invalid username or password!", "Błąd", MessageBoxButton.OK, MessageBoxImage.Error);
                TextBoxFirstName.Text = "";
                TextBoxLastName.Text = "";
                PasswordBoxPassword.Password = "";
            }
        }
    }
}
