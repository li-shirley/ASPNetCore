using System.ComponentModel.DataAnnotations;
namespace SimpleLoginRegistration.Models
{
    public class Login
    {
        [Required (ErrorMessage = "field is required")]
        [DataType(DataType.EmailAddress)]
        [Display(Name = "Email")]
        public string LoginEmail {get;set;}

        [Required (ErrorMessage = "field is required")]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string LoginPassword { get; set; }
    }
}