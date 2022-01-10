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
                aux.price = car.price;
                carModel.Add(aux);

            }
            ViewBag.cars = carModel;
            return View();
        }
        public async Task<IActionResult> addCar()
        {
            return View();
        }

        /* public IActionResult ConfirmAdd()
         {
             AddCarViewModel model = new AddCarViewModel();
             Console.WriteLine("+++++-" + model.date);
             return View(model);
         }
     */

        /*public async Task<IActionResult> ConfirmAdd(IFormCollection form)
        {

            // Console.WriteLine(Request["data"].ToString());
             Console.WriteLine("+++"+form["data"]);
           // Console.WriteLine("----"+model.date);
            //Console.WriteLine(HttpContext.Request.QueryString["name"].toString());
            return View();

        }*/

        //[Route("{id:int}")]
        //[HttpPost]
        public ActionResult ConfirmAdd(AddCarViewModel model)
        {
            AddCarViewModel newModel = model;
            return View(model);
        }

    }
}
