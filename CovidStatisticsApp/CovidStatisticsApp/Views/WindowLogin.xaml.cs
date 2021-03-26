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
        public WindowLogin()
        {
            InitializeComponent();
            //Set colors of backgrounds in Login Window
            ButtonSignIn.Background = Brushes.Yellow;
            ButtonChangePassword.Background = Brushes.Yellow;
            ButtonSignUp.Background = Brushes.Yellow;
            TextBoxFirstName.Background = Brushes.Yellow;
            TextBoxLastName.Background = Brushes.Yellow;
            PasswordBoxPassword.Background = Brushes.Yellow;
        }

        /// <summary>
        /// Sign in button check password and personal data
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ButtonSignIn_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
