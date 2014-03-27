using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ComputerStore.Models
{
    public class Address
    {
        [Display(Name = "Calle")]
        public string street { get; set; }

        [Display(Name = "Numero")]
        public string Number { get; set; }

        [Display(Name = "Población")]
        public string City { get; set; }

        [Display(Name = "País")]
        public string Country { get; set; }

        [Display(Name = "C.Postal")]
        public string CPostal { get; set; }
    }
}