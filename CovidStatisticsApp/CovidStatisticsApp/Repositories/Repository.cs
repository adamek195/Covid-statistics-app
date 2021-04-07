using AutoMapper;
using CovidStatisticsApp.Infrastructure;
using CovidStatisticsApp.Models;


namespace CovidStatisticsApp.Repositories
{
    public abstract class Repository
    {
        protected readonly DataBaseContext DbContext = new DataBaseContext();

        private static MapperConfiguration MapperConfig = new MapperConfiguration(cfg => cfg.AddProfile(new MapperProfile()));

        protected readonly IMapper Mapper = MapperConfig.CreateMapper();
    }
}
