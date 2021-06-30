using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YES.Shared.Dto;

namespace YES.Shared.Helper
{
    class CantBeNull : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var venue = value as VenueDto;
            if (venue.Name == null)
            {
                return new ValidationResult($"Please select a venue", new[] { validationContext.MemberName });
            }

            return ValidationResult.Success;
        }
    }
}
