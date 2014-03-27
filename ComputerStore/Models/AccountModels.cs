using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Globalization;
using System.Web.Security;

namespace ComputerStore.Models
{
    public class UsersContext : DbContext
    {
        public UsersContext()
            : base("DefaultConnection")
        {
        }

        public DbSet<UserProfile> UserProfiles { get; set; }
    }


    public class UserProfileAndRegisterModel
    {
        //This class is to hold two models in one
        public UserProfile AUserProfile {get; set; }
        public RegisterModel ARegisterModel { get; set; }
    }


    [Table("UserProfile")]
    public class UserProfile
    {
        [Key]
        [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
        public int UserId { get; set; }

        public string UserName { get; set; }

        [Required(ErrorMessage = "Debe suministrar un correo electrónico")]
        [RegularExpression("^[a-zA-Z0-9_.+-]+@[a-zA-Z0-9-]+\\.[a-zA-Z0-9-.]+$", 
                  ErrorMessage = "La dirección de correo debe ser una dirección válida.")]
        [Display(Name = "eMail")]
        public string EMail { get; set; }

        [Display(Name = "Calle")]
        public string Street { get; set; }

        [Display(Name = "Numero")]
        public string Number { get; set; }

        [Display(Name = "Población")]
        public string City { get; set; }

        [Display(Name = "País")]
        public string Country { get; set; }

        [Display(Name = "C.Postal")]
        [RegularExpression("\\d{5}(-\\d{4})?",
                  ErrorMessage = "El código postal debe ser 12345 o 12345-6789.")]
        //[StringLength(5, ErrorMessage = "El {0} debe tener al {2} caracteres.", MinimumLength = 5)]
        public string CPostal { get; set; }
    }

    public class RegisterExternalLoginModel
    {
        [Required]
        [Display(Name = "Usuario")]
        public string UserName { get; set; }

        public string ExternalLoginData { get; set; }
    }

    public class LocalPasswordModel
    {
        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string OldPassword { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "El {0} debe tener al menos {2} caracteres.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "Nuevo password")]
        public string NewPassword { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Confirma el nuevo password")]
        [Compare("NewPassword", ErrorMessage = "La contraseña y su confirmación no coinciden.")]
        public string ConfirmPassword { get; set; }
    }

    public class LoginModel
    {
        [Required]
        [Display(Name = "Usuario")]
        public string UserName { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string Password { get; set; }

        [Display(Name = "¿Recordarme?")]
        public bool RememberMe { get; set; }
    }

    public class RegisterModel
    {
        [Key]
        [Required]
        [Display(Name = "Usuario")]
        public string UserName { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "El {0} debe tener al menos {2} caracteres.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Confirma el nuevo password")]
        [Compare("Password", ErrorMessage = "La contraseña y su confirmación no coinciden.")]
        public string ConfirmPassword { get; set; }
    }

    public class ExternalLogin
    {
        public string Provider { get; set; }
        public string ProviderDisplayName { get; set; }
        public string ProviderUserId { get; set; }
    }
}
