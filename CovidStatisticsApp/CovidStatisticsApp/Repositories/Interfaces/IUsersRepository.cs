using System;

namespace CovidStatisticsApp.Repositories.Interfaces
{
    /// <summary>
    /// An interface that defines methods related to communication
    /// with the database for the table User
    /// </summary>
    public interface IUsersRepository
    {
        /// <summary>
        /// abstract method for logging into the system
        /// </summary>
        /// <param name="firstName"></param>
        /// <param name="lastName"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        bool SignIn(string firstName, string lastName, string password);

        /// <summary>
        /// abstract method for changing user password
        /// </summary>
        /// <param name="firstName"></param>
        /// <param name="lastName"></param>
        /// <param name="email"></param>
        /// <param name="newPassword"></param>
        /// <returns></returns>
        bool ChangePassword(string firstName, string lastName, string email, string newPassword);

        /// <summary>
        /// abstract method for signing up into the system
        /// </summary>
        /// <param name="firstName"></param>
        /// <param name="lastName"></param>
        /// <param name="email"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        bool SignUp(string firstName, string lastName, string email, string password);
    }
}
