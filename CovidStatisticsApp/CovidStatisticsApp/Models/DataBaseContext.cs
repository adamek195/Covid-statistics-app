using CovidStatisticsApp.Models.Entities;
using System.Data.Entity;

namespace CovidStatisticsApp.Models
{
    /// <summary>
    /// Class where is initalized context of database
    /// </summary>
    public class DataBaseContext: DbContext
    {
        public DataBaseContext() : base("ConnectionString")
        {
        }

        /// <summary>
        /// Initialize tables in a database
        /// </summary>
        public DbSet<User> Users { get; set; }
    }
}
