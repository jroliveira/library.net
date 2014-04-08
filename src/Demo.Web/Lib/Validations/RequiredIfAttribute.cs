using System;
using System.ComponentModel.DataAnnotations;

namespace Demo.Web.Lib.Validations {

    [AttributeUsage(AttributeTargets.Property, AllowMultiple = true)]
    public class RequiredIfPropertyEqualToAttribute : ValidationAttribute {

        private readonly string _property;
        private readonly object _comparisonValue;

        public RequiredIfPropertyEqualToAttribute(string property, object comparisonValue) {
            _property = property;
            _comparisonValue = comparisonValue;
        }

        protected override ValidationResult IsValid(object value, ValidationContext validationContext) {
            try {
                var propertyValue = validationContext.ObjectType.GetProperty(_property).GetValue(validationContext.ObjectInstance);

                if (!propertyValue.Equals(_comparisonValue)) return ValidationResult.Success;
                
                return value != null 
                    ? ValidationResult.Success 
                    : new ValidationResult(FormatErrorMessage(validationContext.DisplayName));
            }
            catch {
                return new ValidationResult(FormatErrorMessage(validationContext.DisplayName));
            }
        }
    }
}