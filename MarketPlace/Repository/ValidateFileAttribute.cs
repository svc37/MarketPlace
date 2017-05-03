using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MarketPlace.Repository
{
    [AttributeUsage(AttributeTargets.Property)]
    public sealed class ValidateFileAttribute : ValidationAttribute
    {

        protected override ValidationResult IsValid(object value,
       ValidationContext validationContext)
        {
            HttpPostedFileBase file = value as HttpPostedFileBase;

            // The file is required.
            if (file == null)
            {
                return new ValidationResult("Please upload a file!");
            }

            // Everything OK.
            return ValidationResult.Success;
        }
    }
}