using CovidStatisticsApp.Models.Entities;
using CovidStatisticsApp.Repositories.Interfaces;
using System.Linq;


namespace CovidStatisticsApp.Repositories
{
    public class UsersRepository : Repository, IUsersRepository
    {
        public bool SignIn(string firstName, string lastName, string password)
        {
            User user = DbContext.Users.SingleOrDefault(u => u.FirstName == firstName && u.LastName == lastName && u.Password == password);
            return user != null;
        }

        public bool ChangePassword(string firstName, string lastName, string email, string newPassword)
        {
            User userToEdit = DbContext.Users.FirstOrDefault(u => u.FirstName == firstName && u.LastName == lastName && u.Email == email);

            if (userToEdit == null)
                return false;

            userToEdit.Password = newPassword;

            return DbContext.SaveChanges() > 0;
        }
    }
}
