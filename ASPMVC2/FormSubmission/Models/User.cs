using System.ComponentModel.DataAnnotations;
namespace FormSubmission.Models
{
    public class User
    {
        [Required]
        [MinLength(4, ErrorMessage = "First name must contain at least 4 characters")]
        [Display(Name = "First Name:")] 
        public string FirstName {get;set;}

        [Required]
        [MinLength(4, ErrorMessage = "Last name must contain at least 4 characters")]
        [Display(Name = "Last Name:")] 
        public string LastName {get;set;}

        [Required]
        [Range(0, int.MaxValue, ErrorMessage = "Age must be a positive number")]
        public int Age {get;set;}

        [Required]
        [EmailAddress]
        [Display(Name = "Email Address :")] 
        public string Email {get;set;}

        [Required]
        [MinLength(8, ErrorMessage = "Password must contain at least 8 characters.")]
        [DataType(DataType.Password)]
        public string Password {get;set;}
    }
}