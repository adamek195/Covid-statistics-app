using CovidStatisticsApp.Models;


namespace CovidStatisticsApp.Repositories
{
    public abstract class Repository
    {
        protected readonly DataBaseContext DbContext = new DataBaseContext();
    }
}
