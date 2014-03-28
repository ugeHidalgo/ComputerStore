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

        [Display(Name = "User Name")]
        [StringLength(150, ErrorMessage = "Este campo no debe tener mas de 150 caracteres.")]
        public string UserName { get; set; }

        [Display(Name = "First Name")]
        [StringLength(150, ErrorMessage = "Este campo no debe tener mas de 150 caracteres.")]
        public string FirstName { get; set; }

        [Display(Name = "Second Name")]
        [StringLength(150, ErrorMessage = "Este campo no debe tener mas de 150 caracteres.")]
        public string SecondName { get; set; }

        [Display(Name = "Fecha de Nacimiento")]
        [DataType(DataType.Date)]
        public DateTime? BirthDate { get; set; }

        [Display(Name = "Fecha de Registro")]
        [DataType(DataType.Date)]
        public DateTime RegDate { get; set; }

        [Display(Name = "DNI")]
        [StringLength(15, ErrorMessage = "Este campo no debe tener mas de 15 caracteres.")]
        public String IDNumber { get; set; }

        [Required(ErrorMessage = "Debe suministrar un correo electrónico")]
        [RegularExpression("^[a-zA-Z0-9_.+-]+@[a-zA-Z0-9-]+\\.[a-zA-Z0-9-.]+$", 
                  ErrorMessage = "La dirección de correo debe ser una dirección válida.")]
        [StringLength(100, ErrorMessage = "Este campo no debe tener mas de 100 caracteres.")]
        [Display(Name = "eMail")]
        public string EMail { get; set; }

        [Display(Name = "Dirección de Envío")]
        public Address SendingAddress { get; set; }

        [Display(Name = "Dirección de Facturación")]
        public Address InvoicingAddress { get; set; }

        [RegularExpression("^(\\(?\\+?[0-9]*\\)?)?[0-9_\\- \\(\\)]*$",
                  ErrorMessage = "Debe suministrar un número de tlf válido.")]
        [StringLength(20, ErrorMessage = "Este campo no debe tener mas de 20 caracteres.")]
        [Display(Name = "Teléfono fijo")]
        public string Phone { get; set; }

        [Display(Name = "Teléfono Móvil")]
        [StringLength(20, ErrorMessage = "Este campo no debe tener mas de 20 caracteres.")]
        public string Mobile { get; set; }

        [Display(Name = "Usuario Activo")]
        public Boolean Active { get; set; }

        public UserProfile()
        {
            SendingAddress = new Address();
            InvoicingAddress = new Address();
            RegDate = DateTime.Now;
            Active = true;
        }
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
        [Required(ErrorMessage = "Debe suministrar un nombre de usuario")]
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
