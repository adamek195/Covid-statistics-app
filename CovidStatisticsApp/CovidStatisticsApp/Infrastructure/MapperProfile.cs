using CovidStatisticsApp.Models.Entities;
using CovidStatisticsApp.ViewModels;
using AutoMapper;


namespace CovidStatisticsApp.Infrastructure
{
    /// <summary>
    /// MapperProfile where Country is mapped on CountryViewModel
    /// </summary>
    class MapperProfile : Profile
    {
        public MapperProfile()
        {
            CreateMap<Country, CountryViewModel>()
                .ForMember(c => c.Name, opt => opt.MapFrom(src => src.Name));
        }
    }
}
