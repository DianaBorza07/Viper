using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CarRental.Models;
using CarRental.Models.AppDBContext;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApplication1.Models;

namespace CarRental.Controllers
{
    public class AdminCarController : Controller
    {
        private readonly ApplicationDBContext _context;

        public AdminCarController(ApplicationDBContext context)
        {
            _context = context;
        }
        public async Task<IActionResult> Index()
        {
            var cars = await _context.Cars.ToListAsync();
            var carModel = new List<Car>();
            foreach (Car car in cars)
            {
                var aux = new Car();
                aux.brand = car.brand;
                aux.id = car.id;
                aux.model = car.model;
                aux.photoPath = car.photoPath;
                aux.fabricationDate = car.fabricationDate;
                carModel.Add(aux);

            }
            ViewBag.cars = carModel;
            return View();
        }

        public async Task<IActionResult> addCar()
        {
            return View();
        }

    }
}
