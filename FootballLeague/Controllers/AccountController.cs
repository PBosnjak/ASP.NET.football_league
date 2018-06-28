using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FootballLeague.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace FootballLeague.Controllers
{
    public class AccountController : Controller
    {
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly UserManager<IdentityUser> _userManager;
        private readonly SignInManager<IdentityUser> _signinManager;

        public AccountController(
            UserManager<IdentityUser> userManager, 
            RoleManager<IdentityRole> roleManager,
            SignInManager<IdentityUser> signinManager
            )
        {
            _userManager = userManager;
            _roleManager = roleManager;
            _signinManager = signinManager;
        }


        public IActionResult Login()
        {
            return View(new LoginViewModel());
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginViewModel login, string returnUrl = null)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }

            var result = await _signinManager.PasswordSignInAsync(
                login.UserName, login.Password,
                login.RememberMe, false
            );

            if (!result.Succeeded)
            {
                ModelState.AddModelError("", "Login error!");
                return View();
            }

            if (string.IsNullOrWhiteSpace(returnUrl))
                return RedirectToAction("Index", "Home");

            return Redirect(returnUrl);
        }

        [HttpPost]
        public async Task<IActionResult> Logout(string returnUrl = null)
        {
            await _signinManager.SignOutAsync();

            if (string.IsNullOrWhiteSpace(returnUrl))
                return RedirectToAction("Index", "Home");

            return Redirect(returnUrl);
        }

        public async Task<IActionResult> Create()
        {
            var identityRole = new IdentityRole
            {
                Id = "admin",
                Name = "admin"
            };

            if (!await _roleManager.RoleExistsAsync(roleName: identityRole.Name))
            {
                var result = await _roleManager.CreateAsync(identityRole);

                if (!result.Succeeded)
                {
                    var exceptionText = result.Errors.Aggregate("Role Creation Failed - Identity Exception. Errors were: \n\r\n\r", (current, error) => current + (" - " + error + "\n\r"));
                    throw new Exception(exceptionText);
                }
            }
            var user = new IdentityUser()
            {
                UserName = "admin",
                Email = "admin@mail.com"
            };

            if (await _userManager.FindByEmailAsync(user.Email) == null)
            {
                var result = await _userManager.CreateAsync(user, "Wintus2.123");

                if (!result.Succeeded)
                {
                    var exceptionText = result.Errors.Aggregate("User Creation Failed - Identity Exception. Errors were: \n\r\n\r", (current, error) => current + (" - " + error + "\n\r"));
                    throw new Exception(exceptionText);
                }

                result = await _userManager.AddToRoleAsync(user, identityRole.Name);
            }
            return Redirect("/");
        }

    }
}