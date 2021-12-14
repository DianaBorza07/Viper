using System;
using System.ComponentModel.DataAnnotations;

namespace WebApplication1.Models
{
    public class Client
    {
        public int id { get; set; }

        [Required(ErrorMessage = "Name is required!")]
        [StringLength(255, ErrorMessage = "Name cannot exceed 255 characters!")]
        public string name { get; set; }

        [Display(Name = "Date of birth")]
        [Minimum18Years]
        public DateTime? birthdate { get; set; }

    }
}
