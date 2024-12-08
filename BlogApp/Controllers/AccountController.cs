using BlogApp.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Routing;

namespace StudentEnrollmentSystemMVC.Controllers
{
    [AllowAnonymous]
    public class AccountController : Controller
    {

        private readonly UserManager<IdentityUser> _userManager;
        private readonly SignInManager<IdentityUser> _signInManager;

        public AccountController(UserManager<IdentityUser> userManager, SignInManager<IdentityUser> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
        }

        public IActionResult Login(string returnUrl = null)
        {
            ViewData["ReturnUrl"] = returnUrl;

            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(LoginViewModel loginViewModel, string returnUrl = null)
        {
            ViewData["ReturnUrl"] = returnUrl;
            if (ModelState.IsValid)
            {
                var user = await _userManager.FindByEmailAsync(loginViewModel.Email);
                if (user != null)
                {
                    var result = await _signInManager.PasswordSignInAsync(user.UserName, loginViewModel.Password, loginViewModel.RememberMe, lockoutOnFailure: false);
                    if (result.Succeeded)
                    {
                        return RedirectToAction("Details", "Users", new { id = 1 });
                    }
                }

                ModelState.AddModelError(string.Empty, "Invalid login attempt.");
                return View(loginViewModel);
            }
            return View(loginViewModel);
        }
        /*
                public IActionResult Register()
                {
                    return View();
                }

                [HttpPost]
                [ValidateAntiForgeryToken]
                public async Task<IActionResult> Register(RegisterViewModel registerViewModel)
                {
                    if (ModelState.IsValid)
                    {
                        var user = new ApplicationUser { UserName = registerViewModel.UserName, Email = registerViewModel.Email };
                        var result = await _userManager.CreateAsync(user, registerViewModel.Password);
                        if (result.Succeeded)
                        {
                            await _signInManager.SignInAsync(user, isPersistent: false);
                            return RedirectToAction("Login", "Account");
                        }
                        foreach (var error in result.Errors)
                        {
                            ModelState.AddModelError(string.Empty, error.Description);
                        }
                    }
                    return View(registerViewModel);
                }

                public IActionResult ForgotPassword()
                {
                    return View();
                }

                [HttpPost]
                [ValidateAntiForgeryToken]
                public async Task<IActionResult> ForgotPassword(ForgotPasswordViewModel model)
                {
                    if (!ModelState.IsValid)
                    {
                        return View(model);
                    }

                    var user = await _userManager.FindByEmailAsync(model.Email);

                    if (user == null)
                    {
                        return RedirectToAction("ForgotPasswordConfirmation");
                    }

                    var token = await _userManager.GeneratePasswordResetTokenAsync(user);
                    var callbackUrl = Url.Action("ResetPassword", "Account", new { token, email = user.Email }, Request.Scheme);

                    await Helpers.EmailSend(model.Email, "Reset Password", $"Please reset your password by <a href='{callbackUrl}'>clicking here</a>.");

                    return RedirectToAction("ForgotPasswordConfirmation");
                }

                public IActionResult ForgotPasswordConfirmation()
                {
                    return View();
                }

                [AllowAnonymous]
                public IActionResult ResetPassword(string token, string email)
                {
                    if (token == null || email == null)
                    {
                        return RedirectToAction("Index", "Home");
                    }
                    var model = new ResetPasswordViewModel { Token = token, Email = email };
                    return View(model);
                }

                [HttpPost]
                [ValidateAntiForgeryToken]
                public async Task<IActionResult> ResetPassword(ResetPasswordViewModel model)
                {
                    if (!ModelState.IsValid)
                    {
                        return View(model);
                    }

                    var user = await _userManager.FindByEmailAsync(model.Email);
                    if (user == null)
                    {
                        return RedirectToAction("ResetPasswordConfirmation");
                    }

                    var result = await _userManager.ResetPasswordAsync(user, model.Token, model.Password);
                    if (result.Succeeded)
                    {
                        return RedirectToAction("ResetPasswordConfirmation");
                    }

                    foreach (var error in result.Errors)
                    {
                        ModelState.AddModelError(string.Empty, error.Description);
                    }

                    return View(model);
                }
        */
        public IActionResult ResetPasswordConfirmation()
        {
            return View();
        }

        public async Task<IActionResult> Logout()
        {
            await _signInManager.SignOutAsync();
            return RedirectToAction("Login", "Account");
        }

        [Route("Error/AccessDenied")]
        public IActionResult AccessDenied()
        {
            return View();
        }

    }
}