using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace HotelListing.Data
{
    public class Country
    {
        public int Id { get; set; }
        
        [Column(TypeName = "varchar(200)")]
        public string Name { get; set; }
        
        [Column(TypeName = "varchar(5)")]
        public string ShortName { get; set; }

        public virtual IList<Hotel> Hotels { get; set; }
    }
}
