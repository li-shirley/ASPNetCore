using System;
using System.ComponentModel.DataAnnotations;
namespace DateValidator.Models
{
    public class PastDateAttribute : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            DateTime dateTime;
            if (value is DateTime)
            {
                dateTime = (DateTime)value;
            }
            else
            {
                return new ValidationResult("Invalid datetime format.");
            }
            if (dateTime > DateTime.Now)
            {
                return new ValidationResult("Date and time must be in the past.");
            }
            return ValidationResult.Success;
        }
    }
}