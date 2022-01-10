using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CarRental.Models.ViewModels
{
    public class RentViewModel
    {
        public Rental rent { set; get; }

        [Required (ErrorMessage="First name is required!")]
        public String clientFirstName { set; get; }

        [Required(ErrorMessage ="Last name is required")]
        public String clientLastName { set; get; }
    }
}
