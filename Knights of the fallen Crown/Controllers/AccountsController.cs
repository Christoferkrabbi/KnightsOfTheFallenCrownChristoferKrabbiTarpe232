using KnightsOfTheFallenCrown.Core.Domain;
using KnightsOfTheFallenCrown.Data;
using KnightsOfTheFallenCrown.Models.Accounts;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Diagnostics;

namespace KnightsOfTheFallenCrown.Controllers
{
    public class AccountsController : Controller
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly KnightsOfTheFallenCrownContext _context;

        public AccountsController
            (UserManager<ApplicationUser> userManager,
            SignInManager<ApplicationUser> signInManager,
            KnightsOfTheFallenCrownContext context
            )
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _context = context;
        }
        [HttpGet]
        public async Task<IActionResult> AddPassword()
        {
            var user = await _userManager.GetUserAsync(User);
            var userHasPassword = await _userManager.HasPasswordAsync(user);
            if (userHasPassword)
            {
                RedirectToAction("ChangePassword");
            }
            return View();
        }



        [HttpPost]
        public async Task<IActionResult> AddPassword(AddPasswordViewModel model)
        {
            if (ModelState.IsValid)
            {
                var user = await _userManager.GetUserAsync(User);
                var result = await _userManager.AddPasswordAsync(user, model.NewPassword);
                if (!result.Succeeded)
                {
                    foreach (var error in result.Errors)
                    {
                        ModelState.AddModelError(string.Empty, error.Description);
                    }
                    return View();
                }
                await _signInManager.RefreshSignInAsync(user);
                return View("AddPasswordConfirmation");
            }
            return View(model);
        }



        [HttpGet]
        public IActionResult Register()
        {
            return View();  
        }

        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> Register(RegisterViewModel model)
        {
            if(ModelState.IsValid)
            {
                var user = new ApplicationUser
                {
                    UserName = model.Email,
                    Email = model.Email,
                    City = model.City,
                };
                var result = await _userManager.CreateAsync(user, model.Password);
                if (result.succeeded)
                {
                    var token = await _userManager.GenerateEmailConfirmationTokenAsync(user);
                    var confirmationLink = Url.Action("ConfirmEmail", "Accounts", new { userId = user.Id, token = token }, Request.Scheme);
                    if(SignInManager.IsSignedIn(User)&& User.IsInRole("Admin"))
                    {
                        return RedirectToAction("ListUsers", "Administrations");

                    }
                    ViewBag.ErrorTitle = "You have successfully registered.";
                    ViewBag.ErrorMessage = "Befire you can log in,  please confirm email fro link" +
                        "\nwe have emailed to your emaild address.";
                    return View("Error");
                }
                foreach(var error in result.Errors)
                {
                    ModelState.AddModelError("", error.Description);

                }
               
            }
            return View(); 
        }

        [HttpGet]
        [AllowAnonymous]
        public async Task<IActionResult> ConfirmEmail(string userId, string token)
        {
            if (userId == null || token == null){return RedirectToAction("Index", "Home");}
            var user = await _userManager.FindByIdAsync(userId);
            if (user == null)
            {
                ViewBag.ErrorMessage = $"The user with id of {userId} is not valid.";
                return View("NotFound");
            }
            var result = await _userManager.ConfirmEmailAsync(user, token);
            if (result.Succeeded)
            {
                return View();
            }
            ViewBag.ErrorTitle = "Emal cannot be confirmed";
            ViewBag.ErrorMessage = $"The users email, with userId of{userId}, ćannot be confirmed.";
            return View("Error");
     }
               

        [HttpGet]
        [AllowAnonymous]
        public async Task<IActionResult> Login(string? returnURL)
        {
            LoginViewModel vm = new()
            {
                ReturnURL = returnURL,

            };
            return View(vm);
        }



        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> Login(LoginViewModel model,string? returnURL)
        {
            if (!ModelState.IsValid)
            {
                var user = await _userManager.FindByEmailAsync(model.Email);
                if (user != null && !user.EmailConfirmed && (await _userManager.CheckPasswordAsync(user, model.Password))) 
                {
                    ModelState.AddModelError(string.Empty, "Your Email hasnt been confirmed yet. Please check your Email spam folf´ders.");
                    return View(model);
                }
                var result = await _signInManager.PasswordSignInAsync(model.Email, model.Password, model.RememberMe, true);
                if (result.Succeeded)
                {
                    if(!string.IsNullOrEmpty(returnURL)&& Url.IsLocalUrl(returnURL))
                    {
                        return Redirect(returnURL);
                    }
                    else
                    {
                        return RedirectToAction("Index", "Home");

                    }

                }
                if (result.IsLockedOut)
                {
                    return View("AccountLocked");

                }
                ModelState.AddModelError("", "Invalid Login Attempt, please contact admin");
            }
            return View(model);
        }
        [HttpPost]
        public async Task<IActionResult> LogOut()
        {
            await _signInManager.SignOutAsync();
            return RedirectToAction("Index", "Home");
        }

    }

}
