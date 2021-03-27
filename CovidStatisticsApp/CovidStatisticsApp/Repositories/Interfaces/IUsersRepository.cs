using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CovidStatisticsApp.Repositories.Interfaces
{
    public interface IUsersRepository
    {
        bool SignIn(string firstName, string lastName, string password);
        bool ChangePassword(string firstName, string lastName, string email, string newPassword);
        bool SignUp(string firstName, string lastName, string email, string password);
    }
}
