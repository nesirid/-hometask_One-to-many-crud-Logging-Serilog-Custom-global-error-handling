using AutoMapper;
using Domain.Entities;
using Service.DTOs.Admin.Cities;
using Service.DTOs.Admin.Countries;

namespace Service.Helpers
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            //Country
            CreateMap<CountryCreateDto, Country>();
            CreateMap<Country, CountryDto>();
            CreateMap<CountryEditDto, Country>();
            //City
            CreateMap<CityCreateDto, City>();
            CreateMap<City, CityDto>();
            CreateMap<CityEditDto, City>();

        }

    }
}
