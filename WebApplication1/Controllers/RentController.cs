using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CarRental.Models;
using CarRental.Models.AppDBContext;
using CarRental.Models.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace CarRental.Controllers
{
    public class RentController : Controller
    {
        private readonly ApplicationDBContext _context;

        public RentController(ApplicationDBContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            return View();
        }

       // [HttpPost]
        public async Task<IActionResult> PlaceOrder( RentViewModel model)
        {
            var obj = HttpContext.Session.GetString("User");
            User appUser = new User();
            if (obj != null)
            {
                var deserializedObj = JsonConvert.DeserializeObject<dynamic>(obj);
                appUser.AccessFailedCount = deserializedObj.AccessFailedCount;
                appUser.ConcurrencyStamp = deserializedObj.ConcurrencyStamp;
                appUser.DrivingLicense = deserializedObj.DrivingLicense;
                appUser.Email = deserializedObj.Email;
                appUser.EmailConfirmed = deserializedObj.EmailConfirmed;
                appUser.Id = deserializedObj.Id;
                appUser.LockoutEnabled = deserializedObj.LockoutEnabled;
                appUser.LockoutEnd = deserializedObj.LockoutEnd;
                appUser.NormalizedEmail = deserializedObj.NormalizedEmail;
                appUser.NormalizedUserName = deserializedObj.NormalizedUserName;
                appUser.PasswordHash = deserializedObj.PasswordHash;
                appUser.PhoneNumber = deserializedObj.PhoneNumber;
                appUser.PhoneNumberConfirmed = deserializedObj.PhoneNumberConfirmed;
                appUser.SecurityStamp = deserializedObj.SecurityStamp;
                appUser.TwoFactorEnabled = deserializedObj.TwoFactorEnabled;
                appUser.UserName = deserializedObj.UserName;
            }

            var obj2 = HttpContext.Session.GetString("Car");
            Car car = new Car();
            if (obj2 != null)
            {
                var deserializedCar = JsonConvert.DeserializeObject<dynamic>(obj2);
                car.id = deserializedCar.id;
                car.model = deserializedCar.model;
                car.brand = deserializedCar.brand;
                car.fabricationDate = deserializedCar.fabricationDate;
                car.photoPath = deserializedCar.photoPath;
                car.price = deserializedCar.price;
            }
         

            DateTime currentDate = new DateTime();
            currentDate = DateTime.UtcNow;
            Console.WriteLine(currentDate);
            String firstName = model.clientFirstName;
            String lastName = model.clientLastName;

            Rental rent = new Rental();

            rent.car = _context.Cars.Where(car1 => car1.id == car.id).FirstOrDefault(); 
            rent.rentalDate = currentDate;
            rent.user =  _context.Users.Where(user => user.Id == appUser.Id).FirstOrDefault();
            rent.clientFirstName = firstName;
            rent.clientLastName = lastName;
            var res = await _context.Rentals.AddAsync(rent);
            await _context.SaveChangesAsync();

            ViewBag.rentUser1 = rent.clientFirstName;
            ViewBag.rentUser2 = rent.clientLastName;
            ViewBag.rentDate = currentDate;
            ViewBag.rentCarBrand = car.brand;
            ViewBag.rentCarModel = car.model;
            ViewBag.rentCarPrice = car.price;
            ViewBag.rentCarDate = car.fabricationDate;
            return View();
        }
    }
}
