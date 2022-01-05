using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using CarRental.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using WebApplication1.Models;

namespace CarRental.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly UserManager<User> _userManager;
        private readonly SignInManager<User> _signInManager;
        public HomeController(ILogger<HomeController> logger, UserManager<User> userManager,
                                      SignInManager<User> signInManager)
        {
            _logger = logger;
            _userManager = userManager;
            _signInManager = signInManager;
        }

        public IActionResult Index()
        {
            int Ok = 0;
            var obj = HttpContext.Session.GetString("User");
            if(obj!=null)
            {
                var deserializedObj = JsonConvert.DeserializeObject<dynamic>(obj);
                User appUser = new User();
                Ok = 1;
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
                ViewData["User"] = appUser.UserName;
                ViewData["ok"] = Ok;
            }
            
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
