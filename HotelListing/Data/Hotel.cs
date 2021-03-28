using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace HotelListing.Data
{
    public class Hotel
    {
        public int Id { get; set; }
     
        [Column(TypeName ="varchar(200)")]
        public string Name { get; set; }

        [Column(TypeName = "varchar(1000)")]
        public string Address { get; set; }

        public double? Rating { get; set; }

        [ForeignKey(nameof(Country))]
        public int CountryId { get; set; }
        public Country Country { get; set; }
    }
}
