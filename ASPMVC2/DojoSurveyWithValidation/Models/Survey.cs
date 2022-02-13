using System.ComponentModel.DataAnnotations;
namespace DojoSurveyWithValidation.Models
{
    public class Survey
    {
        [Required]
        [MinLength(2, ErrorMessage = "Name must be at least 2 characters in length.")]
        [Display(Name = "Name:")]
        public string Name {get;set;}

        [Required]
        [Display(Name = "Dojo Location:")]
        public string Location {get;set;}

        [Required]
        [Display(Name = "Favorite Language:")]
        public string Language {get;set;}

        [MinLength(20, ErrorMessage = "Comment must be at least 20 characters in length.")]
        [Display(Name = "Comment (optional):")]
        public string Comment{get;set;}
    }
}