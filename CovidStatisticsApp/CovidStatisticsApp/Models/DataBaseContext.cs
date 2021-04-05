using CovidStatisticsApp.Models.Entities;
using System.Data.Entity;

namespace CovidStatisticsApp.Models
{
    public class DataBaseContext: DbContext
    {
        public DataBaseContext() : base("ConnectionString")
        {
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Country> Countries { get; set; }
    }
}
