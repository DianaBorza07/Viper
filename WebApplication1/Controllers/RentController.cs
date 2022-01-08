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
            /*var obj = HttpContext.Session.GetString("User");
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
            var car = await _context.Cars.FindAsync(int.Parse(carId));
            Car car1 = (Car)car;
            ViewBag.car = car1.brand;
            Console.WriteLine("id: " + carId + " brand: " + car1.brand);

            DateTime currentDate = new DateTime();
            currentDate = DateTime.UtcNow;
            Console.WriteLine(currentDate);

            Random random = new Random();

            int rentId = random.Next(1, 2500);

            /*var find = _context.Rentals.FindAsync(rentId);
            while (find != null)
            {
                rentId = random.Next(1, 2500);
                find = _context.Rentals.FindAsync(rentId);
            }
            Rental rent = new Rental();
            rent.car = car1;
            rent.rentalDate = currentDate;
            rent.user = appUser;
            rent.id = rentId;
            Console.WriteLine("rentId: " + rentId + " rentCar: " + rent.car + " user: " + rent.user.UserName);

            model.rent = rent;
            //var res=await _context.Rentals.AddAsync(rent);
            //  Console.WriteLine(res);
            HttpContext.Session.SetString("FirstName", JsonConvert.SerializeObject(model.firstName));
            HttpContext.Session.SetString("LastName", JsonConvert.SerializeObject(model.lastName));
            */
            var obj = HttpContext.Session.GetString("User");
            User appUser = new User();
            if (obj != null)
            {
                var deserializedObj = JsonConvert.DeserializeObject<dynamic>(obj);
                appUser.AccessFailedCount = deserializedObj.AccessFailedCount;
                appUser.ConcurrencyStamp = deserializedObj.ConcurrencyStamp;
                //appUser.DrivingLicense = deserializedObj.DrivingLicense;
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
            }
            //int rentId = _context.Rentals.Select(p => p.id).DefaultIfEmpty(0).Max();
            int rentId;
            if (_context.Rentals.Any())
                rentId = _context.Rentals.Max(p => p.id);
            else rentId = 1;
            Console.WriteLine(rentId);

            DateTime currentDate = new DateTime();
            currentDate = DateTime.UtcNow;
            Console.WriteLine(currentDate);

            Rental rent = new Rental();
            rent.car = car;
            rent.rentalDate = currentDate;
            rent.user = appUser;
            rent.id = rentId;
            Console.WriteLine("rentId: " + rentId + " rentCar: " + rent.car.model + " user: " + rent.user.UserName);
            var res = await _context.Rentals.AddAsync(rent);
            Console.WriteLine(res);
            _context.SaveChangesAsync();
            return View();
        }
    }
}
