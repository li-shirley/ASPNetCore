using System.ComponentModel.DataAnnotations;
namespace SimpleLoginRegistration.Models
{
    public class Registration
    {
        [Required (ErrorMessage = "field is required")]
        [MinLength(2, ErrorMessage = "must have at least 2 characters")]
        [Display (Name = "First Name")]
        public string FirstName {get;set;}

        [Required (ErrorMessage = "field is required")]
        [MinLength(2, ErrorMessage = "must have at least 2 characters")]
        [Display (Name = "Last Name")]
        public string LastName {get;set;}

        [Required (ErrorMessage = "field is required")]
        [DataType(DataType.EmailAddress)]
        public string Email {get;set;}

        [Required (ErrorMessage = "field is required")]
        [MinLength(8, ErrorMessage = "must have at least 8 characters")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Required (ErrorMessage = "field is required")]
        [Compare("Password", ErrorMessage = "must match Password")]
        [DataType(DataType.Password)]
        [Display(Name = "Confirm Password")]
        public string ConfirmPassword { get; set; }
    }

}