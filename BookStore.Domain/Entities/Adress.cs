using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStore.Domain.Entities
{
    public class Adress
    {
        [Key]
        public String UserId { get; set; }
        public String Country { get; set; }
        public String City { get; set; }
        public String Street { get; set; }
        public String PostalCode { get; set; }
        public String HouseNumber { get; set; }
        public String ApartmentNumber { get; set; }
    }
}
