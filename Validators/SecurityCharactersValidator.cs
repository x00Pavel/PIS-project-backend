using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace video_pujcovna_back.Validators;

public class SecurityCharactersValidatorAttribute : ValidationAttribute
{
    protected override ValidationResult IsValid(object value, ValidationContext validationContext)
    {
        if (value != null)
        {
            string input = value.ToString();
            if (input.Any(c => c == '<' || c == '>' || c == '\'' || c == '\"' || c == '%' || c == ';'))
            {
                return new ValidationResult("Input contains special characters.");
            }
        }
        return ValidationResult.Success;
    }
}
