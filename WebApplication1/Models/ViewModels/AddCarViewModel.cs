using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CarRental.Models.ViewModels
{
    public class AddCarViewModel
    {
        public Car car;

        [Required(ErrorMessage = "Brand is required!")]
        public String brand;

        [Required(ErrorMessage = "Model is required!")]
        public String model;

        [Required(ErrorMessage = "Date is required!")]
        public DateTime date;

        [Required(ErrorMessage = "Photo is required!")]
        public String photoPath;

        [Required(ErrorMessage = "Price is required!")]
        public float price;
    }
}
