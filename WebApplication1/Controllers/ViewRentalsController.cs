using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CarRental.Models;
using CarRental.Models.AppDBContext;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CarRental.Controllers
{
    public class ViewRentalsController : Controller
    {
        private readonly ApplicationDBContext _context;

        public ViewRentalsController(ApplicationDBContext context)
        {
            _context = context;
        }
        public async Task<IActionResult> Index()
        {
            var rentals = await _context.Rentals.ToListAsync();
            var rentalModels = new List<Rental>();
            foreach (Rental rent in rentals)
            {
                var aux = new Rental();
                aux.user = rent.user;
                aux.car = rent.car;
                aux.clientFirstName = rent.clientFirstName;
                aux.clientLastName = rent.clientLastName;
                aux.id = rent.id;
                aux.rentalDate = rent.rentalDate;
                if(aux.clientFirstName!=null && aux.clientLastName!=null)
                 rentalModels.Add(aux);
                
            }
            ViewBag.rentals = rentalModels;
            return View();
        }
    }
}
