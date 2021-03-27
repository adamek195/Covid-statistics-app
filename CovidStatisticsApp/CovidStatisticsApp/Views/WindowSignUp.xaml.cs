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

        public WindowSignUp()
        {
            usersRepository = new UsersRepository();
            InitializeComponent();
            WindowStartupLocation = WindowStartupLocation.CenterScreen;
        }
    }
}
