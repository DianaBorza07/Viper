using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CarRental.Models.ViewModels
{
    public class RegisterViewModel
    {
        [Required]
        [EmailAddress]
        public string Email { get; set; }
        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Confirm Password")]
        [Compare("Password", ErrorMessage = "Password and confirmation password not match.")]
        public string ConfirmPassword { get; set; }

        [Required]
        [Display(Name = "Phone number")]
        [StringLength(13,ErrorMessage = "Phone cannot exceed 13 characters")]
        public string PhoneNumber { get; set; }

        [Required]
        [Display(Name = "Driving License")]

        public string DrivingLicense { get; set; }

        [Required]
        [Display(Name = "Role")]
        public string Role { get; set; }
    }
}
