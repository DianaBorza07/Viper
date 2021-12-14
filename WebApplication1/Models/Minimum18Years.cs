using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication1.Models
{
    public class Minimum18Years : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var client = (Client)validationContext.ObjectInstance;

            // verify if birthdate is empty
            if (client.birthdate == null)
                return new ValidationResult("Birthdate is required!");

            //compute client age
            var age = DateTime.Today.Year - client.birthdate.Value.Year;

            if (age >= 18)
                return ValidationResult.Success; // client has 18 years
            else
                return new ValidationResult("Client must have at least 18 years old!");// client is too young

        }
    }
}
