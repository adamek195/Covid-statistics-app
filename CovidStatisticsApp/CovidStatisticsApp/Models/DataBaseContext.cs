using CovidStatisticsApp.Models.Entities;
using System.Data.Entity;

namespace CovidStatisticsApp.Models
{
    /// <summary>
    /// Class, where are defined database context and tables in the database
    /// </summary>
    public class DataBaseContext: DbContext
    {
        public DataBaseContext() : base("ConnectionString")
        {
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Country> Countries { get; set; }
    }
}
