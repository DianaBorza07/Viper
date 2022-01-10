using System;
using System.ComponentModel.DataAnnotations;

namespace CarRental.Models
{
    public class  Rental
    {   
        [Key]
        public int id { get; set; }

        [Required(ErrorMessage = "Client is required!")]
        public User user { get; set; }

        [Required(ErrorMessage = "Car is required!")]
        public Car car { get; set; }

        public DateTime rentalDate { get; set; }

        public String clientFirstName { get; set; }

        public String clientLastName { get; set; }

    }
}
