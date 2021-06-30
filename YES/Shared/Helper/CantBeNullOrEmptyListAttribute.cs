using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using YES.Shared.Dto;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YES.Shared.Helper
{
    public class CantBeNullOrEmptyListAttribute : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var categories = value as IEnumerable<TicketCategoryDto>;
            if (categories.Count() == 0)
            {
                return new ValidationResult($"Please enter a ticket category", new[] {validationContext.MemberName });
            }

            return ValidationResult.Success;
        }
    }
}
