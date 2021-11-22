using System;
using System.ComponentModel.DataAnnotations;

namespace WebApplication1.Models
{
    public class Rental
    {
        public int id { get; set; }

        [Required(ErrorMessage = "Client is required!")]
        public Client client { get; set; }

        [Required(ErrorMessage = "Car is required!")]
        public Car car { get; set; }

        public DateTime rentalDate { get; set; }

        public DateTime? returnDate { get; set; }
    }
}
