using CovidStatisticsApp.Models.Entities;
using CovidStatisticsApp.Repositories.Interfaces;
using System.Linq;


namespace CovidStatisticsApp.Repositories
{
    /// <summary>
    /// Class defining methods related to communication with the database for the Users table
    /// </summary>
    public class UsersRepository : Repository, IUsersRepository
    {
        /// <summary>
        /// implementation of method for logging into the system
        /// </summary>
        /// <param name="firstName"></param>
        /// <param name="lastName"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        public bool SignIn(string firstName, string lastName, string password)
        {
            User user = DbContext.Users.SingleOrDefault(u => u.FirstName == firstName && u.LastName == lastName && u.Password == password);
            return user != null;
        }

        /// <summary>
        /// implementation of method for changing user password
        /// </summary>
        /// <param name="firstName"></param>
        /// <param name="lastName"></param>
        /// <param name="email"></param>
        /// <param name="newPassword"></param>
        /// <returns></returns>
        public bool ChangePassword(string firstName, string lastName, string email, string newPassword)
        {
            User userToEdit = DbContext.Users.FirstOrDefault(u => u.FirstName == firstName && u.LastName == lastName && u.Email == email);

            if (userToEdit == null)
                return false;

            userToEdit.Password = newPassword;

            return DbContext.SaveChanges() > 0;
        }

        /// <summary>
        /// implementation of method for signing up into the system
        /// </summary>
        /// <param name="firstName"></param>
        /// <param name="lastName"></param>
        /// <param name="email"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        public bool SignUp(string firstName, string lastName, string email, string password)
        {
            User userToAdd = new User()
            {
                FirstName = firstName,
                LastName = lastName,
                Email = email,
                Password = password
            };

            User foundedUser = DbContext.Users.FirstOrDefault(u => u.FirstName == firstName && u.LastName == lastName
                                && u.Email == email && u.Password == password);
            if (foundedUser != null)
                return false;

            DbContext.Users.Add(userToAdd);

            return DbContext.SaveChanges() > 0;
        }
    }
}
