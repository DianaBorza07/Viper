using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CarRental.Models
{
    public class Car
    {
        public int id { get; set; }

        [Required(ErrorMessage = "Car brand is required!")]
        [StringLength(255,ErrorMessage = "Brand cannot exceed 255 characters")]
        public string brand { get; set; }

        [Required(ErrorMessage = "Car model is required!")]
        [StringLength(255, ErrorMessage = "Model cannot exceed 255 characters")]
        public string model { get; set; }

        public DateTime fabricationDate { get; set; }

        public String photoPath { get; set; }


    }
}
