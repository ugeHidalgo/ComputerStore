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
        [StringLength(100, ErrorMessage = "Este campo no debe tener mas de 100 caracteres.")]
        public string Street { get; set; }

        [Display(Name = "Numero")]
        [StringLength(10, ErrorMessage = "Este campo no debe tener mas de 10 caracteres.")]
        public string Number { get; set; }

        [Display(Name = "Población")]
        [StringLength(100, ErrorMessage = "Este campo no debe tener mas de 100 caracteres.")]
        public string City { get; set; }

        [Display(Name = "País")]
        [StringLength(100, ErrorMessage = "Este campo no debe tener mas de 100 caracteres.")]
        public string Country { get; set; }

        [Display(Name = "C.Postal")]
        [RegularExpression("\\d{5}(-\\d{4})?",
                  ErrorMessage = "El código postal debe ser 12345 o 12345-6789.")]
        //[StringLength(5, ErrorMessage = "El {0} debe tener al {2} caracteres.", MinimumLength = 5)]
        public string CPostal { get; set; }
    }
}