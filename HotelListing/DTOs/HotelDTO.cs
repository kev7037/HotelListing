using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace HotelListing.DTOs
{
    public class CreateHotelDTO
    {
        [Required]
        [StringLength(maximumLength: 200, ErrorMessage = "Hotel name is too long")]
        public string Name { get; set; }

        [Required]
        [StringLength(maximumLength: 1000, ErrorMessage = "Address is too long")]
        public string Address { get; set; }

        [Range(1, 5)]
        public double? Rating { get; set; }

        [Required]
        public int CountryId { get; set; }

    }

    public class UpdateHotelDTO: CreateHotelDTO {}
    
    public class HotelDTO: CreateCountryDTO
    {
        public int Id { get; set; }

        public CountryDTO Country { get; set; }
    }
}