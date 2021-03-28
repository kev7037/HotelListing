using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace HotelListing.DTOs
{
    public class CreateCountryDTO
    {
        [Required]
        [StringLength(maximumLength:200, ErrorMessage ="Country name is too long")]
        public string Name { get; set; }

        [Required]
        [StringLength(maximumLength: 5, ErrorMessage = "Country shortname is too long")]
        public string ShortName { get; set; }
    }

    public class CountryDTO: CreateCountryDTO
    {
        public int Id { get; set; }
    }
}
