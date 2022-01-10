using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CarRental.Models.AppDBContext;
using CarRental.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace CarRental.Controllers
{
    public class AddController : Controller
    {
        private readonly ApplicationDBContext _context;
        public AddController(ApplicationDBContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
          
            return View();
        }

        public async Task<IActionResult> ConfirmAdd(AddCarViewModel model)
        {
            Console.WriteLine("------+++----" + model.brand + " " + model.model + " " + model.price + " " + model.date);
            return View();
        }
    }
}
