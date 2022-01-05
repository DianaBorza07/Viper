using CarRental.Models;
using CarRental.Models.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;


namespace CarRental.Controllers
{
    public class AccountController : Controller
    {
        private readonly UserManager<User> _userManager;
        private readonly SignInManager<User> _signInManager;

        public AccountController(UserManager<User> userManager,
                                      SignInManager<User> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
        }
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Register()
        {
            List<String> responseCategory = new List<String>();
            responseCategory.Add("No");
            responseCategory.Add("Yes");
            ViewBag.responseCategory = responseCategory;
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Register(RegisterViewModel model)
        {
            if (ModelState.IsValid)
            {
                String[] userNameModel = model.Email.Split('@');
                String username = userNameModel[0];
                String createUsername = null;
                if (String.Compare(username, "null", comparisonType: StringComparison.OrdinalIgnoreCase) == 0)
                    createUsername = model.Email;
                else
                    createUsername = username;
                var user = new User 
                {
                    UserName = createUsername,
                    Email = model.Email,
                    PhoneNumber = model.PhoneNumber,
                    DrivingLicense = model.DrivingLicense,
                };

                var result = await _userManager.CreateAsync(user, model.Password);
                var result2 = await _userManager.AddToRoleAsync(user, Roles.Basic.ToString());

                if (result.Succeeded)
                {
                    await _signInManager.SignInAsync(user, isPersistent: false);

                    return RedirectToAction("index", "Home");
                }

                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError("", error.Description);
                }

                ModelState.AddModelError(string.Empty, "Invalid Register Attempt");

            }
            return View(model);
        }
        public async Task<IActionResult> Logout()
        {
            await _signInManager.SignOutAsync();

            return RedirectToAction("Login");
        }
        [HttpGet]
        [AllowAnonymous]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> Login(LoginViewModel user)
        {
            if (ModelState.IsValid)
            {
                String email = user.Email;
                String[] splitEmail = email.Split('@');
                String userName = null;
                if (String.Compare(splitEmail[0], "null", comparisonType: StringComparison.OrdinalIgnoreCase) == 0)
                    userName = user.Email;
                else
                    userName = splitEmail[0];
                var result = await _signInManager.PasswordSignInAsync(userName, user.Password, user.RememberMe, false);

                if (result.Succeeded)
                {  
                    var user1 =await  _userManager.FindByEmailAsync(user.Email);
                    if (user1 != null)
                    {
                        HttpContext.Session.SetString("User", JsonConvert.SerializeObject(user1));
                            return RedirectToAction("Index", "Home");
                    }
                    else ModelState.AddModelError(string.Empty, "Invalid login attempt");
                }


                ModelState.AddModelError(string.Empty, "Invalid Login Attempt");

            }
            return View(user);
        }

        }
    }
