using AutoMapper;
using CovidStatisticsApp.Infrastructure;
using CovidStatisticsApp.Models;


namespace CovidStatisticsApp.Repositories
{
    /// <summary>
    /// An abstract class that has variables and/or methods that each repository should contain
    /// </summary>
    public abstract class Repository
    {
        protected readonly DataBaseContext DbContext = new DataBaseContext();

        private static MapperConfiguration MapperConfig = new MapperConfiguration(cfg => cfg.AddProfile(new MapperProfile()));

        protected readonly IMapper Mapper = MapperConfig.CreateMapper();
    }
}
