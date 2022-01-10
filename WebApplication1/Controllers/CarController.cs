using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CarRental.Models;
using CarRental.Models.AppDBContext;
using CarRental.Models.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;

namespace CarRental.Controllers
{
    public class CarController : Controller
    {
        private readonly ApplicationDBContext _context;
        private readonly RentViewModel model;


        public CarController(ApplicationDBContext context)
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
                aux.price = car.price;
                carModel.Add(aux);

            }
            ViewBag.cars = carModel;
            return View();
        }

        public async Task<IActionResult> RentCar(RentViewModel model,string carId)
        {
            ViewBag.carId = carId;
            var car = await _context.Cars.FindAsync(int.Parse(carId));
            Car car1 = (Car)car;
            ViewBag.carBrand = car1.brand ;
            ViewBag.carModel = car1.model;
            ViewBag.carPhoto = car1.photoPath;
            HttpContext.Session.SetString("Car", JsonConvert.SerializeObject(car1));
            return View();

        }

       
    }
}
