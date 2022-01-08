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
                carModel.Add(aux);

            }
            ViewBag.cars = carModel;
            return View();
        }

        public async Task<IActionResult> RentCar(string carId)
        {
            ViewBag.carId = carId;
            var car = await _context.Cars.FindAsync(int.Parse(carId));
            Car car1 = (Car)car;
            ViewBag.car = car1.brand;
            Console.WriteLine("id: " + carId + " brand: " + car1.brand);
            HttpContext.Session.SetString("Car", JsonConvert.SerializeObject(car1));
            //HttpContext.Session.SetString("FirstName", JsonConvert.SerializeObject(model.firstName));
            //HttpContext.Session.SetString("LastName", JsonConvert.SerializeObject(model.lastName));
            return View();

        }

       
    }
}
