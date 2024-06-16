using System.ComponentModel.DataAnnotations;
using System.Text.RegularExpressions;

namespace GameStore.Data.Validations
{
    public class OnlyLettersAttribute : ValidationAttribute
    {
        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
        {
            if (value is string stringValue)
            {
                if (Regex.IsMatch(stringValue, @"^[a-zA-Z]+$"))
                {
                    return ValidationResult.Success;
                }
                else
                {
                    return new ValidationResult("The field can only contain letters.");
                }
            }

            return new ValidationResult("Invalid data type.");
        }
    }
}
