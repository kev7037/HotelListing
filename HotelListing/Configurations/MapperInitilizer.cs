using AutoMapper;
using HotelListing.Data;
using HotelListing.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HotelListing.Configurations
{
    public class MapperInitilizer : Profile
    {
        public MapperInitilizer()
        {
            CreateMap<Country, CountryDTO>().ReverseMap();
            CreateMap<Country, CreateCountryDTO>().ReverseMap();
            
            CreateMap<Hotel, HotelDTO>().ReverseMap();
            CreateMap<Country, CreateHotelDTO>().ReverseMap();
        }
    }
}
