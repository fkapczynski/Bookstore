using System.ComponentModel.DataAnnotations;

namespace BookStoreWebsite.Models
{
    public class AdressViewModel
    {
        [Required]
        //[Country]
        [Display(Name = "Kraj")]
        public string Country { get; set; }

        [Required]
        // [City]
        [Display(Name = "Miasto")]
        public string City { get; set; }

        [Required]
        //[Street]
        [Display(Name = "Ulica")]
        public string Street { get; set; }

        [Required]
        //[PostalCode]
        [Display(Name = "Kod pocztowy")]
        public string PostalCode { get; set; }

        [Required]
        //[HouseNumber]
        [Display(Name = "Numer Domu")]
        public string HouseNumber { get; set; }

        //[ApartmentNumber]
        [Display(Name = "Numer Mieszkania")]
        public string ApartmentNumber { get; set; }

    }
}