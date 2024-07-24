using System.ComponentModel.DataAnnotations;

namespace Prescolaire.Validators
{
    public class AgeRangeAttribute : ValidationAttribute
    {
        private readonly int _minAge;
        private readonly int _maxAge;

        public AgeRangeAttribute(int minAge, int maxAge)
        {
            _minAge = minAge;
            _maxAge = maxAge;
        }

        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            if (value == null)
            {
                return new ValidationResult("Date of birth is required.");
            }

            if (value is DateOnly dateOfBirth)
            {
                var age = DateTime.Today.Year - dateOfBirth.Year;
                if (dateOfBirth.AddYears(age) > DateOnly.FromDateTime(DateTime.Today))
                {
                    age--;
                }

                if (age < _minAge || age > _maxAge)
                {
                    return new ValidationResult($"Age must be between {_minAge} and {_maxAge} years.");
                }

                return ValidationResult.Success;
            }

            return new ValidationResult("Invalid date of birth.");
        }
    }
}
