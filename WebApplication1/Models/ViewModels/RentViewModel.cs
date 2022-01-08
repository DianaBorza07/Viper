using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CarRental.Models.ViewModels
{
    public class RentViewModel
    {
        public Rental rent { set; get; }

        public String firstName { set; get; }

        public String lastName { set; get; }
    }
}
