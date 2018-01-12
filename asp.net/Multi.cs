using System;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text.RegularExpressions;

namespace Zaliczenie.Helpers
{

    [AttributeUsage(AttributeTargets.Property, AllowMultiple = false)]
    public class Multi : ValidationAttribute
    {
        public string ComparePropertyName { get; private set; }

        public Multi(string comparePropertyName)
        {
            ComparePropertyName = comparePropertyName;
           
        }
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {

            var comparePropertyValue = validationContext.ObjectType.GetProperty(ComparePropertyName).GetValue(validationContext.ObjectInstance);

            if (value == null)
            {
                return new ValidationResult(validationContext.DisplayName + " is required.");
            }



                return value.ToString()[0] == comparePropertyValue.ToString()[0] ?
                ValidationResult.Success
                : new ValidationResult(validationContext.DisplayName + " not pass!");
        }
    }
}
