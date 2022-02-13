using System.ComponentModel.DataAnnotations;
namespace DateValidator.Models
{
    public class Date
    {
        [Required]
        // [DataType(DataType.DateTime)]
        [PastDate]
        [Display(Name = "Date:")] 
        public string Day {get;set;}

    }
}