using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace StreetCountryWebApp.Services
{
    public static class ModelValidator
    {
        public static bool IsValid<T>(this T obj, out List<string> errors) where T : class
        {
            errors = new List<string>();
            if (obj == null)
                return false;

            var validationResults = new List<ValidationResult>();
            var context = new ValidationContext(obj);

            if (!Validator.TryValidateObject(obj, context, validationResults, true))
            {
                foreach (var error in validationResults)
                {
                    errors.Add(error.ErrorMessage);
                }
            }
            return errors.Count == 0;
        }
    }
}
